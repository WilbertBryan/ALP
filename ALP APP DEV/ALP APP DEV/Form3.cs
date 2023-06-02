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
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace ALP_APP_DEV
{
    public partial class Form3 : Form
    {
        bool menuPop = false;
        string query = "";
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        DataTable dtConcert = new DataTable();
        DataTable dtPicture= new DataTable();
        public static string concertid = "";
        public static string judulconcert = "";
        
        string connection = "server=localhost;uid=root;pwd=root;database=db_concert";
        Label[] labeljudul;
        Label[] labelharga;
        Label[] labeltanggal;
        Label[] labelavailable;
        Label[] labelstartfrom;
        PictureBox[] pictureBox;
        public Form3()
        {
            InitializeComponent();
            sqlConnection=new MySqlConnection(connection);
        }
        public void Design()
        {
            labeljudul = new Label[dtConcert.Rows.Count];
            pictureBox = new PictureBox[dtConcert.Rows.Count];
            labelharga = new Label[dtConcert.Rows.Count];
            labeltanggal = new Label[dtConcert.Rows.Count];
            labelavailable = new Label[dtConcert.Rows.Count];
            labelstartfrom = new Label[dtConcert.Rows.Count];

            int pictureboxY = 70;
            int labeljudulY = 70;
            int labeltanggalY = 160;
            int labelavailableY = 180;
            int labelhargaY = 260;
            int labelstartfromY = 260;
            for (int i = 0; i < dtConcert.Rows.Count; i++)
            {

                //PICTURE BOX
                pictureBox[i] = new PictureBox();
                pictureBox[i].Location = new Point(90, pictureboxY);
                pictureBox[i].Size = new Size(180, 220);
                pictureBox[i].SizeMode = PictureBoxSizeMode.StretchImage;
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

                string imagepath = projectDirectory + dtConcert.Rows[i][1].ToString();
                //MessageBox.Show(imagepath);
                pictureBox[i].ImageLocation = imagepath;
                pictureBox[i].Tag = i.ToString();
                pictureBox[i].Click += pictureBox_Click;
                this.panel_concert.Controls.Add(pictureBox[i]);
                pictureboxY += 290;

                //LABEL JUDUL
                labeljudul[i] = new Label();
                labeljudul[i].Location = new Point(300, labeljudulY);
                labeljudul[i].Size = new Size(1000, 50);
                labeljudul[i].Font = new Font("Microsoft Sans Serif", 20);
                labeljudul[i].Text = dtConcert.Rows[i][0].ToString();
                labeljudul[i].ForeColor = Color.White;
                labeljudul[i].Click += label_Click;
                this.panel_concert.Controls.Add(labeljudul[i]);
                labeljudulY += 290;

                //LABEL TANGGAL
                labeltanggal[i] = new Label();
                labeltanggal[i].Location = new Point(305, labeltanggalY);
                labeltanggal[i].Size = new Size(500, 20);
                labeltanggal[i].Font = new Font("Microsoft Sans Serif", 10);
                labeltanggal[i].Text = dtConcert.Rows[i][3].ToString();
                labeltanggal[i].ForeColor = Color.White;
                this.panel_concert.Controls.Add(labeltanggal[i]);
                labeltanggalY += 290;

                //LABEL AVAILABLE
                labelavailable[i] = new Label();
                labelavailable[i].Location = new Point(305, labelavailableY);
                labelavailable[i].Size = new Size(500, 20);
                labelavailable[i].Font = new Font("Microsoft Sans Serif", 10);
                labelavailable[i].Text = "Available (" + Convert.ToInt32(dtConcert.Rows[i][4]).ToString() + ") days";
                labelavailable[i].ForeColor = Color.LightGreen;
                this.panel_concert.Controls.Add(labelavailable[i]);
                labelavailableY += 290;

                //LABEL HARGA
                labelharga[i] = new Label();
                labelharga[i].Location = new Point(400, labelhargaY);
                labelharga[i].Size = new Size(1000, 20);
                labelharga[i].Font = new Font("Microsoft Sans Serif", 14);
                int harga = Convert.ToInt32(dtConcert.Rows[i][2]);
                labelharga[i].Text = "IDR " + harga.ToString("N0");
                labelharga[i].ForeColor = Color.Tomato;
                this.panel_concert.Controls.Add(labelharga[i]);
                labelhargaY += 290;

                //LABEL START FROM
                labelstartfrom[i] = new Label();
                labelstartfrom[i].Location = new Point(305, labelstartfromY);
                labelstartfrom[i].Size = new Size(1000, 20);
                labelstartfrom[i].Font = new Font("Microsoft Sans Serif", 10);
                labelstartfrom[i].Text = "start from:";
                labelstartfrom[i].ForeColor = Color.Gray;
                this.panel_concert.Controls.Add(labelstartfrom[i]);
                labelstartfromY += 290;
            }

        }
        private void Form3_Load(object sender, EventArgs e)
        {
            this.AutoScroll = false;
            this.HorizontalScroll.Visible = false;
            this.HorizontalScroll.Enabled = false;
            this.AutoScroll = true;
            
            dtConcert =new DataTable();
            query = "SELECT c.nama_concert,c.gambar, MIN(k.harga),MIN(date_format(j.date_jadwal,'%d %M %Y')),count(j.id_concert)/5\r\nFROM concert c, kategori_kursi k, jadwal j\r\nWHERE c.id_concert = k.id_concert AND j.id_concert=c.id_concert\r\nGROUP BY c.nama_concert,c.gambar;";
            sqlCommand = new MySqlCommand(query, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtConcert);

            Design();

        }
        private void label_profile_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void label_history_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            this.Hide();
            form6.ShowDialog();
        }

        private void label_panah_Click(object sender, EventArgs e)
        {
            if(menuPop == false)
            {
                panel_menu.Location = new Point(-30, 0);
                menuPop = true;
            } else
            {
                panel_menu.Location = new Point(-110, 0);
                menuPop = false;
            }
        }


        private void txt_searchBar_TextChanged(object sender, EventArgs e)
        {
            panel_concert.Controls.Clear();
            string namasearch = txt_searchBar.Text.ToUpper();

            dtConcert = new DataTable();
            query = $"SELECT c.nama_concert,c.gambar, MIN(k.harga),MIN(date_format(j.date_jadwal,'%d %M %Y')),count(j.id_concert)/5\r\nFROM concert c, kategori_kursi k, jadwal j\r\nWHERE c.id_concert = k.id_concert AND j.id_concert=c.id_concert AND c.nama_concert like'{namasearch}%'\r\nGROUP BY c.nama_concert,c.gambar;";

            sqlCommand = new MySqlCommand(query, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtConcert);

            Design();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            dtPicture = new DataTable();
            PictureBox pbox= (PictureBox)sender;
            int num=Convert.ToInt32(pbox.Tag.ToString());

            query = $"select id_concert,nama_concert from concert where nama_concert='{dtConcert.Rows[num][0].ToString()}';";
            sqlCommand = new MySqlCommand(query, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtPicture);

            concertid=dtPicture.Rows[0][0].ToString();
            judulconcert = dtPicture.Rows[0][1].ToString();
            Form7 form7 = new Form7 ();
            this.Hide();
            form7.ShowDialog();
        }

        private void label_Click(object sender, EventArgs e)
        {
            Label selectedlabel = (Label)sender;
            string selectedvalue = selectedlabel.Text;
            this.Hide();
            Form7 form7 = new Form7 ();
            judulconcert = selectedvalue;
            form7.ShowDialog();
        }

        private void label_logOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to log out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Account has been logged out.", "Log Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form1 form1 = new Form1();
                form1.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Account not logged out.", "Log Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void panel_concert_MouseEnter(object sender, EventArgs e)
        {
            panel_concert.Focus();
        }

        private void panel_concert_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_concert_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
