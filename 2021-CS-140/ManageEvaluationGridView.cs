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
    public partial class ManageEvaluationGridView : Form
    {
        public ManageEvaluationGridView()
        {
            InitializeComponent();
        }

        private void closeBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void manageStudentForm_Paint(object sender, PaintEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");

            // create a SqlCommand object
            SqlCommand cmd = new SqlCommand("Select Name,TotalMarks,TotalWeightage From Evaluation", con);

            // create a SqlDataAdapter object
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // create a DataTable object
            DataTable dt = new DataTable();

            // fill the DataTable with data from the database
            da.Fill(dt);

            // set the DataGridView's DataSource property to the DataTable
            dataGridView1.DataSource = dt;
        }

        private void studentSearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = String.Format("Name Like '%" + projectSearchBox.Text + "%'");
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
                string name = row.Cells["Name"].Value.ToString(); // Replace ID_COLUMN_NAME with the name of the ID column in your database table
                // Replace NAME_COLUMN_NAME with the name of the name column in your database table
                int totalMarks = Convert.ToInt32(row.Cells["TotalMarks"].Value.ToString());
                int totalWeightage = Convert.ToInt32(row.Cells["TotalWeightage"].Value.ToString());


                // Show a form with textboxes to edit the data
                EditManageEvaluation editForm = new EditManageEvaluation(name, totalMarks, totalWeightage);
                DialogResult result = editForm.ShowDialog();

                // If the user clicks OK on the edit form, update the data in the database
                if (result == DialogResult.OK)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Evaluation SET Name=@Name,TotalMarks=@TotalMarks,TotalWeightage=@TotalWeightage Where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@TotalMarks", totalMarks);
                    cmd.Parameters.AddWithValue("@TotalWeightage", totalWeightage);
                    cmd.ExecuteNonQuery();



                    // Update the data in the DataGridView control
                    row.Cells["Name"].Value = name; // Replace NAME_COLUMN_NAME with the name of the name column in your database table
                    row.Cells["TotalMarks"].Value = totalMarks;
                    row.Cells["TotalWeightage"].Value = totalWeightage;
                    con.Close();
                }
            }

        }



    }
}
