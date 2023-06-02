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
    public partial class Form6 : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        DataTable dtCustomer = new DataTable();
        Label []judulKonser;
        Label []tanggalKonser;
        Label []kategoriKonser;
        Label []kursiKonser;
        Label []hargaKonser;
        string connection = "server=localhost;uid=root;pwd=root;database=db_concert";
        string query = "";
        public Form6()
        {
            InitializeComponent();
            sqlConnection=new MySqlConnection(connection);
        }
        private void Design()
        {
            judulKonser = new Label[dtCustomer.Rows.Count];
            tanggalKonser= new Label[dtCustomer.Rows.Count];
            kategoriKonser = new Label[dtCustomer.Rows.Count];
            kursiKonser = new Label[dtCustomer.Rows.Count];
            hargaKonser = new Label[dtCustomer.Rows.Count];

            int judulY = 20;
            int tanggalY = 70;
            int kategoriY = 90;
            int kursiY =110;
            int hargaY=130;

            for (int i = 0; i < dtCustomer.Rows.Count; i++)
            {
                
                //LABEL JUDUL KONSER
                judulKonser[i] = new Label();
                judulKonser[i].Location = new Point(100, judulY);
                judulKonser[i].Size = new Size(1000, 30);
                judulKonser[i].Font = new Font("Microsoft Sans Serif", 20);
                judulKonser[i].Text = dtCustomer.Rows[i][0].ToString();
                judulKonser[i].ForeColor = Color.White;
                this.Controls.Add(judulKonser[i]);
                judulY += 180;

                //LABEL TANGGAL KONSER
                tanggalKonser[i] = new Label();;
                tanggalKonser[i].Location = new Point(105, tanggalY);
                tanggalKonser[i].Size = new Size(1000, 19);
                tanggalKonser[i].Font = new Font("Microsoft Sans Serif", 10);
                tanggalKonser[i].Text = "Date / Time : "+dtCustomer.Rows[i][1].ToString()+" - "+ dtCustomer.Rows[i][2].ToString();
                tanggalKonser[i].ForeColor = Color.White;
                this.Controls.Add(tanggalKonser[i]);
                tanggalY += 180;

                //LABEL KATEGORI KONSER
                kategoriKonser[i] = new Label();
                kategoriKonser[i].Location = new Point(105, kategoriY);
                kategoriKonser[i].Size = new Size(1000, 19);
                kategoriKonser[i].Font=new Font("Microsoft Sans Serif", 10);
                kategoriKonser[i].Text = "Cateogry :" + dtCustomer.Rows[i][3].ToString();
                kategoriKonser[i].ForeColor= Color.White;
                this.Controls.Add(kategoriKonser[i]);
                kategoriY += 180;
                
                //LABEL KURSI
                kursiKonser[i] = new Label();
                kursiKonser[i].Location = new Point(105, kursiY);
                kursiKonser[i].Size= new Size(1000, 20);
                kursiKonser[i].Font = new Font("Microsoft Sans Serif", 10);
                kursiKonser[i].Text = "Seat No : "+dtCustomer.Rows[i][4].ToString();
                kursiKonser[i].ForeColor = Color.White;
                this.Controls.Add(kursiKonser[i]);
                kursiY += 180;

                //LABEL HARGA
                hargaKonser[i] = new Label();
                hargaKonser[i].Location = new Point(105, hargaY);
                hargaKonser[i].Size=new Size(1000, 20);
                hargaKonser[i].Font=new Font("Microsoft Sans Serif", 10);
                int harga = Convert.ToInt32(dtCustomer.Rows[i][5]);
                hargaKonser[i].Text = "Price : IDR " + harga.ToString("N0");
                hargaKonser[i].ForeColor= Color.White;
                this.Controls.Add(hargaKonser[i]);
                hargaY += 180;

            }
            Label totalPriceText=new Label();
            totalPriceText.Location = new Point(400, hargaY-90);
            totalPriceText.Size = new Size(90, 20);
            totalPriceText.Font=new Font("Microsoft Sans Serif", 10);
            totalPriceText.Text = "Total Price : ";
            totalPriceText.ForeColor = Color.White;
            this.Controls.Add(totalPriceText);

            dtCustomer = new DataTable();
            query = $"select sum(k.harga)\r\nfrom customer cus, transaksi t, kategori_kursi k, queue_number q\r\nwhere cus.id_cust=t.id_cust \r\n    and t.id_kategori=k.id_kategori\r\n    and t.id_order=q.id_order\r\n    and cus.id_cust='{Form1.customerid}';";
            sqlCommand = new MySqlCommand(query, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtCustomer);

            Label totalPrice=new Label();
            totalPrice.Location = new Point(500, hargaY - 90);
            totalPrice.Size = new Size(1000, 40);
            totalPrice.Font=new Font("Microsoft Sans Serif", 15);
            long total = Convert.ToInt32(dtCustomer.Rows[0][0]);
            totalPrice.Text = "IDR "+total.ToString("N0");
            totalPrice.ForeColor = Color.Tomato;
            this.Controls.Add(totalPrice);
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            query = $"select c.nama_concert,date_format(j.date_jadwal,'%d %M %Y'),j.time_jadwal,k.nama_kategori,if(`status`='standing','-',q.nokursi),k.harga\r\nfrom customer cus, transaksi t, jadwal j, concert c, kategori_kursi k, queue_number q\r\nwhere cus.id_cust=t.id_cust \r\n\tand t.id_jadwal=j.id_jadwal\r\n    and t.id_kategori=k.id_kategori\r\n    and t.id_order=q.id_order\r\n    and c.id_concert=j.id_concert\r\n    and cus.id_cust='{Form1.customerid}';";
            sqlCommand= new MySqlCommand(query,sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtCustomer);

            Design();
        }

        private void label_back_Click(object sender, EventArgs e)
        {
            Form3 form3= new Form3();
            this.Hide();
            form3.ShowDialog();
        }
    }
}
