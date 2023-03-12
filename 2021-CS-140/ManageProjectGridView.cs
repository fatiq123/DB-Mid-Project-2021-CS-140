using iText.Layout.Element;
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
    public partial class ManageProjectGridView : Form
    {
        // to make it global
        private DataTable stdDataTable = new DataTable();

        public ManageProjectGridView()
        {
            InitializeComponent();
        }

        public ManageProjectGridView(DataTable dataTable)
        {
            InitializeComponent();

           // dataGridView1.DataSource = dataTable;
        }

        private void closeBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void manageStudentForm_Paint(object sender, PaintEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");

            // create a SqlCommand object
            SqlCommand cmd = new SqlCommand("Select Description,Title From Project", con);

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
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = String.Format("Title Like '%" + projectSearchBox.Text + "%'");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");

            //if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            //    string description = row.Cells["Description"].Value.ToString(); // Replace ID_COLUMN_NAME with the name of the ID column in your database table
            //    // Replace NAME_COLUMN_NAME with the name of the name column in your database table
            //    string title = row.Cells["Title"].Value.ToString();



            //    // Show a form with textboxes to edit the data
            //    EditManageProject editForm = new EditManageProject(description, title );
            //    DialogResult result = editForm.ShowDialog();

            //    // If the user clicks OK on the edit form, update the data in the database
            //    if (result == DialogResult.OK)
            //    {
            //        con.Open();
            //        SqlCommand cmd = new SqlCommand("UPDATE Project SET Description=@Description,Title=@Title WHERE Id=@Id", con);
            //        cmd.Parameters.AddWithValue("@Description", description);
            //        cmd.Parameters.AddWithValue("@Title", title);
            //        cmd.ExecuteNonQuery();



            //        // Update the data in the DataGridView control
            //        row.Cells["Description"].Value = description; // Replace NAME_COLUMN_NAME with the name of the name column in your database table
            //        row.Cells["Title"].Value = title;                                                   
            //        con.Close();

            //    }

            //}




            // get the selected row
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            // get the data for the selected row
            string title = row.Cells["Title"].Value.ToString();
            string description = row.Cells["Description"].Value.ToString();

            // create an instance of the edit form
            EditManageProject editForm = new EditManageProject(title, description);

            // show the edit form
            editForm.ShowDialog();

            // handle the edit button click
            if (editForm.DialogResult == DialogResult.OK)
            {
                // get the edited data from the edit form


                // update the corresponding record in the database
                string connectionString = "Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True";
                string sqlQuery = "UPDATE Project SET Title=@Title, Description=@Description WHERE ID=@ID";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Description", description);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                // update the data source and refresh the DataGridView control
                List<EditManageProject> tableData = GetTableData(); // get updated data source
                dataGridView1.DataSource = tableData;
                dataGridView1.Refresh();
            }
            MessageBox.Show("Project Updated Successfuly");

        }



        private List<EditManageProject> GetTableData()
        {
            // get the data from the database and return as a list of MyTable objects
            List<EditManageProject> tableData = new List<EditManageProject>();
            string connectionString = "Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True";
            string sqlQuery = "SELECT * FROM Project";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = reader["Title"].ToString();
                            string description = reader["Description"].ToString();
                            EditManageProject row = new EditManageProject(title, description);
                            tableData.Add(row);
                        }
                    }
                }
            }
            return tableData;
        }
    }
}
