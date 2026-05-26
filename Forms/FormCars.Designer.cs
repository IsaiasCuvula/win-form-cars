namespace Cars.Forms
{
    partial class FormCars
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
            label1 = new Label();
            txtRegNumber = new TextBox();
            txtCarBrand = new TextBox();
            label2 = new Label();
            txtDriverName = new TextBox();
            label3 = new Label();
            label4 = new Label();
            nudSeats = new NumericUpDown();
            label5 = new Label();
            chkLuggage = new CheckBox();
            btnSave = new Button();
            btnDelete = new Button();
            dgvCars = new DataGridView();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudSeats).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCars).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(141, 19);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 0;
            label1.Text = "Reg. Number:";
            // 
            // txtRegNumber
            // 
            txtRegNumber.Location = new Point(240, 16);
            txtRegNumber.Name = "txtRegNumber";
            txtRegNumber.Size = new Size(172, 23);
            txtRegNumber.TabIndex = 1;
            // 
            // txtCarBrand
            // 
            txtCarBrand.Location = new Point(240, 45);
            txtCarBrand.Name = "txtCarBrand";
            txtCarBrand.Size = new Size(172, 23);
            txtCarBrand.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(141, 53);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 2;
            label2.Text = "Car Brand:";
            // 
            // txtDriverName
            // 
            txtDriverName.Location = new Point(240, 128);
            txtDriverName.Name = "txtDriverName";
            txtDriverName.Size = new Size(172, 23);
            txtDriverName.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(141, 131);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 4;
            label3.Text = "Driver Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(141, 77);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 6;
            label4.Text = "Seats (3-10):";
            // 
            // nudSeats
            // 
            nudSeats.Location = new Point(242, 74);
            nudSeats.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudSeats.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            nudSeats.Name = "nudSeats";
            nudSeats.Size = new Size(120, 23);
            nudSeats.TabIndex = 7;
            nudSeats.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(141, 102);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 8;
            label5.Text = "Luggage:";
            // 
            // chkLuggage
            // 
            chkLuggage.AutoSize = true;
            chkLuggage.Location = new Point(242, 103);
            chkLuggage.Name = "chkLuggage";
            chkLuggage.Size = new Size(43, 19);
            chkLuggage.TabIndex = 9;
            chkLuggage.Text = "Yes";
            chkLuggage.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(154, 175);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(117, 23);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(277, 175);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 23);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvCars
            // 
            dgvCars.AllowUserToAddRows = false;
            dgvCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCars.Location = new Point(0, 229);
            dgvCars.Name = "dgvCars";
            dgvCars.ReadOnly = true;
            dgvCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCars.Size = new Size(643, 278);
            dgvCars.TabIndex = 12;
            dgvCars.CellContentClick += dgvCars_CellContentClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(147, 104);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 13;
            label6.Text = "Luggage:";
            // 
            // FormCars
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 507);
            Controls.Add(label6);
            Controls.Add(dgvCars);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(chkLuggage);
            Controls.Add(nudSeats);
            Controls.Add(label4);
            Controls.Add(txtDriverName);
            Controls.Add(label3);
            Controls.Add(txtCarBrand);
            Controls.Add(label2);
            Controls.Add(txtRegNumber);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormCars";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cars Management";
            Load += FormCars_Load;
            ((System.ComponentModel.ISupportInitialize)nudSeats).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCars).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtRegNumber;
        private TextBox txtCarBrand;
        private Label label2;
        private TextBox txtDriverName;
        private Label label3;
        private Label label4;
        private NumericUpDown nudSeats;
        private Label label5;
        private CheckBox chkLuggage;
        private Button btnSave;
        private Button btnDelete;
        private DataGridView dgvCars;
        private Label label6;
    }
}