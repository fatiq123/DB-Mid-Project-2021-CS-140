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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _2021_CS_140
{
    public partial class MarkEvaluationAgainstGroup : Form
    {
        private int groupId;
        private int evaluationId;
        public MarkEvaluationAgainstGroup()
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

            SqlCommand cmd = new SqlCommand("Select Id From [Group]", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                groupId = int.Parse(reader["Id"].ToString());
                comboBox1.Items.Add(groupId);
            }
            reader.Close();
            cmd.Dispose();

            SqlCommand cmd1 = new SqlCommand("Select Id From Evaluation", con);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                evaluationId = int.Parse(reader1["Id"].ToString());
                comboBox2.Items.Add(evaluationId);
            }
            reader1.Close();
            cmd1.Dispose();

        }

        private void advisorAssignBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "" && comboBox2.Text != "" && textBox1.Text != "" && dateTimePicker1 != null)
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Insert into GroupEvaluation values(@GroupId,@EvaluationId,@ObtainedMarks,@EvaluationDate)", con);
                    
                    cmd.Parameters.AddWithValue("@GroupId", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@EvaluationId", comboBox2.Text);

                    int number;
                    if (int.TryParse(textBox1.Text, out number))
                    {
                        // input is a valid integer, do something with it
                        cmd.Parameters.AddWithValue("@ObtainedMarks", textBox1.Text);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid integer in ObtainedMarks Field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    cmd.Parameters.Add("@EvaluationDate", SqlDbType.Date).Value = dateTimePicker1.Value.Date;


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

        private void showMarkEvaluationBtn_Click(object sender, EventArgs e)
        {
            MarkEvaluationAgainstGroupGridView m = new MarkEvaluationAgainstGroupGridView();
            m.Show();
        }
    }
}
