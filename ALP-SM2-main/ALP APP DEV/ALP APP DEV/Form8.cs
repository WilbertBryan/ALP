using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace ALP_APP_DEV
{
    public partial class Form8 : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        MySqlDataReader sqlDataReader;
        DataTable dtConcert = new DataTable();
        DataTable metodepembayaran=new DataTable();
        DataTable dtidTransaksi= new DataTable();
        string idTransaksi = "TRA";
        string query = "";
        string connection = "server=localhost;uid=root;pwd=root;database=db_concert";
        int count = 0;
        public Form8()
        {
            InitializeComponent();
            sqlConnection = new MySqlConnection(connection);
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            labelConcertName.Text = Form3.judulconcert;
            labelCategoryName.Text = Form7.categoryconcert;
            int harga = Convert.ToInt32(Form7.priceconcert);
            labelPrice.Text =  harga.ToString("N0");
            labelSelectedDate.Text = Form7.jadwal.ToString("yyyy-MM-dd");
            labelCount.Text = count.ToString();
            UpdateTotalLabel();

            query = "select jenis_pembayaran from transaksi where jenis_pembayaran in('BCA', 'MANDIRI','ALFAMART','INDOMART') group by jenis_pembayaran;";
            sqlCommand = new MySqlCommand(query, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(metodepembayaran);
            comboBox_transaksi.DataSource = metodepembayaran;
            comboBox_transaksi.DisplayMember = "jenis_pembayaran";
        }
        private void UpdateTotalLabel()
        {
            decimal total = count * Form7.priceconcert;
            int harga = Convert.ToInt32(total);
            label_total.Text = "IDR " + harga.ToString("N0");
        }
        private void minus_Click(object sender, EventArgs e)
        {
            if (count != 0)
            {
                count--;
                labelCount.Text = count.ToString();
                UpdateTotalLabel();
            } 
        }
        private void add_Click(object sender, EventArgs e)
        {
            if(count<Form7.maxcapacity)
            {
                count++;
                labelCount.Text = count.ToString();
                UpdateTotalLabel();
            }
           
        }

        private void label_back_Click(object sender, EventArgs e)
        {
            Form7 form7= new Form7();
            this.Hide();
            form7.ShowDialog();

        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            query = "select count(*)+1\r\nfrom  transaksi;";
            sqlCommand = new MySqlCommand(query, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtidTransaksi);

            int id = Convert.ToInt32(dtidTransaksi.Rows[0][0]);
            string ids = id.ToString();
            for (int i = 3 - ids.Length; i >= 1; i--)
            {
                idTransaksi += "0";
            }
            idTransaksi += ids;

            query = $"INSERT INTO transaksi values ('{idTransaksi}','{count}','{comboBox_transaksi.Text}','{Form1.customerid}','{Form7.jadwalid}','{Form7.categoryid}')";

            try
            {
                sqlConnection.Open();
                sqlCommand=new MySqlCommand(query,sqlConnection);  
                sqlDataReader= sqlCommand.ExecuteReader();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
                MessageBox.Show("Success");
            }
        }
    }
}
