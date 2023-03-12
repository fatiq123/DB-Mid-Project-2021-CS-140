using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2021_CS_140
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void manageStudentBtn_Click(object sender, EventArgs e)
        {
            ManageStudent s = new ManageStudent();
            s.Show();
        }

        private void manageAdvisorsBtn_Click(object sender, EventArgs e)
        {
            ManageAdvisor a  = new ManageAdvisor();
            a.Show();
        }

        private void manageProjectsBtn_Click(object sender, EventArgs e)
        {
            ManageProject p = new ManageProject();
            p.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormationOfStudentgroup f = new FormationOfStudentgroup();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AssignmentOfProjectToGroupStudent a = new AssignmentOfProjectToGroupStudent();
            a.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AssignmentOfMultipleAdvisorsToProject a = new AssignmentOfMultipleAdvisorsToProject();
            a.Show();
        }

        private void manageEvaluationBtn_Click(object sender, EventArgs e)
        {
            ManageEvaluations m = new ManageEvaluations();
            m.Show();
        }

        private void manageGroupEvaluationBtn_Click(object sender, EventArgs e)
        {
            MarkEvaluationAgainstGroup m = new MarkEvaluationAgainstGroup();
            m.Show();
        }
    }
}
