namespace Proje2_Bilet_Rezervasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Nereden: " + comboBox1.Text);
            listBox1.Items.Add("Nereye: " + comboBox2.Text);
            listBox1.Items.Add("Tarih: " + dateTimePicker1.Text);
            listBox1.Items.Add("Saat: " + maskedTextBox1.Text);
            listBox1.Items.Add("Ad/Soyad: " + textBox1.Text);
            listBox1.Items.Add("TC NO: " + maskedTextBox2.Text);
            listBox1.Items.Add("Telefon NO: " + maskedTextBox3.Text);
            MessageBox.Show("Yolcu Kaydý Tamamlandý");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label10.Text = comboBox2.Text;
            comboBox2.Text = comboBox1.Text;
            comboBox1.Text = label10.Text;

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}