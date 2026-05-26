namespace Cars.Forms
{
    partial class FormOrders
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
            btnDelete = new Button();
            btnSave = new Button();
            label4 = new Label();
            txtDistance = new TextBox();
            label3 = new Label();
            txtAddress = new TextBox();
            addressLabel = new Label();
            label1 = new Label();
            dgvOrders = new DataGridView();
            cmbTaxi = new ComboBox();
            dtpOrderTime = new DateTimePicker();
            txtFare = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(215, 193);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 23);
            btnDelete.TabIndex = 22;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(92, 193);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(117, 23);
            btnSave.TabIndex = 21;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(88, 77);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 18;
            label4.Text = "Date/Time:";
            // 
            // txtDistance
            // 
            txtDistance.Location = new Point(187, 106);
            txtDistance.Name = "txtDistance";
            txtDistance.Size = new Size(192, 23);
            txtDistance.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(88, 109);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 16;
            label3.Text = "Distance (km):";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(187, 45);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(192, 23);
            txtAddress.TabIndex = 15;
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new Point(88, 53);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(52, 15);
            addressLabel.TabIndex = 14;
            addressLabel.Text = "Address:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 19);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 12;
            label1.Text = "Taxi:";
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(0, 235);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(643, 278);
            dgvOrders.TabIndex = 23;
            dgvOrders.CellContentClick += dgvOrders_CellContentClick;
            // 
            // cmbTaxi
            // 
            cmbTaxi.FormattingEnabled = true;
            cmbTaxi.Location = new Point(187, 16);
            cmbTaxi.Name = "cmbTaxi";
            cmbTaxi.Size = new Size(192, 23);
            cmbTaxi.TabIndex = 24;
            // 
            // dtpOrderTime
            // 
            dtpOrderTime.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpOrderTime.Format = DateTimePickerFormat.Custom;
            dtpOrderTime.Location = new Point(187, 77);
            dtpOrderTime.Name = "dtpOrderTime";
            dtpOrderTime.Size = new Size(192, 23);
            dtpOrderTime.TabIndex = 25;
            // 
            // txtFare
            // 
            txtFare.Location = new Point(187, 139);
            txtFare.Name = "txtFare";
            txtFare.Size = new Size(192, 23);
            txtFare.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(88, 142);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 26;
            label2.Text = "Fare (lv):";
            // 
            // FormOrders
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 511);
            Controls.Add(txtFare);
            Controls.Add(label2);
            Controls.Add(dtpOrderTime);
            Controls.Add(cmbTaxi);
            Controls.Add(dgvOrders);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(label4);
            Controls.Add(txtDistance);
            Controls.Add(label3);
            Controls.Add(txtAddress);
            Controls.Add(addressLabel);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "FormOrders";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cars - Orders";
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDelete;
        private Button btnSave;
        private Label label4;
        private TextBox txtDistance;
        private Label label3;
        private TextBox txtAddress;
        private Label addressLabel;
        private Label label1;
        private DataGridView dgvOrders;
        private ComboBox cmbTaxi;
        private DateTimePicker dtpOrderTime;
        private TextBox txtFare;
        private Label label2;
    }
}