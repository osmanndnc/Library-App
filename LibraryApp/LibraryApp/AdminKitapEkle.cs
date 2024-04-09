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
    public partial class AdminKitapEkle : Form
    {
        //sql baglantısı
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-B024QRDP;Initial Catalog=KutuhaneVTYS;Integrated Security=True; TrustServerCertificate = true");
        SqlDataAdapter adap;
        public AdminKitapEkle()
        {
            InitializeComponent();
        }

        private void AdminKitapEkle_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try//kitap eklemek için 4 ayrı tabloya veri ekleyen kod
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
                MessageBox.Show("Kitap Eklendi");

            }
            catch (Exception ex)//hata durumunda verilecek mesaj
            {
                MessageBox.Show("HATA");
                
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

