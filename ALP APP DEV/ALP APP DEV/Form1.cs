using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ALP_APP_DEV
{
    public partial class Form1 : Form
    {
        string query = "";
        string connection = "server=localhost;uid=root;pwd=root;database=db_concert";
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        DataTable dtCustomer = new DataTable();
        public static string customerid="";
        public Form1()
        {
            InitializeComponent();
            sqlConnection= new MySqlConnection(connection);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_email.Text = "john@mail.com";
            txt_email.ForeColor = SystemColors.GrayText;
            txt_password.Text = "123456";
            txt_password.ForeColor = SystemColors.GrayText;

            this.ActiveControl = null;
            pictureBox1.Focus(); //shit isnt working the heck?????

            dtCustomer = new DataTable();
            query = "select email_cust,password_cust from customer;";
            sqlCommand = new MySqlCommand(query, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtCustomer);
        }

        /*biar di txt_username ada tulisannya buat panduan
        kalo di click tulisannya hilang*/
        private void txt_username_Enter(object sender, EventArgs e)
        {
            if (txt_email.Text == "john@mail.com")
            {
                txt_email.Text = "";
                txt_email.ForeColor = SystemColors.WindowText;
            }
        }
        private void txt_password_Enter(object sender, EventArgs e)
        {
            if (txt_password.Text == "123456")
            {
                txt_password.Text = "";
                txt_password.ForeColor = SystemColors.WindowText;
            }
        }

        //literally kebalikkannya yg atas
        private void txt_username_Leave(object sender, EventArgs e)
        {
            if (txt_email.Text == "")
            {
                txt_email.Text = "john@mail.com";
                txt_email.ForeColor = SystemColors.GrayText;
            }
        }
        private void txt_password_Leave(object sender, EventArgs e)
        {
            if (txt_password.Text == "")
            {
                txt_password.Text = "123456";
                txt_password.ForeColor = SystemColors.GrayText;
            }
        }

        private void label_signUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
           
        }

        private void btn_signIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_email.Text) || string.IsNullOrEmpty(txt_password.Text))
                label_info.Visible = true;
            else
            {
                //CONVERT MD5
                string input = txt_password.Text;

                MD5 md5 = new MD5CryptoServiceProvider();
                md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input));
                byte[] result = md5.Hash;

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    stringBuilder.Append(result[i].ToString("x2"));
                }
                input = stringBuilder.ToString();

                //CHECKING
                bool found = false;

                foreach (DataRow dt in dtCustomer.Rows)
                {
                    if (dt["email_cust"].ToString() == txt_email.Text && dt["password_cust"].ToString() == input)
                    {
                        found = true;
                        break;
                    }

                }
                if (found == true)
                {
                    /*Buat daptein id customer biar bisa ke pake di form lainnya*/
                    dtCustomer = new DataTable();
                    query= $"SELECT id_cust from customer where email_cust='{txt_email.Text}';";
                    sqlCommand = new MySqlCommand(query, sqlConnection);
                    sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dtCustomer);
                    customerid= dtCustomer.Rows[0][0].ToString();

                    Form3 form3 = new Form3();
                    this.Hide();
                    form3.ShowDialog();
                }
                else
                    label_info.Visible = true;
            }

           
        }
    }
}
