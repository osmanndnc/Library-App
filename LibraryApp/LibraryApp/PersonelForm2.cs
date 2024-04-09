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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryApp
{
    public partial class PersonelForm2 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-B024QRDP;Initial Catalog=KutuhaneVTYS;Integrated Security=True; TrustServerCertificate = true");
        SqlDataAdapter adap;
        public PersonelForm2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //kitapları listeleyen kod
            baglanti.Open();
            adap = new SqlDataAdapter("SELECT * FROM Kitaplarr", baglanti);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            //üyeleri listeleyen kod 
            baglanti.Open();
            adap = new SqlDataAdapter("SELECT * FROM Uyeler ", baglanti);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PersonelKullaniciSİl personelKullaniciSİl = new PersonelKullaniciSİl();
            personelKullaniciSİl.Show();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PersonelKullanıcı_Ekle personelKullanıcı_Ekle = new PersonelKullanıcı_Ekle();
            personelKullanıcı_Ekle.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            PersonelKitapEkle personelKitapEkle = new PersonelKitapEkle();
            personelKitapEkle.ShowDialog();
        }

        private void PersonelForm2_Load(object sender, EventArgs e)
        {
            //kütüphane durumunu göstren kodlar 
            baglanti.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Kitaplarr", baglanti);
            object toplam = cmd.ExecuteScalar();
            label9.Text = toplam.ToString();

            SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM Kitaplarr WHERE KitapDurumu = 'Rafta'", baglanti);
            object ktoplam = cmd1.ExecuteScalar();
            label8.Text = ktoplam.ToString();

            SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM Kitaplarr WHERE KitapDurumu = 'Disarida'", baglanti);
            object dtoplam = cmd2.ExecuteScalar();
            label7.Text = dtoplam.ToString();

            SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM Uyeler", baglanti);
            object utoplam = cmd3.ExecuteScalar();
            label4.Text = utoplam.ToString();

            SqlCommand cmd4 = new SqlCommand("SELECT COUNT(*) FROM Personeller", baglanti);
            object ptoplam = cmd4.ExecuteScalar();
            label5.Text = ptoplam.ToString();

            baglanti.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PersonelİadeEt personelİadeEt = new PersonelİadeEt();
            personelİadeEt.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersonelOduncVer personelOduncVer = new PersonelOduncVer();
            personelOduncVer.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PersonelSüreUzat personelSüreUzat = new PersonelSüreUzat();
            personelSüreUzat.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
