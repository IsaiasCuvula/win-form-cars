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

        private void FormCars_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            LoadCars();
        }

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
                string sql = "SELECT * FROM Cars";
                var cmd = new SqliteCommand(sql, conn);
                var dt = new DataTable();

                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }

                dgvCars.DataSource = dt;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegNumber.Text) ||
                string.IsNullOrWhiteSpace(txtCarBrand.Text) ||
                string.IsNullOrWhiteSpace(txtDriverName.Text))
            {
                MessageBox.Show("Preenche todos os campos!", "Atenção",
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

            MessageBox.Show(selectedCodeTaxi == -1 ? "Carro adicionado!" : "Carro atualizado!",
                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                MessageBox.Show("Seleciona um carro na tabela!", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Tens a certeza que queres apagar?", "Confirmar",
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

                MessageBox.Show("Carro apagado!", "Sucesso",
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