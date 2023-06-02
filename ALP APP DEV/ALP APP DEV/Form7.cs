using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace ALP_APP_DEV
{
    public partial class Form7 : Form
    {
        private string selectedValue;
        public static DateTime jadwal;
        public static string categoryconcert = "";
        public static Decimal priceconcert;
        public static string jadwalid="";
        public static string categoryid = "";
        public static int maxcapacity;
        MySqlConnection sqlConnection;
        DataTable dtConcert = new DataTable();
        DataTable dtPicture = new DataTable();
        string connection = "server=localhost;uid=root;pwd=root;database=db_concert";
        string formattedDate;
        public Form7()
        {
            InitializeComponent();
            sqlConnection = new MySqlConnection(connection);
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            //DESCRIPTION & GAMBAR
            string query = $"SELECT desc_concert,gambar FROM concert WHERE nama_concert = '{Form3.judulconcert}'";
            using (MySqlConnection sqlConnection = new MySqlConnection(connection))
            {
                using (MySqlCommand sqlCommand = new MySqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@selectedValue", selectedValue);
                    sqlConnection.Open();
                    using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            string columnName = sqlDataReader["desc_concert"].ToString();
                            string [] split=columnName.Split(' ');
                            
                            for(int i=0; i < split.Length; i++)
                            {
                                labeldesc.Text = labeldesc.Text+ split[i]+" ";
                                if(i%10==0 && i>0)
                                    labeldesc.Text = labeldesc.Text+"\n";
                            }

                            string workingDirectory = Environment.CurrentDirectory;
                            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

                            string imagepath = projectDirectory + sqlDataReader["gambar"].ToString();
                            pictureBox1.ImageLocation = imagepath;
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                }
            }
            //BUTTON
            query = $"SELECT j.date_jadwal FROM jadwal j, concert c WHERE j.id_concert = c.id_concert AND c.nama_concert = '{Form3.judulconcert}'";
            using (MySqlConnection sqlConnection = new MySqlConnection(connection))
            {
                using (MySqlCommand sqlCommand = new MySqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@selectedValue", selectedValue);
                    sqlConnection.Open();
                    using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        int buttonY = 250;

                        while (sqlDataReader.Read())
                        {
                            string date = sqlDataReader["date_jadwal"].ToString();
                            Button button = new Button();
                            button.Text = date;
                            button.ForeColor = Color.Black;
                            button.BackColor = Color.White;
                            button.Location = new Point(100, buttonY);
                            button.Click += button_Click;
                            this.Controls.Add(button);

                            buttonY += 30;
                        }
                    }
                }
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string selectedDate = button.Text;

            DateTime date;
            if (DateTime.TryParse(selectedDate, out date))
            {
                formattedDate = date.ToString("yyyy-MM-dd"); // Format the date as 'YYYY-MM-DD'
                labelSelectedDate.Text = "Selected Date: " + formattedDate;
                // Clear existing seat information
                panelSeats.Controls.Clear();

                string query = $@"
                SELECT c.nama_concert AS concert_name,
                k.nama_kategori AS category_name,
                k.harga,
                k.maxcapacity,
                k.maxcapacity - COALESCE(SUM(t.totalkursi), 0) AS remaining_seats,
                j.id_jadwal
                FROM concert c
                INNER JOIN jadwal j ON c.id_concert = j.id_concert
                INNER JOIN kategori_kursi k ON c.id_concert = k.id_concert
                LEFT JOIN transaksi t ON k.id_kategori = t.id_kategori AND j.id_jadwal = t.id_jadwal
                WHERE c.nama_concert = '{Form3.judulconcert}'
                    AND j.date_jadwal = @selectedDate
                GROUP BY c.nama_concert, k.nama_kategori, k.harga, k.maxcapacity,j.id_jadwal;";

                using (MySqlConnection sqlConnection = new MySqlConnection(connection))
                {
                    using (MySqlCommand sqlCommand = new MySqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@selectedValue", selectedValue);
                        sqlCommand.Parameters.AddWithValue("@selectedDate", formattedDate);
                        sqlConnection.Open();
                        using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            int labelY = 50;
                            int labelyy = 50;
                            while (sqlDataReader.Read())
                            {
                                string categoryName = sqlDataReader["category_name"].ToString();
                                string price = sqlDataReader["harga"].ToString();
                                string maxCapacity = sqlDataReader["maxcapacity"].ToString();
                                string remainingSeats = sqlDataReader["remaining_seats"].ToString();

                                Label labelCategoryName = new Label();
                                labelCategoryName.Location = new Point(50, labelY);
                                labelCategoryName.Size = new Size(200, 20);
                                labelCategoryName.Text = "Category: " + categoryName;
                                labelCategoryName.ForeColor = Color.White;
                                labelCategoryName.Font= new Font("Microsoft Sans Serif",10, FontStyle.Bold);
                                panelSeats.Controls.Add(labelCategoryName);

                                Label labelPrice = new Label();
                                labelPrice.Location = new Point(50, labelY + 30);
                                labelPrice.Size = new Size(200, 20);
                                int harga = Convert.ToInt32(price);
                                labelPrice.Text = "Price: IDR " + harga.ToString("N0");
                                labelPrice.ForeColor = Color.White;
                                labelPrice.Font= new Font("Microsoft Sans Serif", 10);
                                panelSeats.Controls.Add(labelPrice);

                                Label labelMaxCapacity = new Label();
                                labelMaxCapacity.Location = new Point(50, labelY + 60);
                                labelMaxCapacity.Size = new Size(200, 20);
                                labelMaxCapacity.Text = "Max Capacity: " + maxCapacity;
                                labelMaxCapacity.ForeColor = Color.White;
                                labelMaxCapacity.Font= new Font("Microsoft Sans Serif", 10);
                                panelSeats.Controls.Add(labelMaxCapacity);

                                Label labelRemainingSeats = new Label();
                                labelRemainingSeats.Location = new Point(50, labelY + 90);
                                labelRemainingSeats.Size = new Size(200, 20);
                                if (remainingSeats == "0")
                                    remainingSeats = "Full";
                                labelRemainingSeats.Text = "Remaining Seats: " + remainingSeats;
                                labelRemainingSeats.ForeColor = Color.Tomato;
                                labelRemainingSeats.Font= new Font("Microsoft Sans Serif", 10);
                                panelSeats.Controls.Add(labelRemainingSeats);

                                labelY += 150;

                                Button button1 = new Button();
                                button1.Text = "Buy";
                                button1.Name = categoryName;
                                button1.Location = new Point(260, labelyy);
                                button1.Click += button1_click;
                                button1.BackColor = Color.White;
                                panelSeats.Controls.Add(button1);

                                labelyy += 150;
                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid date format: " + selectedDate);
                return;
            }
        }
        private void button1_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            categoryconcert = button.Name;

            string query = $@"
            SELECT c.nama_concert AS concert_name,
                k.nama_kategori AS category_name,
                k.harga,
                j.date_jadwal,
                j.id_jadwal,
                k.id_kategori,
                k.maxcapacity - COALESCE(SUM(t.totalkursi), 0) AS remaining_seats
            FROM concert c
            INNER JOIN jadwal j ON c.id_concert = j.id_concert
            INNER JOIN kategori_kursi k ON c.id_concert = k.id_concert
            LEFT JOIN transaksi t ON k.id_kategori = t.id_kategori AND j.id_jadwal = t.id_jadwal
            WHERE c.nama_concert = '{Form3.judulconcert}'
                AND k.nama_kategori = @categoryName
                AND j.date_jadwal='{formattedDate}'
            GROUP BY c.nama_concert, k.nama_kategori, k.harga, j.date_jadwal,j.id_jadwal, k.id_kategori;";

            using (MySqlConnection sqlConnection = new MySqlConnection(connection))
            {
                using (MySqlCommand sqlCommand = new MySqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@selectedValue", selectedValue);
                    sqlCommand.Parameters.AddWithValue("@categoryName", categoryconcert);
                    sqlConnection.Open();
                    using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            priceconcert = Convert.ToDecimal(sqlDataReader["harga"]);
                            jadwal = Convert.ToDateTime(sqlDataReader["date_jadwal"]);
                            jadwalid = sqlDataReader["id_jadwal"].ToString();
                            categoryid = sqlDataReader["id_kategori"].ToString();
                            maxcapacity = Convert.ToInt32(sqlDataReader["remaining_seats"]);
                        }
                    }
                }
            }
            //MessageBox.Show($"jadwal id= {jadwalid} \ncategory id= {categoryid} \nmaxcapacity={maxcapacity}");

            this.Hide();
            Form8 form8 = new Form8();
            form8.Show();
        }
        private void label_back_Click(object sender, EventArgs e)
        {
            Form3 form3= new Form3();
            this.Hide();
            form3.ShowDialog();
        }

        private void panelSeats_MouseEnter(object sender, EventArgs e)
        {
            panelSeats.Focus();
        }
    }
}
