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
using System.Data.SqlClient;
namespace LibraryApp
{
    public partial class AdminSüreUzat : Form
    {
        //sql bağlantısı
        SqlConnection baglanti= new SqlConnection("Data Source=LAPTOP-B024QRDP;Initial Catalog=KutuhaneVTYS;Integrated Security=True; TrustServerCertificate = true");
        SqlDataAdapter adap;
        public AdminSüreUzat()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //view ile dışarıda olan kitapları listeleyen kod
            baglanti.Open();
            adap = new SqlDataAdapter("SELECT * FROM DisaridaOlanKitaplarView", baglanti);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //sp ile kitabın gününü uzatan kod
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("sp_GunUzat", baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@kitapid", textBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kitabın iade günü 10 gün uzatıldı");
            baglanti.Close();
        }

        private void AdminSüreUzat_Load(object sender, EventArgs e)
        {

        }
    }
}
