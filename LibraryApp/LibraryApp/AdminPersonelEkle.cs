using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace LibraryApp
{
    public partial class AdminPersonelEkle : Form
        //sql baglantısı
    {   SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-B024QRDP;Initial Catalog=KutuhaneVTYS;Integrated Security=True; TrustServerCertificate = true");
        public AdminPersonelEkle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //personel tablosuna veri ekleyip sonra da son eklenen verinin numarasını bildiren kod
            try
            {
                baglanti.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Personeller (PersonelAd, PersonelSoyad) VALUES (@ad, @soyad); SELECT SCOPE_IDENTITY();", baglanti);
                cmd.Parameters.AddWithValue("@ad", textBox1.Text);
                cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
                int yeniPersonelID = Convert.ToInt32(cmd.ExecuteScalar());

                MessageBox.Show("Personel Eklendi! Personel ID: " + yeniPersonelID.ToString());
            }
            finally
            {
                baglanti.Close();
                this.Close();
            }


        }

        private void AdminPersonelEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
