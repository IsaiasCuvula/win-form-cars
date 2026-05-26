namespace Cars
{
    partial class FormMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            introduction_btn = new Button();
            report_exit = new Button();
            logout = new Button();
            ordersBtn = new Button();
            SuspendLayout();
            // 
            // introduction_btn
            // 
            introduction_btn.Location = new Point(125, 24);
            introduction_btn.Name = "introduction_btn";
            introduction_btn.Size = new Size(120, 33);
            introduction_btn.TabIndex = 0;
            introduction_btn.Text = "Cars";
            introduction_btn.UseVisualStyleBackColor = true;
            introduction_btn.Click += button1_Click;
            // 
            // report_exit
            // 
            report_exit.Location = new Point(125, 136);
            report_exit.Name = "report_exit";
            report_exit.Size = new Size(120, 33);
            report_exit.TabIndex = 1;
            report_exit.Text = "Reports";
            report_exit.UseVisualStyleBackColor = true;
            report_exit.Click += button2_Click;
            // 
            // logout
            // 
            logout.Location = new Point(125, 193);
            logout.Name = "logout";
            logout.Size = new Size(120, 35);
            logout.TabIndex = 2;
            logout.Text = "Exit";
            logout.UseVisualStyleBackColor = true;
            logout.Click += logout_Click;
            // 
            // ordersBtn
            // 
            ordersBtn.Location = new Point(125, 81);
            ordersBtn.Name = "ordersBtn";
            ordersBtn.Size = new Size(120, 33);
            ordersBtn.TabIndex = 3;
            ordersBtn.Text = "Orders";
            ordersBtn.UseVisualStyleBackColor = true;
            ordersBtn.Click += ordersBtn_Click;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 261);
            Controls.Add(ordersBtn);
            Controls.Add(logout);
            Controls.Add(report_exit);
            Controls.Add(introduction_btn);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cars - Menu Principal";
            ResumeLayout(false);
        }

        #endregion

        private Button introduction_btn;
        private Button report_exit;
        private Button logout;
        private Button ordersBtn;
    }
}
