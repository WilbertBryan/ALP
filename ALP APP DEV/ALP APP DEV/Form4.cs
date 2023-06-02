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
namespace ALP_APP_DEV
{
    public partial class Form4 : Form
    {
        string query = "";
        string connection = "server=localhost;uid=root;pwd=root;database=db_concert";
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        DataTable dtCustomer = new DataTable();
        public Form4()
        {
            InitializeComponent();
            sqlConnection= new MySqlConnection(connection);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            query = $"select nama_cust,nik_cust,date_format(birth_date_cust,'%d %M %Y'),no_telp_cust,email_cust from customer where id_cust='{Form1.customerid}';";
            sqlCommand = new MySqlCommand(query, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtCustomer);

            label_nama.Text= dtCustomer.Rows[0][0].ToString();
            label_nik.Text= dtCustomer.Rows[0][1].ToString();
            label_birthdate.Text = dtCustomer.Rows[0][2].ToString();
            label_noTelp.Text= dtCustomer.Rows[0][3].ToString();
            label_email.Text= dtCustomer.Rows[0][4].ToString();
        }

        private void label_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void label_editPassword_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            this.Hide();
            form5.ShowDialog();
        }
    }
}
