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
    public partial class PersonelSüreUzat : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-B024QRDP;Initial Catalog=KutuhaneVTYS;Integrated Security=True; TrustServerCertificate = true");
        SqlDataAdapter adap;
        public PersonelSüreUzat()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //view ile listeleme yapan kodlar 
            baglanti.Open();
            adap = new SqlDataAdapter("SELECT * FROM DisaridaOlanKitaplarView", baglanti);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //sp ile gün uzatan kodlar 
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("sp_GunUzat", baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@kitapid", textBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kitabın iade günü 10 gün uzatıldı");
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PersonelSüreUzat_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
