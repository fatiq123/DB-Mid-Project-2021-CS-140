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
    public partial class ManageStudentGridView : Form
    {
        // to make it global
        private DataTable stdDataTable = new DataTable();

        public ManageStudentGridView()
        {
            InitializeComponent();
        }

        public ManageStudentGridView(DataTable dataTable)
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
            SqlCommand cmd = new SqlCommand("Select p.Id,p.FirstName,p.LastName,p.Contact,p.Email,p.DateOfBirth,p.Gender,s.RegistrationNo From Person p join Student s on p.Id = s.Id", con);

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
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = String.Format("Email Like '%" + studentSearchBox.Text + "%'");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void studentUpdateBtn_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");
            for (int item = 0; item <= dataGridView1.Rows.Count - 1; item++)
            {
                int id1 = 1,id2=2;
                string query1 = "UPDATE Person SET FirstName = @FirstName,LastName = @LastName,Email = @Email, Contact = @Contact, DateOfBirth = @DateOfBirth, Gender = @Gender WHERE Id = @Id";
                string query2 = "UPDATE Student SET RegistrationNo = @RegistrationNo WHERE Id = @Id";
              
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command1 = new SqlCommand(query1, connection, transaction);
                SqlCommand command2 = new SqlCommand(query2, connection, transaction);

                command2.Parameters.AddWithValue("@RegistrationNo", dataGridView1.Rows[item].Cells[1].Value);
                command2.Parameters.AddWithValue("@Id", id2);
                command2.ExecuteNonQuery();

                command1.Parameters.AddWithValue("@FirstName", dataGridView1.Rows[item].Cells[2].Value);
                command1.Parameters.AddWithValue("@LastName", dataGridView1.Rows[item].Cells[3].Value);
                command1.Parameters.AddWithValue("@Contact", dataGridView1.Rows[item].Cells[4].Value);
                command1.Parameters.AddWithValue("@Email", dataGridView1.Rows[item].Cells[5].Value);
                command1.Parameters.AddWithValue("@DateOfBirth", dataGridView1.Rows[item].Cells[6].Value);
                command1.Parameters.AddWithValue("@Gender", dataGridView1.Rows[item].Cells[7].Value);
                command1.Parameters.AddWithValue("@Id", id1);
                command1.ExecuteNonQuery();


                connection.Close();

            }

        }

        private void studentDeleteBtn_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");

            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string registrartionNo = row.Cells["RegistrationNo"].Value.ToString(); // Replace ID_COLUMN_NAME with the name of the ID column in your database table
                // Replace NAME_COLUMN_NAME with the name of the name column in your database table
                string firstName = row.Cells["FirstName"].Value.ToString();
                string lastName = row.Cells["LastName"].Value.ToString();
                string contact = row.Cells["Contact"].Value.ToString();
                string email = row.Cells["Email"].Value.ToString();
                string date = row.Cells["DateOfBirth"].Value.ToString();
                int gender = Convert.ToInt32(row.Cells["Gender"].Value.ToString());
                // Similarly, get the values of all other columns you want to edit


                // Show a form with textboxes to edit the data
                EditManageStudent editForm = new EditManageStudent(registrartionNo, firstName, lastName, contact, email, date, gender);
                DialogResult result = editForm.ShowDialog();

                // If the user clicks OK on the edit form, update the data in the database
                if (result == DialogResult.OK)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Student SET RegistrationNo=@RegistrationNo WHERE Id=@Id", con);
                    cmd.Parameters.AddWithValue("@RegistrationNo", registrartionNo);
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
                    row.Cells["RegistrationNo"].Value = registrartionNo; // Replace NAME_COLUMN_NAME with the name of the name column in your database table
                             // Similarly, update the values of all other columns you edited

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
