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
    public partial class PersonelKitapEkle : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-B024QRDP;Initial Catalog=KutuhaneVTYS;Integrated Security=True; TrustServerCertificate = true");
        public PersonelKitapEkle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //kitap eklemek için 4 ayrı tabloya veri ekleyen kod
            try
            {
                baglanti.Open();
                SqlCommand cmd1 = new SqlCommand("INSERT INTO Kategoriler (KategoriID,KategoriAdi) VALUES (@kaıd,@kad)", baglanti);
                cmd1.Parameters.AddWithValue("@kaıd", textBox3.Text);
                cmd1.Parameters.AddWithValue("@kad", textBox9.Text);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("INSERT INTO YayinEvleri (YayinEviID,YayinEviAdi) VALUES (@yaıd,@yad)", baglanti);
                cmd2.Parameters.AddWithValue("@yaıd", textBox8.Text);
                cmd2.Parameters.AddWithValue("@yad", textBox7.Text);
                cmd2.ExecuteNonQuery();
                SqlCommand cmd3 = new SqlCommand("INSERT INTO Yazarlar (YazarID,YazarAdi) VALUES (@yrıd,@yrad)", baglanti);
                cmd3.Parameters.AddWithValue("@yrıd", textBox1.Text);
                cmd3.Parameters.AddWithValue("yrad", textBox4.Text);
                cmd3.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("INSERT INTO Kitaplarr (KitapAdi,KategoriID,YazarId,YayineviID,SayfaSayisi,KitapDurumu,KitapYeri) VALUES (@ad,@katıd,@yıd,@yayıd,@says,@kd,@ky)", baglanti);
                cmd.Parameters.AddWithValue("@ad", textBox2.Text);
                cmd.Parameters.AddWithValue("@says", textBox5.Text);
                cmd.Parameters.AddWithValue("@ky", textBox6.Text);
                cmd.Parameters.AddWithValue("@yıd", textBox1.Text);
                cmd.Parameters.AddWithValue("@katıd", textBox3.Text);
                cmd.Parameters.AddWithValue("@yayıd", textBox8.Text);
                cmd.Parameters.AddWithValue("@kd", "Rafta");
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA OLUŞTU");
                baglanti.Close();
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void PersonelKitapEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
