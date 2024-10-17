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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = SABANAKCEHRE\\SABAN; Initial Catalog = ilkDatabese; Integrated Security = True");

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand Komut = new SqlCommand("insert into kisiler (Ad,Soyad,Sehir,Maas,Meslek) values (@k1,@k2,@k3,@k4,@k5) ", baglanti);
            Komut.Parameters.AddWithValue("k1", textBox2.Text);
            Komut.Parameters.AddWithValue("k2", textBox3.Text);
            Komut.Parameters.AddWithValue("k3", comboBox1.Text);
            Komut.Parameters.AddWithValue("k4", textBox4.Text);
            Komut.Parameters.AddWithValue("k5", textBox6.Text);
            Komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi.");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("Delete From kisiler Where ID=@p1",baglanti);
            sil.Parameters.AddWithValue("@p1", textBox1.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // T Bu kod satırı kisiler tablosununu gösterir datagridviewde
            this.kisilerTableAdapter.Fill(this.ilkDatabeseDataSet1.kisiler);
            label8.Visible = false; // label8 i görünmez yaptı .
           

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Listele_Click(object sender, EventArgs e)
        {
            this.kisilerTableAdapter.Fill(this.ilkDatabeseDataSet1.kisiler); // Listeleme Komutu
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Seçtiğimiz dataGridviewdeki bilgiler Personel giriş ekranına yansıtıldı.
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            
            textBox1.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secim].Cells[6].Value.ToString();

            //label8 ile durum bilgisinin False True mi ekrana yazdırıyoruz.
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            //label8 değeri TextChaged özelliği ile radiobuttonlara aktarılıyor . peki aktarıldıktan sonra sabit kalmaması için radio buttonlara da aşağıdaki gibi kod yazdık.
            if (label8.Text == "True") { radioButton2.Checked = true; }
            if (label8.Text == "False") { radioButton1.Checked = true; }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true) { label8.Text = "True"; }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true) { label8.Text = "False"; }
        }

        private void Guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("Update kisiler Set Ad=@p1,Soyad=@p2,Sehir=@p3,Maas=@p4,Durum=@p5,Meslek=@p6 Where ID=@p7",baglanti);
            guncelle.Parameters.AddWithValue("p1", textBox2.Text);
            guncelle.Parameters.AddWithValue("p2", textBox3.Text);
            guncelle.Parameters.AddWithValue("p3", comboBox1.Text);
            guncelle.Parameters.AddWithValue("p4", textBox4.Text);
            guncelle.Parameters.AddWithValue("p5", label8.Text);
            guncelle.Parameters.AddWithValue("p6", textBox6.Text);
            guncelle.Parameters.AddWithValue("p7", textBox1.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Güncellenmesi Tamamlandı.");

        }
        String[] secilenDeger = { "textBox1", "textBox2", "textBox3.Text", "comboBox1", "textBox4", "label8", "textBox6" };
        void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox1.Focus(); // Her şey temizlendikten sonra tekrar id ye oodaklanmaya yarar.
        }
        private void Temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
