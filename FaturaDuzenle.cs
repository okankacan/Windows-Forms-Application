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
    public partial class FaturaDuzenle : Form
    {
        public FaturaDuzenle()
        {
            InitializeComponent();
        }

        private void FaturaDuzenle_Load(object sender, EventArgs e)
        {
            Faturalar f2 = (Faturalar)Application.OpenForms["Faturalar"];
            int id = Convert.ToInt32(f2.VeriTut);

            var dt = FaturaIslem.UrunBilgileri();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "urunAdi";
            comboBox1.ValueMember = "UrunFiyati";

     

            var item = FaturaIslem.FaturaSelect(id);
            if (item != null)
            {
                textBox1.Text = item.MusteriKimlik.ToString();
                textBox1.Enabled = false;
                textBox3.Text = item.UrunAdet.ToString();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
 

                Faturalar f2 = (Faturalar)Application.OpenForms["Faturalar"];
                int id = Convert.ToInt32(f2.VeriTut);
                var item = FaturaIslem.FaturaSelect(id);
                var toplam = Convert.ToDecimal(comboBox1.SelectedValue.ToString()) * Convert.ToDecimal(textBox3.Text);
                var result = FaturaIslem.FaturaDuzenle(id, comboBox1.Text,Convert.ToInt32(textBox3.Text), textBox1.Text, toplam,item.FaturaNo,item.tarih);
                if (result == true)
                {
                    Faturalar f1 = (Faturalar)Application.OpenForms["Faturalar"];
                    f1.FaturaBilgileriAl();
                    this.Close();
                }
            }
            catch (Exception)
            { this.Close(); }
         
        }
    }
}
