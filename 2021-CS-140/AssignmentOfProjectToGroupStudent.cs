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
    public partial class AssignmentOfProjectToGroupStudent : Form
    {
        private int projectId;
        private int groupId;
        public AssignmentOfProjectToGroupStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AssignmentOfProjectToGroupStudent_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Id From Project",con);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                projectId = int.Parse(reader["Id"].ToString());
                comboBox1.Items.Add(projectId);
            }
            reader.Close();
            cmd.Dispose();

            SqlCommand cmd1 = new SqlCommand("Select Id From [Group]",con);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                groupId = int.Parse(reader1["Id"].ToString());
                comboBox2.Items.Add(groupId);
            }
            reader1.Close();
            cmd1.Dispose();

        }
        private void assignProjectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "" && comboBox2.Text != "" && dateTimePicker1 != null)
                {

                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into GroupProject values(@ProjectId,@GroupId,@AssignmentDate)", con);
                    cmd.Parameters.AddWithValue("@ProjectId", int.Parse(comboBox1.Text));
                    cmd.Parameters.AddWithValue("@GroupId", int.Parse(comboBox2.Text));
                    cmd.Parameters.Add("@AssignmentDate", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Project Added Successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("All Project Fields should not Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showAssignedProjectBtn_Click(object sender, EventArgs e)
        {
            AssignmentOfProjectToGroupGridView a = new AssignmentOfProjectToGroupGridView();
            a.Show();

        }
    }
}
