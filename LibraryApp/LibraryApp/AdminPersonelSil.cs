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
    public partial class AdminPersonelSil : Form
    {   //sql bağlantısı
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-B024QRDP;Initial Catalog=KutuhaneVTYS;Integrated Security=True; TrustServerCertificate = true");
        SqlDataAdapter dataAdapter;
        public AdminPersonelSil()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //personel silmek için gerekli kod 
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Personeller WHERE PersonelID= @pıd",baglanti);
            cmd.Parameters.AddWithValue("@pıd",Convert.ToInt32(textBox1.Text));
            MessageBox.Show("PERSSONEL SİLİNDİ");
            cmd.ExecuteNonQuery();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //personelleri listeleme için gerekli kod
            dataAdapter= new SqlDataAdapter("SELECT * FROM Personeller ",baglanti);
            DataTable dt = new DataTable(); 
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void AdminPersonelSil_Load(object sender, EventArgs e)
        {
            
        }
    }
}
