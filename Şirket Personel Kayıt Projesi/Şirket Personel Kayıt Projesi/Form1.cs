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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DO¦UKAN\\MSSQLSERVERR;Initial Catalog=SirketPersonelVeriTabani;Integrated Security=True");

        void temizle()
        {
            Txtid.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            CmbSehir.Text = "";
            MskMaas.Text = "";
            TxtBolum.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked= false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.personelBilgiTableAdapter.Fill(this.sirketPersonelVeriTabaniDataSet.PersonelBilgi);

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {

            this.personelBilgiTableAdapter.Fill(this.sirketPersonelVeriTabaniDataSet.PersonelBilgi);

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("insert into PersonelBilgi (PerAd,PerSoyad,PerSehir,PerMaas,PerDurum,PerBolum,PerCinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)",baglanti);
           
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", MskMaas.Text);
            komut.Parameters.Add("@p5", SqlDbType.Bit).Value = radioButton1.Checked;
            komut.Parameters.AddWithValue("@p6", TxtBolum.Text);
            komut.Parameters.Add("@p7",SqlDbType.Bit).Value = radioButton3.Checked;

            komut.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Başarıyla Personel Kaydı Yapılmıştır");
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();

            TxtAd.Focus();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutsil = new SqlCommand("Delete from PersonelBilgi where PerId = @p1", baglanti);
            komutsil.Parameters.AddWithValue("@p1", Txtid.Text);            

            komutsil.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Veri Başarıyla Silinmiştir");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutguncelle = new SqlCommand("Update PersonelBilgi set PerAd = @p1, PerSoyad = @p2, PerSehir = @p3, PerMaas = @p4, PerDurum = @p5, PerBolum = @p6, PerCinsiyet = @p7 where perId = @p8",baglanti);

            komutguncelle.Parameters.AddWithValue("@p1",TxtAd.Text);
            komutguncelle.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@p3", CmbSehir.Text);
            komutguncelle.Parameters.AddWithValue("@p4", MskMaas.Text);
            komutguncelle.Parameters.AddWithValue("@p5", label10.Text);
            komutguncelle.Parameters.AddWithValue("@p6", TxtBolum.Text);
            komutguncelle.Parameters.AddWithValue("@p7", label11.Text);
            komutguncelle.Parameters.AddWithValue("@p8",Txtid.Text);

            komutguncelle.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Güncelleme Başarıyla Yapılmıştır");

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label10.Text = "True";
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label10.Text = "False";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                label11.Text = "True";
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                label11.Text = "False";
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = e.RowIndex;

            Txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label10.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtBolum.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            label11.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();

        }

        private void BtnIstatistik_Click(object sender, EventArgs e)
        {
            FrmIstatistik frm = new FrmIstatistik();
            frm.Show();
        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafik grf = new FrmGrafik();
            grf.Show();
        }
    }
}
