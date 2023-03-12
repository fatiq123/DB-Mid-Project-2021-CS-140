using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2021_CS_140
{
    public partial class ManageAdvisorGridView : Form
    {
        public ManageAdvisorGridView()
        {
            InitializeComponent();
        }

        private void advisorCloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void manageStudentForm_Paint(object sender, PaintEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");

            // create a SqlCommand object
            SqlCommand cmd = new SqlCommand("Select a.Designation,a.Salary,p.FirstName,p.LastName,p.Contact,p.Email,p.DateOfBirth,p.Gender FROM Advisor a join Person p on a.Id = p.Id", con);

            // create a SqlDataAdapter object
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // create a DataTable object
            DataTable dt = new DataTable();

            // fill the DataTable with data from the database
            da.Fill(dt);

            // set the DataGridView's DataSource property to the DataTable
            dataGridView2.DataSource = dt;
        }

        private void advisorSearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (dataGridView2.DataSource as DataTable).DefaultView.RowFilter = String.Format("Contact Like '%" + advisorSearchBox.Text + "%'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");

            if (e.ColumnIndex == dataGridView2.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                int designation = Convert.ToInt32(row.Cells["Designation"].Value.ToString()); // Replace ID_COLUMN_NAME with the name of the ID column in your database table
                int salary = Convert.ToInt32(row.Cells["Salary"].Value.ToString()); // Replace NAME_COLUMN_NAME with the name of the name column in your database table
                string firstName = row.Cells["FirstName"].Value.ToString();
                string lastName = row.Cells["LastName"].Value.ToString();
                string contact = row.Cells["Contact"].Value.ToString();
                string email = row.Cells["Email"].Value.ToString();
                string date = row.Cells["DateOfBirth"].Value.ToString();
                int gender = Convert.ToInt32(row.Cells["Gender"].Value.ToString());
                // Similarly, get the values of all other columns you want to edit

                
                // Show a form with textboxes to edit the data
                EditManageAdvisor editForm = new EditManageAdvisor(designation, salary,firstName,lastName,contact,email,date,gender);
                DialogResult result = editForm.ShowDialog();

                // If the user clicks OK on the edit form, update the data in the database
                if (result == DialogResult.OK)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Advisor SET Designation=@Designation,Salary=@Salary WHERE Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Designation", designation);
                    cmd.Parameters.AddWithValue("@Salary", salary);
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand("UPDATE Person SET FirstName=@FirstName,LastName=@LastName,Contact=@Contact,Email=@Email,DateOfBirth=@DateOfBirth,Gender=@Gender WHERE Id=@Id", con);
                    cmd1.Parameters.AddWithValue("@FirstName", firstName);
                    cmd1.Parameters.AddWithValue("@LastName", lastName);
                    cmd1.Parameters.AddWithValue("@Contact", contact);
                    cmd1.Parameters.AddWithValue("@Email", email);
                    cmd1.Parameters.AddWithValue("@DateOfBirth", date);
                    cmd1.Parameters.AddWithValue("@Gender", gender);
                    cmd1.ExecuteNonQuery();




                    // Update the data in the DataGridView control
                    row.Cells["Designation"].Value = designation; // Replace NAME_COLUMN_NAME with the name of the name column in your database table
                    row.Cells["Salary"].Value = salary;          // Similarly, update the values of all other columns you edited
                    
                    row.Cells["FirstName"].Value = firstName;
                    row.Cells["LastName"].Value = lastName;
                    row.Cells["Contact"].Value = contact;
                    row.Cells["Email"].Value = email;
                    row.Cells["DateOfBirth"].Value = date;
                    row.Cells["Gender"].Value = gender;
                    con.Close();
                }
            }
        }
    }
}


//private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
//{
//    if (e.ColumnIndex == dataGridView1.Columns["editButton"].Index && e.RowIndex >= 0)
//    {
//        DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
//        int id = Convert.ToInt32(row.Cells["ID_COLUMN_NAME"].Value); // Replace ID_COLUMN_NAME with the name of the ID column in your database table
//        string name = row.Cells["NAME_COLUMN_NAME"].Value.ToString(); // Replace NAME_COLUMN_NAME with the name of the name column in your database table
//        // Similarly, get the values of all other columns you want to edit

//        // Show a form with textboxes to edit the data
//        EditForm editForm = new EditForm(id, name, /*pass other values here*/);
//        DialogResult result = editForm.ShowDialog();

//        // If the user clicks OK on the edit form, update the data in the database
//        if (result == DialogResult.OK)
//        {
//            con.Open();
//            cmd = new SqlCommand("UPDATE YOUR_TABLE_NAME SET NAME_COLUMN_NAME=@name /*set other columns here*/ WHERE ID_COLUMN_NAME=@id", con);
//            cmd.Parameters.AddWithValue("@name", editForm.NewName);
//            cmd.Parameters.AddWithValue("@id", id);
//            cmd.ExecuteNonQuery();
//            con.Close();

//            // Update the data in the DataGridView control
//            row.Cells["NAME_COLUMN_NAME"].Value = editForm.NewName; // Replace NAME_COLUMN_NAME with the name of the name column in your database table
//            // Similarly, update the values of all other columns you edited
//        }
//    }
//}
