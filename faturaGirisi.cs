using ProjeFaturalama.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjeFaturalama
{
    public partial class faturaGirisi : Form
    {
        public decimal ToplamTutar = 0;
        public faturaGirisi()
        {
            InitializeComponent();
        }

        private void faturaGirisi_Load(object sender, EventArgs e)
        {
            var dt= FaturaIslem.UrunBilgileri();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "urunAdi";
            comboBox1.ValueMember = "UrunFiyati";

            var MusDt = FaturaIslem.MusteriBilgileri();
            comboBox2.DataSource = MusDt;
            comboBox2.DisplayMember = "adi";
            comboBox2.ValueMember = "MusteriKimlik";

            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].HeaderText = "Ürün Adı";
            dataGridView1.Columns[1].HeaderText = "Kaç Adet";
            dataGridView1.Columns[2].HeaderText = "Fiyatı";
            dataGridView1.Columns[3].HeaderText = "Toplam";
 
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.Rows.Add();
            decimal urunFiyati = Convert.ToDecimal(comboBox1.SelectedValue.ToString());

            decimal adet = Convert.ToDecimal(textBox3.Text);

            dataGridView1.Rows[n].Cells[0].Value = comboBox1.Text;
            dataGridView1.Rows[n].Cells[1].Value = textBox3.Text;
            dataGridView1.Rows[n].Cells[2].Value = comboBox1.SelectedValue.ToString();
            dataGridView1.Rows[n].Cells[3].Value = Convert.ToString(urunFiyati * adet);

            ToplamTutar = ToplamTutar + Convert.ToDecimal(dataGridView1.Rows[n].Cells[3].Value);
            label4.Text ="Toplam = "+ ToplamTutar.ToString() + " TL";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Fatura = Guid.NewGuid().ToString();

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                try
                {
                    string urunAdiAl = item.Cells[0].Value.ToString();
                    int adetAl = Convert.ToInt32(item.Cells[1].Value.ToString());
                    string MusteriKim = comboBox2.SelectedValue.ToString();
                    decimal Toplam = Convert.ToDecimal(item.Cells[3].Value);
                    DateTime tarih = DateTime.Now;

                    FaturaIslem.FaturaEkle(urunAdiAl, adetAl, MusteriKim, Toplam, Fatura, tarih);
                    Faturalar FaturaGit = (Faturalar)Application.OpenForms["Faturalar"];
                    FaturaGit.FaturaBilgileriAl();
                }
                catch   { this.Close(); }
               
            }
        }
    }
}
