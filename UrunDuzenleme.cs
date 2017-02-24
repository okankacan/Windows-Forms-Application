using ProjeFaturalama.controller;
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
    public partial class UrunDuzenleme : Form
    {
        public UrunDuzenleme()
        {
            InitializeComponent();
        }

        private void UrunDuzenleme_Load(object sender, EventArgs e)
        {
            Urunler f2 = (Urunler)Application.OpenForms["Urunler"];
            textBox1.Text = f2.VeriTut.ToString();

            textBox1.Enabled = false;
            var item = Urun.UrunSelect(textBox1.Text);
            if (item != null)
            {
                textBox2.Text = item.urunAdi;
                textBox3.Text = item.urunAciklama;
                textBox5.Text = item.UrunFiyati.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = Urun.UrunDuzenle(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, Convert.ToDecimal(textBox5.Text));
            if (result == true)
            {
                label1.Text = "İstediğiniz Değişiklik Yapıldı";
                Urunler f1 = (Urunler)Application.OpenForms["Urunler"];
                f1.UrunBilgileriAl();
                this.Close();
            }

            else
                label1.Text = "İstediğiniz Değişiklik yapılamadı";
        }

     
    }
}
