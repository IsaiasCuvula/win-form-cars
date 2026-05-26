namespace Cars.Forms
{
    partial class FormReport
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
            dtpFilter = new DateTimePicker();
            dgvReport = new DataGridView();
            btnExport = new Button();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 21);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 0;
            label1.Text = "Orders Before:";
            // 
            // dtpFilter
            // 
            dtpFilter.CustomFormat = "dd/MM/yyyy";
            dtpFilter.Format = DateTimePickerFormat.Custom;
            dtpFilter.Location = new Point(36, 49);
            dtpFilter.Name = "dtpFilter";
            dtpFilter.Size = new Size(148, 23);
            dtpFilter.TabIndex = 1;
            // 
            // dgvReport
            // 
            dgvReport.AllowUserToAddRows = false;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Location = new Point(1, 135);
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new Size(643, 366);
            dgvReport.TabIndex = 24;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(153, 95);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(120, 23);
            btnExport.TabIndex = 26;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(36, 95);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(117, 23);
            btnSearch.TabIndex = 25;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // FormReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 504);
            Controls.Add(btnExport);
            Controls.Add(btnSearch);
            Controls.Add(dgvReport);
            Controls.Add(dtpFilter);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Orders Report";
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpFilter;
        private DataGridView dgvReport;
        private Button btnExport;
        private Button btnSearch;
    }
}