using iText.Layout;
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
    public partial class ManageStudent : Form
    {
        public ManageStudent()
        {
            InitializeComponent();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public DataTable GetDataFromSQL()
        {
            // Establish a connection to your SQL database
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");

            // Create a SQL command to retrieve data from your database
            SqlCommand command = new SqlCommand("SELECT DateOfBirth FROM Person", connection);

            // Execute the command and retrieve the data
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            // Create a DataTable object to store the data
            DataTable dataTable = new DataTable();

            // Load the data into the DataTable object
            dataTable.Load(reader);

            // Close the connection and disposo0e of the SqlDataReader object
            reader.Close();
            connection.Close();

            // Return the DataTable object
            return dataTable;
        }


        private void addstudentbtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && dateTimePicker1 != null && comboBox1 != null)
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");
                    con.Open();

                    // add values             
                    SqlCommand cmd = new SqlCommand("insert into Person values(@FirstName,@LastName,@Contact,@Email,@DateOfBirth,@Gender)", con);
                    cmd.Parameters.AddWithValue("@FirstName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@LastName", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Contact", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox5.Text);
                    cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = dateTimePicker1.Value.Date;


                    //string connectionString = "Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True";

                    if (comboBox1.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please select a option from drop down menu");
                        comboBox1.Focus();
                    }
                    int gender;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        gender = 1;
                    }
                    else
                    {
                        gender = 2;
                    }

                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.ExecuteNonQuery();

                    string insertStudentQuery = "insert into student (Id,RegistrationNo) Values((SELECT MAX(Id) FROM Person), @regNo)";
                    SqlCommand insertStudentCommand = new SqlCommand(insertStudentQuery, con);
                    insertStudentCommand.Parameters.AddWithValue("@regNo", textBox1.Text);
                    insertStudentCommand.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Student Added Successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Required Fields should not Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void showStudentBtn_Click(object sender, EventArgs e)
        {
            ManageStudentGridView m = new ManageStudentGridView();
            m.Show();

        }

    }
}

