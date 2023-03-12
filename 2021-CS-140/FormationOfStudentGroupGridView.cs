﻿using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace _2021_CS_140
{
    public partial class FormationOfStudentGroupGridView : Form
    {
        // to make it global
        private DataTable stdDataTable = new DataTable();

        public FormationOfStudentGroupGridView()
        {
            InitializeComponent();
        }

        private void closeBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void studentSearchBox_TextChanged(object sender, EventArgs e)
        {

            try
            {
                //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = String.Format("ObtainedMarks Like '%" + markEvaluationSearchBox.Text + "%'");
                string searchValue = groupStudentSearchBox.Text.Trim();

                if (string.IsNullOrEmpty(searchValue))
                {
                    // Clear the filter if the search box is empty
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "";
                }
                else
                {
                    // Apply the filter based on the search value
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = String.Format("Convert(GroupId, 'System.String') Like '%{0}%'", searchValue);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");

            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int groupId = Convert.ToInt32(row.Cells["GroupId"].Value.ToString()); // Replace ID_COLUMN_NAME with the name of the ID column in your database table
                // Replace NAME_COLUMN_NAME with the name of the name column in your database table
                int studentId = Convert.ToInt32(row.Cells["StudentId"].Value.ToString());
                int status = Convert.ToInt32(row.Cells["Status"].Value.ToString());

                string date = row.Cells["AssignmentDate"].Value.ToString();
                // Similarly, get the values of all other columns you want to edit


                // Show a form with textboxes to edit the data
                EditFormationOfStudentGroup editForm = new EditFormationOfStudentGroup(groupId, studentId, status, date);
                DialogResult result = editForm.ShowDialog();
                
                // If the user clicks OK on the edit form, update the data in the database
                if (result == DialogResult.OK)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE GroupStudent SET GroupId=@GroupId, StudentId=@StudentId, Status=@Status, AssignmentDate=@AssignmentDate WHERE Id=@Id", con);
                    cmd.Parameters.AddWithValue("@GroupId", groupId);
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@AssignmentDate", date);
                    cmd.ExecuteNonQuery();



                    // Update the data in the DataGridView control
                    row.Cells["GroupId"].Value = groupId;
                    row.Cells["StudentId"].Value = studentId;
                    row.Cells["Status"].Value = status;
                    row.Cells["AssignmentDate"].Value = date;
                    con.Close();
                }
            }

        }

        private void FormationOfStudentGroupGridView_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");

            // create a SqlCommand object
            SqlCommand cmd = new SqlCommand("Select GroupId,StudentId,Status,AssignmentDate FROM GroupStudent", con);

            // create a SqlDataAdapter object
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // create a DataTable object
            DataTable dt = new DataTable();

            // fill the DataTable with data from the database
            da.Fill(dt);

            // set the DataGridView's DataSource property to the DataTable
            dataGridView1.DataSource = dt;
        }
    }
}
