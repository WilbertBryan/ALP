using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALP_APP_DEV
{
    public partial class Form2 : Form
    {
        string query = "";
        string connection = "server=localhost;uid=root;pwd=root;database=db_concert";
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        MySqlDataReader sqlDataReader;
        DataTable dtCustomer = new DataTable();
        string customerid = "C";
        public Form2()
        {
            InitializeComponent();
            sqlConnection = new MySqlConnection(connection);
        }
        private static bool isNumber(string str)
        {
            bool isNumber = true;

            foreach (char s in str)
            {
                if (char.IsLetter(s) || char.IsSymbol(s))
                    isNumber = false;
            }
            if (string.IsNullOrEmpty(str))
                isNumber = false;

            return isNumber;
        }
        private static bool isLetter(string str)
        {
            bool isLetter = true;

            foreach (char s in str)
            {
                if (char.IsNumber(s) || char.IsSymbol(s))
                    isLetter = false;
            }
            if (string.IsNullOrEmpty(str))
                isLetter = false;

            return isLetter;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            txt_nama.Text = "Name";
            txt_nama.ForeColor = SystemColors.GrayText;
            txt_noTelp.Text = "Phone Number";
            txt_noTelp.ForeColor = SystemColors.GrayText;
            txt_email.Text = "Email";
            txt_email.ForeColor = SystemColors.GrayText;
            txt_password.Text = "0123456789";
            txt_password.ForeColor = SystemColors.GrayText;
            txt_nik.Text = "NIK";
            txt_nik.ForeColor = SystemColors.GrayText;

            query = "select max(substr(id_cust,2,5)) from customer;";
            sqlCommand= new MySqlCommand(query,sqlConnection);
            sqlDataAdapter= new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtCustomer);
            int id = Convert.ToInt32(dtCustomer.Rows[0][0])  +1;
            string ids=id.ToString();
            for(int i=5-ids.Length;i>=1;i--)
            {
                customerid += "0";
            }
            customerid += ids;
        }

        private void txt_nama_Enter(object sender, EventArgs e)
        {
            if (txt_nama.Text == "Name")
            {
                txt_nama.Text = "";
                txt_nama.ForeColor = SystemColors.WindowText;
            }
        }

        private void txt_nama_Leave(object sender, EventArgs e)
        {
            if (txt_nama.Text == "")
            {
                txt_nama.Text = "Name";
                txt_nama.ForeColor = SystemColors.GrayText;
            }
        }

        private void txt_noTelp_Enter(object sender, EventArgs e)
        {
            if (txt_noTelp.Text == "Phone Number")
            {
                txt_noTelp.Text = "";
                txt_noTelp.ForeColor = SystemColors.WindowText;
            }
        }

        private void txt_noTelp_Leave(object sender, EventArgs e)
        {
            if (txt_noTelp.Text == "")
            {
                txt_noTelp.Text = "Phone Number";
                txt_noTelp.ForeColor = SystemColors.GrayText;
            }
        }

        private void txt_email_Enter(object sender, EventArgs e)
        {
            if (txt_email.Text == "Email")
            {
                txt_email.Text = "";
                txt_email.ForeColor = SystemColors.WindowText;
            }
        }

        private void txt_email_Leave(object sender, EventArgs e)
        {
            if (txt_email.Text == "")
            {
                txt_email.Text = "Email";
                txt_email.ForeColor = SystemColors.GrayText;
            }
        }

        private void txt_password_Enter(object sender, EventArgs e)
        {
            if (txt_password.Text == "0123456789")
            {
                txt_password.Text = "";
                txt_password.ForeColor = SystemColors.WindowText;
            }
        }

        private void txt_password_Leave(object sender, EventArgs e)
        {
            if (txt_password.Text == "")
            {
                txt_password.Text = "0123456789";
                txt_password.ForeColor = SystemColors.GrayText;
            }
        }

        private void txt_nik_Enter(object sender, EventArgs e)
        {
            if (txt_nik.Text == "NIK")
            {
                txt_nik.Text = "";
                txt_nik.ForeColor = SystemColors.WindowText;
            }
        }

        private void txt_nik_Leave(object sender, EventArgs e)
        {
            if (txt_nik.Text == "")
            {
                txt_nik.Text = "NIK";
                txt_nik.ForeColor = SystemColors.GrayText;
            }
        }
        private void btn_signUp_Click(object sender, EventArgs e)
        {
            if (isLetter(txt_nama.Text) && isNumber(txt_noTelp.Text) && !string.IsNullOrEmpty(txt_email.Text) && !string.IsNullOrEmpty(txt_password.Text) && isNumber(txt_nik.Text))
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

                string birthdate = dateTimePicker_tglLahir.Value.ToString("yyyy-MM-dd");

                query = $"INSERT INTO customer VALUES('{customerid}','{txt_nik.Text}','{txt_nama.Text}','{txt_noTelp.Text}','{birthdate}','{txt_email.Text}','{input}')";

                try
                {
                    sqlConnection.Open();
                    sqlCommand = new MySqlCommand(query, sqlConnection);
                    sqlDataReader = sqlCommand.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                    MessageBox.Show("Account successfuly created.", "Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                }
            }
            else
                MessageBox.Show("Please fill all the required field.", "Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void label_back_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
        }
    }
}
