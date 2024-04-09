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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
namespace LibraryApp
{
    public partial class PersonelOduncVer : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-B024QRDP;Initial Catalog=KutuhaneVTYS;Integrated Security=True; TrustServerCertificate = true");
        SqlDataAdapter adap;
        public PersonelOduncVer()
        {
            InitializeComponent();
        }
        void GetirUye()
        {
            //üyeleri listeleyen kodlar 
            adap = new SqlDataAdapter("SELECT UyeID,UyeAdi FROM Uyeler", baglanti);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void GetirKitap()
        {
            // kitapları listeleyen kodlar
            adap = new SqlDataAdapter("SELECT KitapID,KitapAdi,KitapDurumu FROM kitaplarr", baglanti);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            dataGridView2.DataSource = tablo;
        }

        DateTime altar = DateTime.Now;//alım tarihi
        DateTime testar = DateTime.Now.AddMonths(1);// teslim tarihi 
        private void button1_Click(object sender, EventArgs e)
        {
            //rafta olan kitabı ödünç veren kodlar 
            try
            {
                baglanti.Open();
                if (textBox3.Text == "Disarida")
                {
                    MessageBox.Show("Kitap Kütüphanede olmadığı için alamazsınız!");
                    baglanti.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO  Odunc (AlimTarihi,TeslimTarihi,UyeID,KitapID) VALUES (@Altar,@Ttar,@UyeID,@KitapID)", baglanti);
                    cmd.Parameters.AddWithValue("@Altar", altar);
                    cmd.Parameters.AddWithValue("@Ttar", testar);
                    cmd.Parameters.AddWithValue("@UyeID", Convert.ToInt32(textBox1.Text));
                    cmd.Parameters.AddWithValue("@KitapID", Convert.ToInt32(textBox2.Text));
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd2 = new SqlCommand("UPDATE Kitaplarr SET KitapDurumu=@durum1 WHERE KitapID=@kitıd", baglanti);
                    cmd2.Parameters.AddWithValue("@kitıd", Convert.ToInt32(textBox2.Text));
                    cmd2.Parameters.AddWithValue("@durum1", "Dışarıda");
                    cmd2.ExecuteNonQuery();
                    GetirUye();
                    GetirUye();
                    textBox3.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                    MessageBox.Show("Kitap ödünç verildi");


                }
            }
            //hata durumunda verilecek mesaj 
            catch 
            {
                MessageBox.Show("HATA!");
            }   
            finally
            {
                baglanti.Close();
               
            }
        }


     
        private void button2_Click_1(object sender, EventArgs e)
        {
            GetirUye();

        }

        private void PersonelOduncVer_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetirKitap();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox2.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
        }
    }
}