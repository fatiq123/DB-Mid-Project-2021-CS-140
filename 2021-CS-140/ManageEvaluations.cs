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
using System.Windows.Forms.VisualStyles;

namespace _2021_CS_140
{
    public partial class ManageEvaluations : Form
    {

        public ManageEvaluations()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void advisorAssignBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Insert into Evaluation values(@Name,@TotalMarks,@TotalWeightage Where Id=@Id)", con);

                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    if (string.IsNullOrEmpty(textBox1.Text))
                    {
                        MessageBox.Show("Please enter a valid string.");
                        textBox1.Focus();
                        textBox1.SelectAll();
                    }


                    int number;
                    if (int.TryParse(textBox2.Text, out number))
                    {
                        // input is a valid integer, do something with it
                        cmd.Parameters.AddWithValue("@TotalMarks", textBox2.Text);
                    }
                    else
                    {
                        MessageBox.Show("Please enter TotalMarks in integer.");
                        textBox2.Focus();
                        textBox2.SelectAll();
                    }
                    int number1;
                    if (int.TryParse(textBox3.Text, out number1))
                    {
                        // input is a valid integer, do something with it
                        cmd.Parameters.AddWithValue("@TotalWeightage", textBox3.Text);
                    }
                    else
                    {
                        MessageBox.Show("Please enter TotalWeightage in integer.");
                        textBox3.Focus();
                        textBox3.SelectAll();
                    }


                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Student Evaluated Successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ManageEvaluationGridView ed = new ManageEvaluationGridView();
            ed.Show();
        }
    }
}
