using Microsoft.IdentityModel.Protocols;
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
    public partial class MarkEvaluationAgainstGroupGridView : Form
    {
        public MarkEvaluationAgainstGroupGridView()
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
                string searchValue = markEvaluationSearchBox.Text.Trim();

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
            catch(Exception ex)
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
                int evaluationId = Convert.ToInt32(row.Cells["EvaluationId"].Value.ToString());
                int obtainedMarks = Convert.ToInt32(row.Cells["ObtainedMarks"].Value.ToString());
                string date = row.Cells["EvaluationDate"].Value.ToString();

                // Show a form with textboxes to edit the data
                EditEvaluationAgainstGroup editForm = new EditEvaluationAgainstGroup(groupId, evaluationId, obtainedMarks, date);
                DialogResult result = editForm.ShowDialog();

                // If the user clicks OK on the edit form, update the data in the database
                if (result == DialogResult.OK)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE GroupEvaluation SET GroupId=@GroupId, EvaluationId=@EvaluationId, ObtainedMarks=@ObtainedMarks, EvaluationDate=@EvaluationDate", con);
                    cmd.Parameters.AddWithValue("@GroupId", groupId);
                    cmd.Parameters.AddWithValue("@EvaluationId", evaluationId);
                    cmd.Parameters.AddWithValue("@ObtainedMarks", obtainedMarks);
                    cmd.Parameters.AddWithValue("@EvaluationDate", date);
                    cmd.ExecuteNonQuery();


                    // Update the data in the DataGridView control
                    row.Cells["GroupId"].Value = groupId; // Replace NAME_COLUMN_NAME with the name of the name column in your database table
                    row.Cells["EvaluationId"].Value = evaluationId;
                    row.Cells["ObtainedMarks"].Value = obtainedMarks;
                    row.Cells["EvaluationDate"].Value = date;
                    con.Close();
                }
            }

        }

        private void MarkEvaluationAgainstGroupGridView_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");

            // create a SqlCommand object
            SqlCommand cmd = new SqlCommand("Select GroupId,EvaluationId,ObtainedMarks,EvaluationDate From GroupEvaluation", con);

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
