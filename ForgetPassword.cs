using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace CsharpForm
{
   
    public partial class ForgetPassword : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = .\SQLEXPRESS; Initial Catalog = FMLProject; Integrated Security = True");
        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string getEmail=textBox1.Text;
            string getPhoneNo = textBox2.Text;
            string getPassword = textBox3.Text;
            string conPassword = textBox4.Text;
            string query1 = "Select name From UserAdmin WHERE name='" + getEmail + "'";
            /*SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.ExecuteNonQuery();*/
            SqlCommand sqlCommand = new SqlCommand(query1, conn);
            int data = (int)sqlCommand.ExecuteScalar();
            if (getEmail == data.ToString())
            {
                string query2 = "UPDATE UserAdmin SET name='" + getEmail + "',contact='" + getPhoneNo + "',FMLPassword='" + getPassword + "' WHERE name='" + getEmail + "'";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                cmd2.ExecuteNonQuery();
            }
            MessageBox.Show("Updated Successfully");
            conn.Close();
        }
    }
}
