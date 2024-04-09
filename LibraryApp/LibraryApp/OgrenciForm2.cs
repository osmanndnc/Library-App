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
using LibraryApp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;

namespace LibraryApp
{
    public partial class OgrenciForm2 : Form
    {

        SqlDataAdapter adap;
        SqlDataAdapter adap1;
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-B024QRDP;Initial Catalog=KutuhaneVTYS;Integrated Security=True; TrustServerCertificate = true");
        public string yazı;

        void Getir()
        {
            // SP_LISTELE adında sp yi çağıran fonksiyon

            SqlCommand sqlCommand = new SqlCommand("SP_LISTELE", baglanti);
            adap = new SqlDataAdapter(sqlCommand);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        void Getir1()
        {
            //üye id sine göre kitapları getiren fonksiyon

            int uyeID;
            if (!int.TryParse(textBox8.Text, out uyeID))
            {
                MessageBox.Show("Üye Bulunamadı");
                return;
            }
            adap1 = new SqlDataAdapter("SELECT * FROM Odunc WHERE UyeID = @UyeID", baglanti);
            adap1.SelectCommand.Parameters.AddWithValue("@UyeID", uyeID);

            DataTable tablo = new DataTable();
            adap1.Fill(tablo);
            dataGridView2.DataSource = tablo;
        }
        void RastgeleKitap()
        {
            //rastgele kitap öneren fonksiyon
            baglanti.Open();    
            SqlCommand sqlCommand = new SqlCommand("sp_RastgeleKitap", baglanti);
            adap = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adap.Fill(dataTable);
            dataGridView3.DataSource = dataTable;
            baglanti.Close();
        }
        


        public OgrenciForm2()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Getir();

        }
        DateTime altar = DateTime.Now;//alım tarihi değişkeni
        DateTime testar = DateTime.Now.AddMonths(1);// teslim tarihi değişkeni 
        private void button2_Click(object sender, EventArgs e)
        {
            //rafta olan kitapları kullanıcının ödünç almasınını sağlayan kodlar 
            baglanti.Open();
            if (textBox7.Text == "Disarida")
            {
                MessageBox.Show("Kitap kütüphanede olmadığı için alamazsınız!");
                baglanti.Close();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO  Odunc (AlimTarihi,TeslimTarihi,UyeID,KitapID) VALUES (@Altar,@Ttar,@UyeID,@KitapID)", baglanti);
                cmd.Parameters.AddWithValue("@Altar", altar);
                cmd.Parameters.AddWithValue("@Ttar", testar);
                cmd.Parameters.AddWithValue("@UyeID", Convert.ToInt32(textBox8.Text));
                cmd.Parameters.AddWithValue("@KitapID", Convert.ToInt32(textBox1.Text));
                cmd.ExecuteNonQuery();
        
                Getir();
                Getir1();
                textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                baglanti.Close();
            }


        }



        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //datagridview deki bilgileri textboclara aktaran kodlar 
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //kitabı iade etmek için gerekli kodlar 
            baglanti.Open();
            SqlCommand cmdsil = new SqlCommand("DELETE FROM Odunc WHERE KitapID=@Odunc", baglanti);
            cmdsil.Parameters.AddWithValue("@Odunc", textBox1.Text);         
            cmdsil.ExecuteNonQuery();
            Getir1();
            Getir();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            baglanti.Close();

        }

        private void OgrenciForm2_Load(object sender, EventArgs e)
        {
            
            textBox8.Text = yazı;
            Getir1();
            Getir();
            RastgeleKitap();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox1.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //checkboxlara göre yazara veya kitap ismine göre sp leri kullanarak arama yapan kodlar 
            try
            {

                baglanti.Open();

                if (checkBox1.Checked)
                {
                    SqlCommand cmd = new SqlCommand("sp_KitapAra", baglanti);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aramakelimesi", textBox10.Text);
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adap.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;

                    baglanti.Close();
                }
                else if (checkBox2.Checked)
                {
                    SqlCommand cmd = new SqlCommand("sp_Yazaragoreara", baglanti);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aranankelime", textBox10.Text);
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adap.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    baglanti.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA");
            }
        }
        
        //checkbox lardan sadece birinin seçilmesini sağlayan kodlar
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            CheckBox selectedCheckBox = sender as CheckBox;

            if (selectedCheckBox.Checked)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox selectedCheckBox = sender as CheckBox;

            if (selectedCheckBox.Checked)
            {
                checkBox1.Checked = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //kullanıcının aldığı kitabın gününü uzatması için gerekli kodlar 
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("sp_GunUzat",baglanti);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@kitapid",textBox1.Text);
            cmd.ExecuteNonQuery(); 
            MessageBox.Show("Kitabın iade günü 10 gün uzatıldı");
            Getir1();
            baglanti.Close();
        }
    }
}


