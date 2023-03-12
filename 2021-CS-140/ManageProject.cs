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
    public partial class ManageProject : Form
    {
        public ManageProject()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addProjectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Project values(@Description,@Title)", con);

                    
                    int value;
                    if (Int32.TryParse(textBox1.Text, out value))
                    {
                        MessageBox.Show("Please enter a non-integer Description.");
                        cmd.Parameters.AddWithValue("@Description", textBox1.Text);
                        //e.Cancel = true;
                    }

                    int value1;
                    if (Int32.TryParse(textBox1.Text, out value1))
                    {
                        MessageBox.Show("Please enter a non-integer Title.");
                        cmd.Parameters.AddWithValue("@Title", textBox2.Text);
                        //e.Cancel = true;
                    }


                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Project Added Successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void showProjectBtn_Click(object sender, EventArgs e)
        {
            ManageProjectGridView m = new ManageProjectGridView();
            m.Show();
        }
    }
}

