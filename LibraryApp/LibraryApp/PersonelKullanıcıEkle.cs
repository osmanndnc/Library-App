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
    public partial class PersonelKullanıcı_Ekle : Form
    {   SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-B024QRDP;Initial Catalog=KutuhaneVTYS;Integrated Security=True; TrustServerCertificate = true");
        public PersonelKullanıcı_Ekle()
        {
            InitializeComponent();
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
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı Eklenemedi.Lütfen tekrar deneyiniz.");
                baglanti.Close();
            }
            finally
            {

                baglanti.Close();
                this.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PersonelKullanıcı_Ekle_Load(object sender, EventArgs e)
        {

        }
    }
}
