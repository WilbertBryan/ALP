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
        DataTable dtNomerduduk = new DataTable();
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
            for (int i = 4 - ids.Length; i >= 1; i--)
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
            }
            
            query = $"SELECT\r\ncase \r\n\twhen k.nama_kategori='SILVER' THEN 'S-'\r\n    when k.nama_kategori='BRONZE' THEN 'B-'\r\n    ELSE k.nama_kategori\r\n    END as nama_kategori,k.`status`,count(q.id_kategori)\r\nFROM queue_number q, kategori_kursi k\r\nwhere q.id_kategori ='{Form7.categoryid}' && q.id_kategori=k.id_kategori\r\ngroup by 1,2;";
            sqlCommand = new MySqlCommand(query, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtConcert);

            //BELUM ADA DI TABLE Queue_Number
            if(dtConcert.Rows.Count.ToString()=="0")
            {
                dtConcert = new DataTable();
                query = $"SELECT\r\ncase \r\n\twhen k.nama_kategori='SILVER' THEN 'S-'\r\n    when k.nama_kategori='BRONZE' THEN 'B-'\r\n    ELSE k.nama_kategori\r\n    END as nama_kategori,k.`status`\r\nFROM kategori_kursi k\r\nwhere k.id_kategori ='{Form7.categoryid}';";
                sqlCommand = new MySqlCommand(query, sqlConnection);
                sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dtConcert);

                //TEMPAT DUDUK STANDING
                if (dtConcert.Rows[0][1].ToString() == "standing") 
                {
                    for (int i = 1; i <= count; i++)
                    {
                        query = $"insert into queue_number values ('{idTransaksi}','{Form7.categoryid}','{dtConcert.Rows[0][0].ToString()}')";
                        sqlConnection.Open();
                        sqlCommand = new MySqlCommand(query, sqlConnection);
                        sqlDataReader = sqlCommand.ExecuteReader();
                        sqlConnection.Close();
                    }
                }
                //TEMPAT DUDUK SEAT ADA NOMER
                else
                {
                    int nomerduduk = 1;
                    for (int i = 1; i <= count; i++)
                    {
                        query = $"insert into queue_number values ('{idTransaksi}','{Form7.categoryid}','{dtConcert.Rows[0][0].ToString()+nomerduduk.ToString()}')";

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
                        }
                        nomerduduk++;
                    }
                }
            }
            //SUDAH ADA DI TABLE Queue_number
            else
            {
                dtConcert = new DataTable();
                query = $"SELECT\r\ncase \r\n\twhen k.nama_kategori='SILVER' THEN 'S-'\r\n    when k.nama_kategori='BRONZE' THEN 'B-'\r\n    ELSE k.nama_kategori\r\n    END as nama_kategori,k.`status`\r\nFROM kategori_kursi k\r\nwhere k.id_kategori ='{Form7.categoryid}';";
                sqlCommand = new MySqlCommand(query, sqlConnection);
                sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dtConcert);

                //kursi standing
                if (dtConcert.Rows[0][1].ToString() == "standing")
                {
                    for (int i = 1; i <= count; i++)
                    {
                        query = $"insert into queue_number values ('{idTransaksi}','{Form7.categoryid}','{dtConcert.Rows[0][0].ToString()}')";
                        sqlConnection.Open();
                        sqlCommand = new MySqlCommand(query, sqlConnection);
                        sqlDataReader = sqlCommand.ExecuteReader();
                        sqlConnection.Close();
                    }
                }
                //kursi duduk
                else
                {
                    query = $"select count(id_kategori)\r\nfrom queue_number\r\nwhere id_kategori='{Form7.categoryid}';";
                    sqlCommand = new MySqlCommand(query, sqlConnection);
                    sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dtNomerduduk);
                    int nomerduduk=Convert.ToInt32(dtNomerduduk.Rows[0][0].ToString())+1;

                    for (int i = 1; i <= count; i++)
                    {
                        query = $"insert into queue_number values ('{idTransaksi}','{Form7.categoryid}','{dtConcert.Rows[0][0].ToString() + nomerduduk.ToString()}')";

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
                        }
                        nomerduduk++;
                    }
                }
            }
            MessageBox.Show("Purchase complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}
