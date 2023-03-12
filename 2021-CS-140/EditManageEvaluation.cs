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
    public partial class EditManageEvaluation : Form
    {
        private string name;
        private int totalMarks;
        private int totalWeightage;

        public EditManageEvaluation(string name, int totalMarks, int totalWeightage)
        {
            InitializeComponent();
            this.name = name;
            this.totalMarks = totalMarks;
            this.totalWeightage = totalWeightage;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditManageEvaluation_Load(object sender, EventArgs e)
        {
            textBox1.Text = this.name;
            textBox2.Text = Convert.ToInt32(this.totalMarks).ToString();
            textBox3.Text = Convert.ToInt32(this.totalWeightage).ToString();
        }

        private void editManageEvaluationBtn_Click(object sender, EventArgs e)
        {
            // edit code to be written here
        }
    }
}
