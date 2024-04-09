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
    public partial class PersonelKullaniciSİl : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-B024QRDP;Initial Catalog=KutuhaneVTYS;Integrated Security=True; TrustServerCertificate = true");
        SqlDataAdapter adap;
        public PersonelKullaniciSİl()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //kullanıcıları listeleyen kod 
            adap = new SqlDataAdapter("SELECT * FROM Uyeler",baglanti);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //seçilen kullanıcıyı silen kod 

            baglanti.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Uyeler WHERE UyeID=@ıd", baglanti);
            cmd.Parameters.AddWithValue("@ıd", Convert.ToInt32(textBox1.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kullanıcı Silindi");
            baglanti.Close();
            this.Close();
        }

        private void PersonelKullaniciSİl_Load(object sender, EventArgs e)
        {

        }
    }
}
