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
using System.Globalization;

namespace Şirket_Personel_Veri_Tabanı
{
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DO¦UKAN\\MSSQLSERVERR;Initial Catalog=SirketPersonelVeriTabani;Integrated Security=True");

        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            //Toplam Personel Sayısı

            baglanti.Open();

            SqlCommand personelsayi = new SqlCommand("Select count(*) from PersonelBilgi",baglanti);

            SqlDataReader dr1 = personelsayi.ExecuteReader();

            while(dr1.Read())
            {
                LblPersonelSayi.Text = dr1[0].ToString();
            }

            baglanti.Close();

            //Erkek Personel Sayısı

            baglanti.Open();

            SqlCommand erkeksayi = new SqlCommand("Select count(*) from PersonelBilgi where PerCinsiyet = 1",baglanti);
            SqlDataReader dr2 = erkeksayi.ExecuteReader();

            while(dr2.Read())
            {
                LblErkek.Text = dr2[0].ToString();
            }

            baglanti.Close();

            //Kız Personel Sayısı

            baglanti.Open();

            SqlCommand kizsayi = new SqlCommand("Select count(*) from PersonelBilgi where PerCinsiyet = 0",baglanti);

            SqlDataReader dr3 = kizsayi.ExecuteReader();

            while(dr3.Read())
            {
                LblKiz.Text = dr3[0].ToString();
            }

            baglanti.Close();
            //Evli Personel Sayısı

            baglanti.Open();

            SqlCommand evlipersonel = new SqlCommand("Select count(*) from PersonelBilgi where PerDurum = 1",baglanti);

            SqlDataReader dr4 = evlipersonel.ExecuteReader();

            while(dr4.Read())
            {
                LblEvli.Text = dr4[0].ToString();
            }

            baglanti.Close();

            //Bekar Personel Sayısı

            baglanti.Open();

            SqlCommand bekarpersonel = new SqlCommand("Select count(*) from PersonelBilgi where PerDurum = 0", baglanti);

            SqlDataReader dr5 = bekarpersonel.ExecuteReader();

            while (dr5.Read())
            {
                LblBekar.Text = dr5[0].ToString();
            }

            baglanti.Close();

            //Şehir Sayısı

            baglanti.Open();

            SqlCommand sehir = new SqlCommand("Select count(distinct(PerSehir)) from PersonelBilgi",baglanti);

            SqlDataReader dr6 = sehir.ExecuteReader();

            while(dr6.Read())
            {
                LblSehir.Text = dr6[0].ToString();
            }

            baglanti.Close();   

            //Personellere Ödenen Toplam Maaşlar

            baglanti.Open();

            SqlCommand odenenmaas = new SqlCommand("Select sum(PerMaas) from PersonelBilgi",baglanti);

            SqlDataReader dr7 = odenenmaas.ExecuteReader();

            while(dr7.Read())
            {
                LblToplamMaas.Text = dr7[0].ToString();
            }

            baglanti.Close();

            //Personellere Ödenen Ortalama Maaşlar

            baglanti.Open();

            SqlCommand ortalamamaas = new SqlCommand("Select avg(PerMaas) from PersonelBilgi",baglanti);

            SqlDataReader dr8 = ortalamamaas.ExecuteReader();

            while (dr8.Read())
            {
                LblOrtMaas.Text = dr8[0].ToString();
            }

            baglanti.Close();

        }
    }
}
