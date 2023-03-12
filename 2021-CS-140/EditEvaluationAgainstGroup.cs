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
    public partial class EditEvaluationAgainstGroup : Form
    {
        private int groupId;
        private int evaluationId;
        private int obtainedMarks;
        private string evaluationDate;

        public EditEvaluationAgainstGroup(int groupId, int evaluationId, int obtainedmarks, string date)
        {
            InitializeComponent();
            this.groupId = groupId;
            this.evaluationId = evaluationId;
            this.obtainedMarks = obtainedmarks;
            this.evaluationDate = date;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditEvaluationAgainstGroup_Load(object sender, EventArgs e)
        {
            textBox1.Text = this.groupId.ToString();
            textBox2.Text = this.evaluationId.ToString();
            textBox3.Text = this.obtainedMarks.ToString();
            dateTimePicker1.Text = this.evaluationDate;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
        }
    }
}
