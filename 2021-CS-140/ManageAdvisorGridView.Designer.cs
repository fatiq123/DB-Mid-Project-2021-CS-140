namespace _2021_CS_140
{
    partial class ManageAdvisorGridView
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.advisorCloseBtn = new System.Windows.Forms.Button();
            this.advisorDeleteBtn = new System.Windows.Forms.Button();
            this.advisorUpdateBtn = new System.Windows.Forms.Button();
            this.manageStudentForm = new System.Windows.Forms.Panel();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.advisorSearchBox = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.manageStudentForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(957, 353);
            this.dataGridView1.TabIndex = 0;
            // 
            // advisorCloseBtn
            // 
            this.advisorCloseBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.advisorCloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advisorCloseBtn.Location = new System.Drawing.Point(836, 431);
            this.advisorCloseBtn.Name = "advisorCloseBtn";
            this.advisorCloseBtn.Size = new System.Drawing.Size(104, 44);
            this.advisorCloseBtn.TabIndex = 13;
            this.advisorCloseBtn.Text = "Close";
            this.advisorCloseBtn.UseVisualStyleBackColor = true;
            this.advisorCloseBtn.Click += new System.EventHandler(this.advisorCloseBtn_Click);
            // 
            // advisorDeleteBtn
            // 
            this.advisorDeleteBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.advisorDeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advisorDeleteBtn.Location = new System.Drawing.Point(284, 431);
            this.advisorDeleteBtn.Name = "advisorDeleteBtn";
            this.advisorDeleteBtn.Size = new System.Drawing.Size(104, 44);
            this.advisorDeleteBtn.TabIndex = 12;
            this.advisorDeleteBtn.Text = "Delete";
            this.advisorDeleteBtn.UseVisualStyleBackColor = true;
            // 
            // advisorUpdateBtn
            // 
            this.advisorUpdateBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.advisorUpdateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advisorUpdateBtn.Location = new System.Drawing.Point(153, 431);
            this.advisorUpdateBtn.Name = "advisorUpdateBtn";
            this.advisorUpdateBtn.Size = new System.Drawing.Size(104, 44);
            this.advisorUpdateBtn.TabIndex = 11;
            this.advisorUpdateBtn.Text = "Update";
            this.advisorUpdateBtn.UseVisualStyleBackColor = true;
            // 
            // manageStudentForm
            // 
            this.manageStudentForm.Controls.Add(this.SearchLabel);
            this.manageStudentForm.Controls.Add(this.advisorSearchBox);
            this.manageStudentForm.Controls.Add(this.dataGridView2);
            this.manageStudentForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manageStudentForm.Location = new System.Drawing.Point(0, 0);
            this.manageStudentForm.Name = "manageStudentForm";
            this.manageStudentForm.Size = new System.Drawing.Size(981, 528);
            this.manageStudentForm.TabIndex = 14;
            this.manageStudentForm.Paint += new System.Windows.Forms.PaintEventHandler(this.manageStudentForm_Paint);
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
            // advisorSearchBox
            // 
            this.advisorSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advisorSearchBox.Location = new System.Drawing.Point(641, 30);
            this.advisorSearchBox.Name = "advisorSearchBox";
            this.advisorSearchBox.Size = new System.Drawing.Size(217, 26);
            this.advisorSearchBox.TabIndex = 7;
            this.advisorSearchBox.TextChanged += new System.EventHandler(this.advisorSearchBox_TextChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Delete});
            this.dataGridView2.Location = new System.Drawing.Point(15, 67);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(949, 322);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
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
            // ManageAdvisorGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 528);
            this.Controls.Add(this.advisorCloseBtn);
            this.Controls.Add(this.advisorDeleteBtn);
            this.Controls.Add(this.advisorUpdateBtn);
            this.Controls.Add(this.manageStudentForm);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ManageAdvisorGridView";
            this.Text = "ManageAdvisorGridView";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.manageStudentForm.ResumeLayout(false);
            this.manageStudentForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button advisorCloseBtn;
        private System.Windows.Forms.Button advisorDeleteBtn;
        private System.Windows.Forms.Button advisorUpdateBtn;
        private System.Windows.Forms.Panel manageStudentForm;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.TextBox advisorSearchBox;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}