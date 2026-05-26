using Cars.Database;
using Microsoft.Data.Sqlite;
using static System.Collections.Specialized.BitVector32;


namespace Cars.Forms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string egn = txtEGN.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(egn))
            {
                MessageBox.Show("Fill in all fields!", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateEGN(egn))
            {
                MessageBox.Show("Invalid EGN! Must have exactly 10 digits.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                var cmd = new SqliteCommand(@"
                    SELECT COUNT(*) FROM Users
                    WHERE UserName=@user AND Password=@pass AND EGN=@egn", conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.Parameters.AddWithValue("@egn", egn);

                long count = (long)cmd.ExecuteScalar();

                if (count > 0)
                {
                    var cmdId = new SqliteCommand(
                      "SELECT Id FROM Users WHERE UserName=@user", conn);
                    cmdId.Parameters.AddWithValue("@user", username);
                    Session.UserId = Convert.ToInt32(cmdId.ExecuteScalar());
                    Session.UserName = username;

                    MessageBox.Show($"Welcome, {username}!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    FormMenu menu = new FormMenu();
                    menu.ShowDialog();
                  
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Username, password or EGN!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string egn = txtEGN.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(egn))
            {
                MessageBox.Show("Fill in all fields before register!", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateEGN(egn))
            {
                MessageBox.Show("Invalid EGN! Must have exactly 10 digits.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                try
                {
                    var cmd = new SqliteCommand(@"
                        INSERT INTO Users (UserName, Password, EGN)
                        VALUES (@user, @pass, @egn)", conn);
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);
                    cmd.Parameters.AddWithValue("@egn", egn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User successfully registered! You can now log in.",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqliteException)
                {
                    MessageBox.Show("Username already exists! Choose another one.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void txtEGN_TextChanged(object sender, EventArgs e)
        {

        }


        private bool ValidateEGN(string egn)
        {
            if (egn.Length != 10) return false;
            foreach (char c in egn)
                if (!char.IsDigit(c)) return false;
            return true;
        }

    }
}
