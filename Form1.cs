using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Data;

namespace CsharpForm
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = .\SQLEXPRESS; Initial Catalog = FMLProject; Integrated Security = True");
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeft,
                int nTop,
                int nRight,
                int nBottom,
                int nWidthEllipse,
                int nHeightEllipse
            );
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 40, 40));
            logIn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, logIn.Width, logIn.Height, 30, 30));
            email.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, email.Width, email.Height, 10, 10));
            password.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, password.Width, password.Height, 10, 10));
            signUp.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, signUp.Width, signUp.Height, 30, 30));
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string _getemail = email.Text;
            string _pass = password.Text;
            if (_getemail == "mishrarohan090@gmail.com" && _pass == "admin")
            {
                MessageBox.Show("Login Sucessful!!!");
            }
            else
            {
                MessageBox.Show("Login Failed!!");
            }*/
            /*this.Controls.Clear();
            this.InitializeComponent();*/
            try
            {
                conn.Open();
                string getMail = email.Text;
                string getPassword = password.Text;
                string query = "SELECT name,FMLPassword from UserAdmin where name='" + getMail + "'AND FMLPassword='" + getPassword + "'";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sda.Fill(dt);//something
                if (dt.Rows.Count > 0)
                {
                    string data1 = dt.Rows[0]["name"].ToString();
                    string data2 = dt.Rows[0]["FMLPassword"].ToString();
                    if (getMail == data1 && getPassword == data2)
                    {
                        signUpForm nextForm;
                        this.Hide();
                        nextForm = new signUpForm();
                        nextForm.ShowDialog();
                        this.Show();
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Incorrect Password or Email");
            }
        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void signUp_Click(object sender, EventArgs e)
        {
            this.Show();
            signUpForm pageLoad = new signUpForm();
            pageLoad.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(password.PasswordChar =='*')
            {
                string getPassword = password.Text;
                password.Text = getPassword;
                password.PasswordChar = '\0';
            }
            else
            {
                string getPassword = password.Text;
                password.Text = getPassword;
                password.PasswordChar = '*';
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Show();
            ForgetPassword pageLoad = new ForgetPassword();
            pageLoad.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ForgetPassword nextForm;
            this.Hide();
            nextForm = new ForgetPassword();
            nextForm.ShowDialog();
            this.Show();
        }
    }
}