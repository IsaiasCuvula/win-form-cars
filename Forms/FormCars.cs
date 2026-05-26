using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using Cars.Database;

namespace Cars.Forms
{
    public partial class FormCars : Form
    {
        private int selectedCodeTaxi = -1;

        public FormCars()
        {
            InitializeComponent();
            LoadCars();
        }

        private void LoadCars()
        {
            using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT CodeTaxi, RegNumber, CarBrand, Seats, Luggage, DriverName FROM Cars";
                var cmd = new SqliteCommand(sql, conn);

                var ds = new DataSet();
                ds.EnforceConstraints = false;
                var dt = ds.Tables.Add("Cars");

                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }

                foreach (DataRow row in dt.Rows)
                    row["Luggage"] = row["Luggage"].ToString() == "1" ? "Yes" : "No";

                dgvCars.DataSource = dt;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegNumber.Text) ||
                string.IsNullOrWhiteSpace(txtCarBrand.Text) ||
                string.IsNullOrWhiteSpace(txtDriverName.Text))
            {
                MessageBox.Show("Fill in all the forms!", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                string sql;

                if (selectedCodeTaxi == -1)
                {
                    sql = @"INSERT INTO Cars (RegNumber, CarBrand, Seats, Luggage, DriverName)
                            VALUES (@reg, @brand, @seats, @luggage, @driver)";
                }
                else
                {
                    sql = @"UPDATE Cars SET RegNumber=@reg, CarBrand=@brand, 
                            Seats=@seats, Luggage=@luggage, DriverName=@driver
                            WHERE CodeTaxi=@code";
                }

                var cmd = new SqliteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@reg", txtRegNumber.Text.Trim());
                cmd.Parameters.AddWithValue("@brand", txtCarBrand.Text.Trim());
                cmd.Parameters.AddWithValue("@seats", (int)nudSeats.Value);
                cmd.Parameters.AddWithValue("@luggage", chkLuggage.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@driver", txtDriverName.Text.Trim());

                if (selectedCodeTaxi != -1)
                    cmd.Parameters.AddWithValue("@code", selectedCodeTaxi);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show(selectedCodeTaxi == -1 ? "Car added successfully!" : "Car updated!",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearForm();
            LoadCars();
        }

        private void ClearForm()
        {
            selectedCodeTaxi = -1;
            txtRegNumber.Clear();
            txtCarBrand.Clear();
            nudSeats.Value = 4;
            chkLuggage.Checked = false;
            txtDriverName.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCodeTaxi == -1)
            {
                MessageBox.Show("Select a car in the table!", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this car?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqliteCommand(
                        "DELETE FROM Cars WHERE CodeTaxi=@code", conn);
                    cmd.Parameters.AddWithValue("@code", selectedCodeTaxi);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Car deleted!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadCars();
            }
        }

        private void dgvCars_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvCars.Rows[e.RowIndex];
            selectedCodeTaxi = Convert.ToInt32(row.Cells["CodeTaxi"].Value);
            txtRegNumber.Text = row.Cells["RegNumber"].Value.ToString();
            txtCarBrand.Text = row.Cells["CarBrand"].Value.ToString();
            nudSeats.Value = Convert.ToInt32(row.Cells["Seats"].Value);
            chkLuggage.Checked = row.Cells["Luggage"].Value.ToString() == "1";
            txtDriverName.Text = row.Cells["DriverName"].Value.ToString();
        }
    }
}