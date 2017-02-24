using ProjeFaturalama.controller;
using System;
using System.Windows.Forms;

namespace ProjeFaturalama
{
    public partial class musterikayit : Form
    {
        public musterikayit()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = Musteriler.MusteriEkle(textBox2.Text, textBox3.Text, maskedTextBox1.Text, textBox5.Text);

            if (result == true)
            {
                label1.Text = "İstediğiniz Değişiklik Yapıldı";
                this.Close();
            }
            else
                label1.Text = "İstediğiniz Değişiklik yapılamadı";
        }

        private void musterikayit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form2 f2 = (Form2)Application.OpenForms["Form2"];
            f2.MusteriBilgileriCek();
        }
    }
}
