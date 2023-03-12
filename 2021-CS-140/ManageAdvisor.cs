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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _2021_CS_140
{
    public partial class ManageAdvisor : Form
    {
        int designation;
        public ManageAdvisor()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void addAdvisorBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && dateTimePicker1 != null && comboBox1 != null)
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");
                    con.Open();

                    // add values             
                    SqlCommand cmd = new SqlCommand("insert into Person values(@FirstName,@LastName,@Contact,@Email,@DateOfBirth,@Gender)", con);

                    int value;
                    if (Int32.TryParse(textBox3.Text, out value))
                    {
                        MessageBox.Show("Please enter FirstName as String.");
                        cmd.Parameters.AddWithValue("@FirstName", textBox3.Text);
                    }
                    int value1;
                    if (Int32.TryParse(textBox4.Text, out value1))
                    {
                        MessageBox.Show("Please enter LastName as String.");
                        cmd.Parameters.AddWithValue("@LastName", textBox4.Text);
                    }
                    int value2;
                    if (Int32.TryParse(textBox5.Text, out value2))
                    {
                        MessageBox.Show("Please enter Contact as String.");
                        cmd.Parameters.AddWithValue("@Contact", textBox5.Text);
                    }
                    int value3;
                    if (Int32.TryParse(textBox6.Text, out value3))
                    {
                        MessageBox.Show("Please enter Email as String.");
                        cmd.Parameters.AddWithValue("@Email", textBox6.Text);
                    }
                    
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



                    SqlCommand cmd2 = new SqlCommand("Select Id from Lookup Where Value = @temp2", con);    // temp2 ham na khud rakha ha
                    cmd2.Parameters.AddWithValue("@temp2", comboBox2.Text);
                    object result3 = cmd2.ExecuteScalar();
                    if (result3 != null)
                    {
                        designation = Convert.ToInt32(result3);
                    }
                    string query2 = "insert into Advisor (Id,Designation,Salary) Values((SELECT MAX(Id) FROM Person),@Designation,@Salary)";
                    SqlCommand cmd3 = new SqlCommand(query2, con);
                    cmd3.Parameters.AddWithValue("@Designation", designation);

                    int number;
                    if (int.TryParse(textBox2.Text, out number))
                    {
                        // input is a valid integer, do something with it
                        cmd3.Parameters.AddWithValue("@Salary", textBox2.Text);
                    }
                    else
                    {
                        MessageBox.Show("Please enter Salary in Integer.");
                    }

                    

                    cmd3.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Advisor Added Successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button1_Click(object sender, EventArgs e)
        {
            ManageAdvisorGridView m = new ManageAdvisorGridView();
            m.Show();
        }
    }
}
