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
    public partial class AdminKitapSil : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-B024QRDP;Initial Catalog=KutuhaneVTYS;Integrated Security=True ; TrustServerCertificate = true");
        public AdminKitapSil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adap = new SqlDataAdapter("select * from Kitaplarr",baglanti);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "Disarida")
            {
                MessageBox.Show("HATA");
            }
            else
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Kitaplarr WHERE KitapID=@id",baglanti);
                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.ExecuteNonQuery();
                baglanti.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void AdminKitapSil_Load(object sender, EventArgs e)
        {

        }
    }
}
