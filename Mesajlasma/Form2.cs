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

namespace Mesajlasma
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-A21VQ07\SQLEXPRESS;Initial Catalog=Mesajlasma;Integrated Security=True");

        public string numara;

        void gelenkutusu()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("select * from mesajlar where alıcı="+numara,baglanti);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dgvGelen.DataSource = dt1;
        }

        void gidenkutusu()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("select * from mesajlar where gonderen=" + numara, baglanti);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dgvGiden.DataSource = dt2;
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblNumara.Text = numara;

            gelenkutusu();

            gidenkutusu();

            //ad soyadı çekmek
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select ad,soyad from kisiler where numara=" + numara, baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            baglanti.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into mesajlar (gonderen,alıcı,baslık,ıcerık) values (@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            komut.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p3", textBox1.Text);
            komut.Parameters.AddWithValue("p4",richTextBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Mesajınız iletildi.");
            gidenkutusu();
        }
    }
}
