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

namespace Şirket_Personel_Veri_Tabanı
{
    public partial class FrmGirisEkrani : Form
    {
        public FrmGirisEkrani()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DO¦UKAN\\MSSQLSERVERR;Initial Catalog=SirketPersonelVeriTabani;Integrated Security=True");


        private void FrmGirisEkrani_Load(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand girisekrani = new SqlCommand("Select * from AdminPaneli where KullaniciAd = @k1 and Sifre = @k2", baglanti);

            girisekrani.Parameters.AddWithValue("@k1", textBox1.Text);
            girisekrani.Parameters.AddWithValue("@k2", textBox2.Text);

            SqlDataReader dr1 = girisekrani.ExecuteReader();

            if (dr1.Read())
            {
                Form1 frm = new Form1();

                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre Girdiniz");
            }

            baglanti.Close();
        }
    }
}
