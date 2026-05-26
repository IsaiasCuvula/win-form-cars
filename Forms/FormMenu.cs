using Cars.Database;
using Cars.Forms;
using System;
using System.Windows.Forms;

namespace Cars
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            this.Text = $"Cars - Menu Principal ({Session.UserName})";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCars formCars = new FormCars();
            formCars.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormReport formReport = new FormReport();
            formReport.ShowDialog();
        }

        private void ordersBtn_Click(object sender, EventArgs e)
        {

            FormOrders formReport = new FormOrders();
            formReport.ShowDialog();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Session.UserId = 0;
            Session.UserName = "";
            this.Close();
        }
    }
}
