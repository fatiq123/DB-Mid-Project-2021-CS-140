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
    public partial class EditFormationOfStudentGroup : Form
    {
        private int groupId, studentId;
        private int status;
        private string date;
        public EditFormationOfStudentGroup(int groupId,int studentId,int status,string date)
        {
            InitializeComponent();
            this.groupId = groupId;
            this.studentId = studentId;
            this.status = status;
            this.date = date;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void inactiveStatusBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");
            con.Open();

            //SqlCommand cmd = new SqlCommand("UPDATE Value SET Status = 4 " +
            //   "FROM GroupStudent " +
            //   "INNER JOIN Lookup ON GroupStudent.GroupId = Lookup.Id " +
            //   "WHERE Lookup.Category = 'STATUS'");

            //cmd.Parameters.AddWithValue("GroupId", groupId);
            //cmd.ExecuteNonQuery();
            //con.Close();

            string connectionString = "Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True";
            string query = "UPDATE GroupStudent SET Status = 4 WHERE GroupId IN (SELECT Id FROM Lookup WHERE Category = 'STATUS')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Status Updated");
        }


        private void EditFormationOfStudentGroup_Load(object sender, EventArgs e)
        {
            textBox1.Text = this.groupId.ToString();
            textBox2.Text = this.studentId.ToString();
            textBox3.Text = this.status.ToString();
            dateTimePicker1.Text = this.date.ToString();
        }
    }
}
