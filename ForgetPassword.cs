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
       /* SqlConnection conn = new SqlConnection(@"Data Source=GWTN141-4;Initial Catalog=FMLProject;Integrated Security=True");*/
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
            string getEmail=Email.Text;
            string getPhoneNo = oPassword.Text;
            string getPassword = nPassword.Text;
            string conPassword = PhoneNo.Text;
            string query1 = "Select name From UserAdmin WHERE name='" + getEmail + "'";
            /*string query1 = "Select Email From UserAdmin WHERE Email='" + getEmail + "'";*/
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

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string getContact = textBox5.Text;
            string query = "Select name,contact From UserAdmin WHERE contact='" + getContact + "'";
           /* string query = "Select Email From UserAdmin WHERE Email='" + getEmail + "'";*/
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string data1 = dt.Rows[0]["name"].ToString();
                string data2 = dt.Rows[0]["contact"].ToString();
                Email.Text = data1;
                PhoneNo.Text = data2;
            }
            conn.Close();
        }
    }
}
