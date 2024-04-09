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
    public partial class PersonelİadeEt: Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-B024QRDP;Initial Catalog=KutuhaneVTYS;Integrated Security=True; TrustServerCertificate = true");
        SqlDataAdapter dataAdapter;
        public PersonelİadeEt()
        {
            InitializeComponent();
        }
        void GetirKitap()
        {
            //üye id sine göre kitap listeleyen kodlar 
            int uyeID;
            if (!int.TryParse(textBox1.Text, out uyeID))
            {
                MessageBox.Show("Üye Bulunamadı");
                return;
            }
            dataAdapter = new SqlDataAdapter("SELECT * FROM Odunc WHERE UyeID = @UyeID", baglanti);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@UyeID", uyeID);

            DataTable tablo = new DataTable();
            dataAdapter.Fill(tablo);
            dataGridView2.DataSource = tablo;
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //kitap iade işlemi için gerekli kodlar 
            try
            {


                baglanti.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Odunc WHERE KitapID=@ıd", baglanti);
                cmd.Parameters.AddWithValue("@ıd", textBox2.Text);
                cmd.ExecuteNonQuery();
                SqlCommand sqlCommand = new SqlCommand("UPDATE Kitaplarr SET KitapDurumu=@durum WHERE KitapID=@kitıd", baglanti);
                sqlCommand.Parameters.AddWithValue("@durum", "Disarida");
                sqlCommand.Parameters.AddWithValue("@kitıd", Convert.ToInt32(textBox2.Text));
                sqlCommand.ExecuteNonQuery();
                GetirKitap();
                MessageBox.Show("Kitap iade edildi");
                
            }
            //hata durumunda verilecek mesaj 
            catch (Exception ex)
            {
                MessageBox.Show("BİR HATA OLUŞTU");
                baglanti.Close();
            }
            finally
            {
                baglanti.Close();
            }


        }


        private void button2_Click_1(object sender, EventArgs e)
            // butona basıldığında üyeleri listeleyen kod
        {
            dataAdapter = new SqlDataAdapter("SELECT *  FROM Uyeler ", baglanti);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PersonelİadeEt_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            GetirKitap();
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();

        }
    }
}
