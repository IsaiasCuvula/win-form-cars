using Cars.Database;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cars.Forms
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
            dtpFilter.Value = DateTime.Now;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filterDate = dtpFilter.Value.ToString("yyyy-MM-dd");

            using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT 
                        c.RegNumber      AS 'Reg. Number',
                        c.CarBrand       AS 'Brand',
                        COUNT(o.OrderNumber) AS 'Total Orders',
                        SUM(o.Fare)      AS 'Total (Euro)'
                    FROM Orders o
                    INNER JOIN Cars c ON o.CodeTaxi = c.CodeTaxi
                    WHERE o.OrderTime < @date
                    GROUP BY c.CodeTaxi, c.RegNumber, c.CarBrand
                    ORDER BY SUM(o.Fare) DESC";

                var cmd = new SqliteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@date", filterDate);

                var dt = new DataTable();
                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }

                dgvReport.DataSource = dt;

                if (dt.Rows.Count == 0)
                    MessageBox.Show("No orders find for this date.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            if (dgvReport.Rows.Count == 0)
            {
                MessageBox.Show("First, do some research!", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt";
            sfd.FileName = $"Relatorio_{DateTime.Now:yyyyMMdd_HHmm}.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    sw.WriteLine("=== ORDERS REPORTS ===");
                    sw.WriteLine($"Orders before: {dtpFilter.Value:dd/MM/yyyy}");
                    sw.WriteLine($"Issued at: {DateTime.Now:dd/MM/yyyy HH:mm}");
                    sw.WriteLine(new string('-', 60));

                    // Header
                    foreach (DataGridViewColumn col in dgvReport.Columns)
                        sw.Write($"{col.HeaderText,-20}");
                    sw.WriteLine();
                    sw.WriteLine(new string('-', 60));

                    // Data
                    foreach (DataGridViewRow row in dgvReport.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                            sw.Write($"{cell.Value,-20}");
                        sw.WriteLine();
                    }

                    sw.WriteLine(new string('-', 60));
                    sw.WriteLine($"Total orders: {dgvReport.Rows.Count}");
                }

                MessageBox.Show($"Exported successfully!\n{sfd.FileName}", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
