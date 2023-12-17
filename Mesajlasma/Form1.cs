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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti=new SqlConnection(@"Data Source=DESKTOP-A21VQ07\SQLEXPRESS;Initial Catalog=Mesajlasma;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kisiler where NUMARA=@p1 AND SIFRE=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", mskNo.Text);
            komut.Parameters.AddWithValue("@p2",txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form2 frm=new Form2();
                frm.numara=mskNo.Text;
                frm.Show();
            }
            else
            {
                MessageBox.Show("Hatalı giriş yaptınız");
            }
            baglanti.Close();
        }
    }
}
