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
    
    public partial class AdminkullaniciEkle : Form
    {
        //sql bağlantısı
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-B024QRDP;Initial Catalog=KutuhaneVTYS;Integrated Security=True; TrustServerCertificate = true");
        public AdminkullaniciEkle()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //kullanıcı eklemek için gerekli kod
            try
            {


                baglanti.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Uyeler (UyeID,UyeAdi,UyeSoyadi,UyeTelefonNo) VALUES (@ıd,@ad,@soyad,@telno)", baglanti);
                cmd.Parameters.AddWithValue("@ıd", textBox4.Text);
                cmd.Parameters.AddWithValue("@ad", textBox1.Text);
                cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
                cmd.Parameters.AddWithValue("@telno", textBox3.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı Eklendi.");

            }
            catch (Exception ex)// hata durumunda verilecek mesaj
            {
                MessageBox.Show("Kullanıcı Eklenemedi.Lütfen tekrar deneyiniz.");
                baglanti.Close();
            }
            finally {
               
                baglanti.Close(); 
                this.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AdminkullaniciEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
