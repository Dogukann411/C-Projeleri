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

namespace Şirket_Personel_Veri_Tabanı
{
    public partial class FrmGrafik : Form
    {
        public FrmGrafik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DO¦UKAN\\MSSQLSERVERR;Initial Catalog=SirketPersonelVeriTabani;Integrated Security=True");
        private void FrmGrafik_Load(object sender, EventArgs e)
        {
            //Grafik 1

            baglanti.Open();
            
            SqlCommand graf1 = new SqlCommand("Select PerSehir,count(*) from PersonelBilgi group by PerSehir",baglanti); 

            SqlDataReader g1 = graf1.ExecuteReader();

            while (g1.Read())
            {
                chart1.Series["Şehirler"].Points.AddXY(g1[0], g1[1]);
            }

            baglanti.Close();


        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
