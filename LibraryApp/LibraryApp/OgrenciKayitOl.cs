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
    public partial class OgrenciKayitOl : Form
    {   SqlConnection baglanti=new SqlConnection("Data Source=LAPTOP-B024QRDP;Initial Catalog=KutuhaneVTYS;Integrated Security=True; TrustServerCertificate = true");
        public OgrenciKayitOl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //öğrenci kayıt için gerekli kodlar
            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Uyeler (UyeID,UyeAdi,UyeSoyadi,UyeTelefonNo) VALUES (@ıd,@ad,@soyad,@no)", baglanti);
                cmd.Parameters.AddWithValue("@ıd",textBox4.Text);
                cmd.Parameters.AddWithValue("@ad", textBox1.Text);
                cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
                cmd.Parameters.AddWithValue("@no", textBox3.Text);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                MessageBox.Show("Kaydınız Tamamlandı");
                baglanti.Close();
                this.Close();
            }
        }

        private void OgrenciKayitOl_Load(object sender, EventArgs e)
        {

        }
    }
}
