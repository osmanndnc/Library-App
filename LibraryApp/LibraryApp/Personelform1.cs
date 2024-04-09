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
    public partial class Personelform1 : Form
    {   SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-B024QRDP;Initial Catalog=KutuhaneVTYS;Integrated Security=True; TrustServerCertificate = true");
        public Personelform1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //datareader ile personel girişinin yapıldığı kodlar 
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Personeller WHERE PersonelID = @Persıd", baglanti);
            cmd.Parameters.AddWithValue("@Persıd", textBox1.Text);
              SqlDataReader rdr = cmd.ExecuteReader();
            bool PersIDBulundu = false;
            while (rdr.Read())
            {
                PersIDBulundu = true;
                break;
            }
            rdr.Close();
            baglanti.Close();
            if (PersIDBulundu)
            {
                PersonelForm2 personelForm2 = new PersonelForm2();
                personelForm2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Giriş Yapılamadı.Lütfen tekrar deneyiniz");
            }
        }

        private void Personelform1_Load(object sender, EventArgs e)
        {

        }
    }
}
