using ProjeFaturalama.controller;
using ProjeFaturalama.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjeFaturalama
{
    public partial class MusteriDuzenle : Form
    {
        public MusteriDuzenle()
        {
            InitializeComponent();
        }

        private void MusteriDuzenle_Load(object sender, EventArgs e)
        {
            Form2 f2 = (Form2)Application.OpenForms["Form2"];
            textBox1.Text = f2.VeriTut.ToString();
            textBox1.Enabled = false;
            var item= Musteriler.MusteriSelect(textBox1.Text);
            if (item!=null)
            {
                textBox2.Text = item.adi;
                textBox3.Text = item.soyadi;
                maskedTextBox1.Text = item.tel;
                textBox5.Text = item.adres;
            }
              
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = Musteriler.MusteriDuzenle(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, maskedTextBox1.Text, textBox5.Text);
            if (result == true)
            {
                label6.Text = "İstediğiniz Değişiklik Yapıldı";
                Form2 f1 = (Form2)Application.OpenForms["Form2"];
                f1.MusteriBilgileriCek();
                this.Close();
            }
               
            else
                label6.Text = "İstediğiniz Değişiklik yapılamadı";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Müşterinizi Silmek Üzeresiniz Emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNoCancel);
            if (secenek == DialogResult.Yes)
            {
                var result = Musteriler.MusteriSil(Convert.ToInt32(textBox1.Text));
                if (result == true)
                {
                    label6.Text = "İstediğiniz Değişiklik Yapıldı";
                    Form2 f1 = (Form2)Application.OpenForms["Form2"];
                    f1.MusteriBilgileriCek();
                    this.Close();
                }
            }
        }
    }
}
