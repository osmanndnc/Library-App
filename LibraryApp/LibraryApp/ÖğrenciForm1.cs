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
    public partial class ÖğrenciForm1 : Form
    {   

        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-B024QRDP;Initial Catalog=KutuhaneVTYS;Integrated Security=True; TrustServerCertificate = true");
        OgrenciForm2 kullaniciid = new OgrenciForm2();

        public ÖğrenciForm1()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //datareader ile öğrenci giriş işlemini yapan kodlar 
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM UYELER WHERE UyeID = @UyeID", baglanti);
            cmd.Parameters.AddWithValue("@UyeID", textBox1.Text);
            SqlDataReader rdr = cmd.ExecuteReader();
            bool uyeIDBulundu = false;
            while (rdr.Read())
            {
                uyeIDBulundu = true;
                break;
            }

            rdr.Close();
            baglanti.Close();
            if (uyeIDBulundu)
            {
                kullaniciid.yazı = textBox1.Text;
                kullaniciid.ShowDialog();
            }
            else
            {
                MessageBox.Show("Giriş Yapılamadı.Lütfen tekrar deneyiniz");
            }



        }

        private void ÖğrenciForm1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgrenciKayitOl ogrenciKayitOl = new OgrenciKayitOl();   
            ogrenciKayitOl.ShowDialog();
        }
    }
}
