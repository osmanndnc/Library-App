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
    public partial class AdminİadeEt : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-B024QRDP;Initial Catalog=KutuhaneVTYS;Integrated Security=True; TrustServerCertificate = true");
        SqlDataAdapter dataAdapter;
        public AdminİadeEt()
        {
            InitializeComponent();
        }
        void GetirKitap() //üye id ye göre kitapları getiren fonksiyon
        {
            
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

        private void button2_Click(object sender, EventArgs e)
        {
            dataAdapter = new SqlDataAdapter("SELECT *  FROM Uyeler ", baglanti);//üyeleri listeleyen butonun kodu
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();//kitabı iade edip durumunu rafta olarak güncelleyen butonun kodu
            SqlCommand cmd = new SqlCommand("DELETE FROM Odunc WHERE KitapID=@ıd",baglanti);
            cmd.Parameters.AddWithValue("@ıd", textBox2.Text);
            cmd.ExecuteNonQuery();
            SqlCommand sqlCommand = new SqlCommand("UPDATE Kitaplarr SET KitapDurumu=@durum WHERE KitapID=@kitıd", baglanti);
            sqlCommand.Parameters.AddWithValue("@durum", "Disarida");
            sqlCommand.Parameters.AddWithValue("@kitıd",Convert.ToInt32(textBox2.Text));
            sqlCommand.ExecuteNonQuery();
            GetirKitap();
            baglanti.Close();

            
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();//datagridview e tıklandığında sütündaki değeri textbox a yazan kod
            GetirKitap();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            textBox2.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();//datagridview e tıklandığında sütündaki değeri textbox a yazan kod

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AdminİadeEt_Load(object sender, EventArgs e)
        {

        }
    }
}
