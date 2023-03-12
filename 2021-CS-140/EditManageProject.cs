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
    public partial class EditManageProject : Form
    {
        private string description;
        private string title;
        public EditManageProject(string description, string title)
        {
            InitializeComponent();
            this.description = description;
            this.title = title;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void EditManageProject_Load(object sender, EventArgs e)
        {

            textBox1.Text = this.description;
            textBox2.Text = this.title;

        }

        private void editProjectBtn_Click(object sender, EventArgs e)
        {
            // edited code to write here
        }
    }
}
