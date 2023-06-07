using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
namespace ALP_APP_DEV
{
    public partial class Form5 : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        MySqlDataReader sqlDataReader;
        DataTable dtAccount = new DataTable();
        string query = "";
        string tanggal = "";
        string password = "";
        string connection = "server=localhost;uid=root;pwd=root;database=db_concert";
        public Form5()
        {
            InitializeComponent();
            sqlConnection = new MySqlConnection(connection);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            txt_oldPass.Text = "Current Password";
            txt_oldPass.ForeColor = SystemColors.GrayText;
            txt_newPass.Text = "New Password";
            txt_newPass.ForeColor = SystemColors.GrayText;
            txt_verifyPass.Text = "Re-Enter New Password";
            txt_verifyPass.ForeColor = SystemColors.GrayText;
            label_msgPass.Visible = false;

            query = $"select date_format(birth_date_cust,'%d/%m/%Y'),password_cust from customer where id_cust='{Form1.customerid}';";
            sqlCommand = new MySqlCommand(query, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtAccount);
            string[]split= dtAccount.Rows[0][0].ToString().Split(' ');
            MessageBox.Show(dtAccount.Rows[0][0].ToString());
            tanggal=split[0];
            password = dtAccount.Rows[0][1].ToString();
        }

        private void txt_oldPass_Enter(object sender, EventArgs e)
        {
            if (txt_oldPass.Text == "Current Password")
            {
                txt_oldPass.Text = "";
                txt_oldPass.ForeColor = SystemColors.WindowText;
            }
        }

        private void txt_oldPass_Leave(object sender, EventArgs e)
        {
            if (txt_oldPass.Text == "")
            {
                txt_oldPass.Text = "Current Password";
                txt_oldPass.ForeColor = SystemColors.GrayText; ;
            }
        }

        private void txt_newPass_Enter(object sender, EventArgs e)
        {
            if (txt_newPass.Text == "New Password")
            {
                txt_newPass.Text = "";
                txt_newPass.ForeColor = SystemColors.WindowText;
            }
        }

        private void txt_newPass_Leave(object sender, EventArgs e)
        {
            if (txt_newPass.Text == "")
            {
                txt_newPass.Text = "New Password";
                txt_newPass.ForeColor = SystemColors.GrayText;
            }
        }

        private void txt_verifyPass_Leave(object sender, EventArgs e)
        {
            if (txt_verifyPass.Text == "")
            {
                txt_verifyPass.Text = "Re-Enter New Password";
                txt_verifyPass.ForeColor = SystemColors.GrayText;
            }
        }

        private void txt_verifyPass_Enter(object sender, EventArgs e)
        {
            if (txt_verifyPass.Text == "Re-Enter New Password")
            {
                txt_verifyPass.Text = "";
                txt_verifyPass.ForeColor = SystemColors.WindowText;
            }
        }
        private string MD5Generator(string input)
        {

            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input));
            byte[] result = md5.Hash;

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                stringBuilder.Append(result[i].ToString("x2"));
            }
            input = stringBuilder.ToString();
            return input;
        }
        private void btn_editPassword_Click(object sender, EventArgs e)
        {    
            //check birthday
            string birthdate = dateTimePicker.Value.ToString("dd/MM/yyyy");
            //MessageBox.Show($"tanggal={tanggal}\nbirthdate={birthdate}");
            if (birthdate == tanggal && MD5Generator(txt_oldPass.Text) == password && txt_newPass.Text == txt_verifyPass.Text && txt_newPass.Text != txt_oldPass.Text)
            {
                dtAccount = new DataTable();
                query = $"update customer set password_cust='{MD5Generator(txt_verifyPass.Text)}' where id_cust='{Form1.customerid}';";
                sqlConnection.Open();
                sqlCommand = new MySqlCommand(query, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                sqlConnection.Close();

                MessageBox.Show("Password is changed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form3 form3 = new Form3();
                form3.ShowDialog();
            }
            else
            {
                label_msgPass.Visible = true;
            }
        }

        private void label_back_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
        }
    }
}
