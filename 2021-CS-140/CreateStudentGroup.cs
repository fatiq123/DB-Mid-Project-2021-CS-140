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
    public partial class CreateStudentGroup : Form
    {
        public CreateStudentGroup()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker1 != null)
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand("Insert into [Group] values(@Created_On)", con);
                    SqlCommand cmd1 = new SqlCommand("insert into Person values(@FirstName,@LastName,@Contact,@Email,@DateOfBirth,@Gender)", con);
                    con.Open();
                    cmd.Parameters.Add("@Created_On", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Group Added Successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Date Field should not Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
