using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class Adminform2 : Form
    {

        SqlDataAdapter adap;
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-B024QRDP;Initial Catalog=KutuhaneVTYS;Integrated Security=True; TrustServerCertificate = true");


        void Getir()
        {
            //udf ile kitapları listeleyen fonksiyon

            baglanti.Open();
            adap = new SqlDataAdapter("SELECT *FROM dbo.KitapListele()", baglanti);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        public Adminform2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Getir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminOduncVer adminOduncVer = new AdminOduncVer();
            adminOduncVer.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminİadeEt adminİadeEt = new AdminİadeEt();
            adminİadeEt.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminKitapEkle adminKitapEkle = new AdminKitapEkle();
            adminKitapEkle.ShowDialog();




        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminkullaniciEkle adminn = new AdminkullaniciEkle();
            adminn.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdminKullaniciSil adminKullaniciSil = new AdminKullaniciSil();
            adminKullaniciSil.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // udf ile uyeleri listeleyen kodlar 
            baglanti.Open();
            adap = new SqlDataAdapter("SELECT * FROM dbo.UyeListele()", baglanti);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //view ile dışarıda olan kitapları listeleyen kodlar 
            baglanti.Open();
            adap = new SqlDataAdapter("SELECT * FROM DisaridaOlanKitaplarView", baglanti);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AdminPersonelEkle adminPersonelEkle = new AdminPersonelEkle();
            adminPersonelEkle.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //personelleri listeleyen kodlar 
            baglanti.Open();
            adap = new SqlDataAdapter("SELECT * FROM dbo.PersonelListele() ", baglanti);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            AdminOduncVer adminOduncVer = new AdminOduncVer();
            adminOduncVer.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Adminform2_Load(object sender, EventArgs e)
        {
            baglanti.Open();//kütüphanedeki kitap durumunu personel ve kullanıcı sayılarını yazdıran kodlar
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Kitaplarr", baglanti); 
            object toplam = cmd.ExecuteScalar();
            label1.Text = toplam.ToString();

            SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM Kitaplarr WHERE KitapDurumu = 'Rafta'", baglanti);
            object ktoplam = cmd1.ExecuteScalar();
            label2.Text = ktoplam.ToString();

            SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM Kitaplarr WHERE KitapDurumu = 'Disarida'", baglanti);
            object dtoplam = cmd2.ExecuteScalar();
            label3.Text = dtoplam.ToString();

            SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM Uyeler", baglanti);
            object utoplam = cmd3.ExecuteScalar();
            label4.Text = utoplam.ToString();

            SqlCommand cmd4 = new SqlCommand("SELECT COUNT(*) FROM Personeller", baglanti);
            object ptoplam = cmd4.ExecuteScalar();
            label5.Text = ptoplam.ToString();

            baglanti.Close();

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AdminPersonelSil adminPersonelSil = new AdminPersonelSil();
            adminPersonelSil.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            AdminSüreUzat adminSüreUzat= new AdminSüreUzat();
            adminSüreUzat.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            AdminKitapSil adminKitapSil = new AdminKitapSil();
            adminKitapSil.ShowDialog();
        }
    }
}
