namespace Cars.Forms
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnRegister = new Button();
            btnLogin = new Button();
            txtEGN = new TextBox();
            label3 = new Label();
            txtPassword = new TextBox();
            passwordLabel = new Label();
            labelUsername = new Label();
            label1 = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
            SuspendLayout();
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(226, 245);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(120, 26);
            btnRegister.TabIndex = 35;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(103, 245);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(117, 26);
            btnLogin.TabIndex = 34;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtEGN
            // 
            txtEGN.Location = new Point(180, 195);
            txtEGN.Name = "txtEGN";
            txtEGN.Size = new Size(192, 23);
            txtEGN.TabIndex = 32;
            txtEGN.TextChanged += txtEGN_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(81, 198);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 31;
            label3.Text = "EGN:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(180, 157);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(192, 23);
            txtPassword.TabIndex = 30;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(81, 165);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(60, 15);
            passwordLabel.TabIndex = 29;
            passwordLabel.Text = "Password:";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(81, 131);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(63, 15);
            labelUsername.TabIndex = 28;
            labelUsername.Text = "Username:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F);
            label1.Location = new Point(53, 27);
            label1.Name = "label1";
            label1.Size = new Size(357, 45);
            label1.TabIndex = 37;
            label1.Text = "Welcome to our system";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(120, 72);
            label2.Name = "label2";
            label2.Size = new Size(196, 15);
            label2.TabIndex = 38;
            label2.Text = "Order taxi, manage orders and live...";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(180, 128);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(192, 23);
            txtUsername.TabIndex = 39;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 351);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Controls.Add(txtEGN);
            Controls.Add(label3);
            Controls.Add(txtPassword);
            Controls.Add(passwordLabel);
            Controls.Add(labelUsername);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Taxi - Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnRegister;
        private Button btnLogin;
        private TextBox txtEGN;
        private Label label3;
        private TextBox txtPassword;
        private Label passwordLabel;
        private Label labelUsername;
        private Label label1;
        private Label label2;
        private TextBox txtUsername;
    }
}