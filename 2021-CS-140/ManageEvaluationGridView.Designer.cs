namespace _2021_CS_140
{
    partial class ManageEvaluationGridView
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
            this.closeBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.projectSearchBox = new System.Windows.Forms.TextBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.manageStudentForm = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.manageStudentForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Location = new System.Drawing.Point(836, 431);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(104, 44);
            this.closeBtn.TabIndex = 9;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Delete});
            this.dataGridView1.Location = new System.Drawing.Point(10, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(949, 322);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // projectSearchBox
            // 
            this.projectSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectSearchBox.Location = new System.Drawing.Point(641, 30);
            this.projectSearchBox.Name = "projectSearchBox";
            this.projectSearchBox.Size = new System.Drawing.Size(217, 26);
            this.projectSearchBox.TabIndex = 7;
            this.projectSearchBox.TextChanged += new System.EventHandler(this.studentSearchBox_TextChanged);
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchLabel.Location = new System.Drawing.Point(543, 30);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(70, 24);
            this.SearchLabel.TabIndex = 8;
            this.SearchLabel.Text = "Search";
            // 
            // manageStudentForm
            // 
            this.manageStudentForm.Controls.Add(this.SearchLabel);
            this.manageStudentForm.Controls.Add(this.projectSearchBox);
            this.manageStudentForm.Controls.Add(this.dataGridView1);
            this.manageStudentForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manageStudentForm.Location = new System.Drawing.Point(0, 0);
            this.manageStudentForm.Name = "manageStudentForm";
            this.manageStudentForm.Size = new System.Drawing.Size(971, 522);
            this.manageStudentForm.TabIndex = 10;
            this.manageStudentForm.Paint += new System.Windows.Forms.PaintEventHandler(this.manageStudentForm_Paint);
            // 
            // ManageProjectGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 522);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.manageStudentForm);
            this.Name = "ManageProjectGridView";
            this.Text = "ManageStudentGridView";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.manageStudentForm.ResumeLayout(false);
            this.manageStudentForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox projectSearchBox;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Panel manageStudentForm;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}