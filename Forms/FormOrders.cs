using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using Cars.Database;

namespace Cars.Forms
{
    public partial class FormOrders : Form
    {
        private int selectedOrderNumber = -1;

        public FormOrders()
        {
            InitializeComponent();
            LoadTaxis();
            LoadOrders();
        }

        private void LoadTaxis()
        {
            using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                var cmd = new SqliteCommand(
                    "SELECT CodeTaxi, RegNumber || ' - ' || CarBrand AS Display FROM Cars", conn);

                cmbTaxi.Items.Clear();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbTaxi.Items.Add(new ComboItem(
                            Convert.ToInt32(reader["CodeTaxi"]),
                            reader["Display"].ToString()
                        ));
                    }
                }

                if (cmbTaxi.Items.Count > 0)
                    cmbTaxi.SelectedIndex = 0;
            }
        }

        private void LoadOrders()
        {
            using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                string sql = @"
                SELECT o.OrderNumber, c.RegNumber, c.CarBrand, 
                       o.Address, o.OrderTime, o.Distance, o.Fare
                FROM Orders o
                INNER JOIN Cars c ON o.CodeTaxi = c.CodeTaxi
                WHERE o.UserId = @userId
                ORDER BY o.OrderTime DESC";

                var cmd = new SqliteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userId", Session.UserId);

                var ds = new DataSet();
                ds.EnforceConstraints = false;
                var dt = ds.Tables.Add("Orders");

                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }

                dgvOrders.DataSource = dt;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
          if (cmbTaxi.SelectedItem == null ||
               string.IsNullOrWhiteSpace(txtAddress.Text) ||
               string.IsNullOrWhiteSpace(txtDistance.Text) ||
               string.IsNullOrWhiteSpace(txtFare.Text))
            {
                MessageBox.Show("Fill in all the fields!", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtDistance.Text.Replace(",", "."),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out double distance) || distance <= 0)
            {
                MessageBox.Show("Distance must be a positive number!", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtFare.Text.Replace(",", "."),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out double fare) || fare <= 0)
            {
                MessageBox.Show("Fare must be a positive number!", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var taxi = (ComboItem)cmbTaxi.SelectedItem;
            string orderTime = dtpOrderTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

            using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                string sql;

                if (selectedOrderNumber == -1)
                {
                    sql = @"INSERT INTO Orders (CodeTaxi, UserId, Address, OrderTime, Distance, Fare)
                    VALUES (@taxi, @user, @address, @time, @distance, @fare)";
                }
                else
                {
                    sql = @"UPDATE Orders SET CodeTaxi=@taxi, UserId=@user, Address=@address,
                    OrderTime=@time, Distance=@distance, Fare=@fare
                    WHERE OrderNumber=@order";
                }

                var cmd = new SqliteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@taxi", taxi.Id);
                cmd.Parameters.AddWithValue("@user", Session.UserId);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@time", orderTime);
                cmd.Parameters.AddWithValue("@distance", distance);
                cmd.Parameters.AddWithValue("@fare", fare);

                if (selectedOrderNumber != -1)
                    cmd.Parameters.AddWithValue("@order", selectedOrderNumber);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show(selectedOrderNumber == -1 ? "Order added successfully!" : "Order updated!",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearForm();
            LoadOrders();
        }

        private void ClearForm()
        {
            selectedOrderNumber = -1;
            cmbTaxi.SelectedIndex = cmbTaxi.Items.Count > 0 ? 0 : -1;
            txtAddress.Clear();
            dtpOrderTime.Value = DateTime.Now;
            txtDistance.Clear();
            txtFare.Clear();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

            if (selectedOrderNumber == -1)
            {
                MessageBox.Show("Select an order from the table!", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this car", "Confirmantion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqliteCommand(
                        "DELETE FROM Orders WHERE OrderNumber=@order", conn);
                    cmd.Parameters.AddWithValue("@order", selectedOrderNumber);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Order deleted!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadOrders();
            }

        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            var row = dgvOrders.Rows[e.RowIndex];
            selectedOrderNumber = Convert.ToInt32(row.Cells["OrderNumber"].Value);
            txtAddress.Text = row.Cells["Address"].Value.ToString();
            dtpOrderTime.Value = Convert.ToDateTime(row.Cells["OrderTime"].Value);
            txtDistance.Text = row.Cells["Distance"].Value.ToString();
            txtFare.Text = row.Cells["Fare"].Value.ToString();

            string regNumber = row.Cells["RegNumber"].Value.ToString();
            foreach (ComboItem item in cmbTaxi.Items)
            {
                if (item.ToString().StartsWith(regNumber))
                {
                    cmbTaxi.SelectedItem = item;
                    break;
                }
            }

        }
    }
}

public class ComboItem
{
    public int Id { get; set; }
    public string Display { get; set; }

    public ComboItem(int id, string display)
    {
        Id = id;
        Display = display;
    }

    public override string ToString() => Display;
}

