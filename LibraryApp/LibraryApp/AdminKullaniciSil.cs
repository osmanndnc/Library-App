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
using System.Runtime.CompilerServices;

namespace LibraryApp
{
    public partial class AdminKullaniciSil : Form
    {
        //sql baglantısı
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-B024QRDP;Initial Catalog=KutuhaneVTYS;Integrated Security=True; TrustServerCertificate = true");
        SqlDataAdapter adap;       
        public AdminKullaniciSil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //kullanıcı silme işini  yapan kod
            
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Uyeler WHERE UyeID=@ıd", baglanti);
            cmd.Parameters.AddWithValue("@ıd", Convert.ToInt32(textBox1.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kullanıcı Silindi");
            baglanti.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //veritabanından kullanıcıları çekip datagridview e yazan kod
            baglanti.Open();
            adap = new SqlDataAdapter("SELECT * FROM Uyeler", baglanti);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void AdminKullaniciSil_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
