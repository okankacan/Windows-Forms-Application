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
    public partial class UrunEkleme : Form
    {
        public UrunEkleme()
        {
            InitializeComponent();
        }

        private void UrunEkleme_Load(object sender, EventArgs e)
        {

          
        }

        private void UrunEkleme_FormClosed(object sender, FormClosedEventArgs e)
        {
            Urunler Urunler = (Urunler)Application.OpenForms["Urunler"];
            Urunler.UrunBilgileriAl();
            
        } 

        private void button2_Click(object sender, EventArgs e)
        {
            var result = controller.Urun.UrunEkle(textBox2.Text, textBox3.Text, Convert.ToDecimal(textBox5.Text));

            if (result == true)
            {
                label1.Text = "İstediğiniz Değişiklik Yapıldı";
                this.Close();
            }
            else
                label1.Text = "İstediğiniz Değişiklik yapılamadı";
        }
    }
}
