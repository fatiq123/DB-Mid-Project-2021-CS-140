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
    public partial class EditManageAdvisor : Form
    {
        private int designation;
        private int salary;
        private string firstName;
        private string lastName;
        private string contact;
        private string email;
        private string date;
        private int gender;

        private string Designation;

        public EditManageAdvisor(int designation,int salary,string firstName,string lastName,string contact,string email,string date,int gender)
        {
            InitializeComponent();
            this.designation = designation;
            this.salary = salary;
            this.firstName = firstName;
            this.lastName= lastName;
            this.contact = contact;
            this.email = email;
            this.date = date;
            this.gender = gender;

        }

        private void editAdvisorCloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditManageAdvisor_Load(object sender, EventArgs e)
        {
            //comboBox1.Text = designation.ToString();
            textBox2.Text = salary.ToString();
            textBox3.Text = firstName.ToString();
            textBox4.Text = lastName.ToString();    
            textBox5.Text = contact.ToString();
            textBox6.Text = email.ToString();
            comboBox2.Text = gender.ToString();

            comboBox1.Items.Clear();    // so that all previous fields are clear. i.e Gender
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-K54JBCF;Initial Catalog=ProjectA;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("Select Value FROM Lookup Where Category='DESIGNATION'", con);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Designation = reader["Value"].ToString();
                comboBox1.Items.Add(Designation);
            }
            reader.Close();
            cmd.Dispose();


        }

        private void editAdvisorBtn_Click(object sender, EventArgs e)
        {
            // yahan pa agr wo button press ara ga to update ho gaya ga record
        }
    }
}
