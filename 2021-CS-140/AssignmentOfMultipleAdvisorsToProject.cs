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
    public partial class AssignmentOfMultipleAdvisorsToProject : Form
    {
        private int advisorId;
        private int projectId;
        private string advisorRole;
        private int projectvalue;
        public AssignmentOfMultipleAdvisorsToProject()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AssignmentOfMultipleAdvisorsToProject_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("Select Id From Advisor", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                advisorId = int.Parse(reader["Id"].ToString());
                comboBox1.Items.Add(advisorId);
            }
            reader.Close();
            cmd.Dispose();

            SqlCommand cmd1 = new SqlCommand("Select Id From Project", con);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                projectId = int.Parse(reader1["Id"].ToString());
                comboBox2.Items.Add(projectId);
            }
            reader1.Close();
            cmd1.Dispose();

            SqlCommand cmd2 = new SqlCommand("Select Value From Lookup Where Category='ADVISOR_ROLE'", con);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                advisorRole = reader2["Value"].ToString();
                comboBox3.Items.Add(advisorRole);
            }
            reader2.Close();
            cmd2.Dispose();
        }

        private void advisorAssignBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Insert into ProjectAdvisor values(@AdvisorId,@ProjectId,@AdvisorRole,@AssignmentDate)", con);
                    cmd.Parameters.AddWithValue("@AdvisorId", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@ProjectId", comboBox2.Text);

                    //SqlCommand cmd1 = new SqlCommand("Select Id FROM Lookup WHERE Value = @Id");

                    // we will get id from lookup then we will show it but if we do it simple by parse then it will generate error
                    SqlCommand cmd2 = new SqlCommand("Select Id from Lookup Where Value = @temp", con);    // temp2 ham na khud rakha ha
                    cmd2.Parameters.AddWithValue("@temp", comboBox3.Text);
                    object result = cmd2.ExecuteScalar();
                    if (result != null)
                    {
                        projectvalue = Convert.ToInt32(result);
                    }

                    // then it will convert projectvalue from ComboBox into int then we will pass it simply
                    cmd.Parameters.AddWithValue("@AdvisorRole", projectvalue);
                    cmd.Parameters.Add("@AssignmentDate", SqlDbType.Date).Value = dateTimePicker1.Value.Date;

                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Advisor Assigned Successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void showAdvisorGridViewBtn_Click(object sender, EventArgs e)
        {
            AssignmentOfMultipleAdvisorToProjectGridView a = new AssignmentOfMultipleAdvisorToProjectGridView();
            a.Show();
        }
    }
}
