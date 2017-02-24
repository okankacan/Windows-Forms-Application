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
    public partial class Urunler : Form
    {
        public string VeriTut;
        public Urunler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UrunEkleme Urun = new UrunEkleme();
            Urun.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VeriTut = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            if (VeriTut != null)
            {
                UrunDuzenleme UrunDuz = new UrunDuzenleme();
                UrunDuz.Show();
            }
            else
            {
                MessageBox.Show("Önce Ürüne ait satırından bir değerini seçin", "Hata Mesajı");
            }

          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                VeriTut = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();


                DialogResult secenek = MessageBox.Show("Müşterinizi Silmek Üzeresiniz Emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNoCancel);
                if (secenek == DialogResult.Yes)
                {
                    var result = Urun.UrunSil(Convert.ToInt32(VeriTut.ToString()));
                    if (result == true)
                    {
                        Urunler f1 = (Urunler)Application.OpenForms["Urunler"];
                        f1.UrunBilgileriAl();
                       
                    }
                }

            }
            catch (Exception)
            { }


 
        }

        private void Urunler_Load(object sender, EventArgs e)
        {
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;

            try
            {
                if ((textBox1.Text == "") || (textBox1.Text == " "))
                {
                    UrunBilgileriAl();

                }
                else
                {

                }
            }
            catch (Exception)
            {
            }
        }

        public void UrunBilgileriAl()
        {
            SqlConnection Baglanti = new SqlConnection(Model.Model.conStr);
            Baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * from urunler", Baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            Baglanti.Close();
            Baglanti.Dispose();
            dataGridView1.Columns[0].HeaderText = "Ürün ID";
            dataGridView1.Columns[1].HeaderText = "Ürün Adı";
            dataGridView1.Columns[2].HeaderText = "Ürün Açıklama";
            dataGridView1.Columns[3].HeaderText = "Ürün Fiyatı";
            dataGridView1.Columns[3].MinimumWidth = 250;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Red;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<string> keywordList = new List<string>();
            keywordList.Add(textBox1.Text);
            for (int i = 0; i < keywordList.Count; i++)
            {
                string item = keywordList[i];
            }
            string whereKosulu = "";
            for (int i = 0; i < keywordList.Count; i++)
            {
                string item = keywordList[i];
                if (i == 0)
                {
                    if (keywordList.Count == 1)
                    {
                        whereKosulu += "urunAdi LIKE '" + item.ToUpper() + "%' OR UrunFiyati LIKE '" + item.ToUpper() + "%' OR urunAciklama LIKE '" + item.ToUpper() + "%'";
                    }
                    else
                    {
                        whereKosulu += "urunAdi LIKE '" + item.ToUpper() + "%' OR UrunFiyati LIKE '" + item.ToUpper() + "%' OR urunAciklama LIKE '" + item.ToUpper() + "%'";
                    }
                }
                else
                {
                    if ((i + 1) == keywordList.Count)
                    {
                        whereKosulu += "urunAdi LIKE '" + item.ToUpper() + "%' OR UrunFiyati LIKE '" + item.ToUpper() + "%' OR urunAciklama LIKE '" + item.ToUpper() + "%'";
                    }
                    else
                    {
                        whereKosulu += "urunAdi LIKE '" + item.ToUpper() + "%' OR UrunFiyati LIKE '" + item.ToUpper() + "%' OR urunAciklama LIKE '" + item.ToUpper() + "%'";
                    }
                }
            }
            SqlConnection Baglanti = new SqlConnection(Model.Model.conStr);
            Baglanti.Open();
            var sorgu22 = "SELECT * FROM urunler where " + whereKosulu + "Order By UrunID DESC";
            SqlCommand listr = new SqlCommand(sorgu22, Baglanti);
            SqlDataAdapter da = new SqlDataAdapter(listr);
            DataTable dtTR = new DataTable();
            da.Fill(dtTR);
            dataGridView1.DataSource = dtTR;
            Baglanti.Close();
            Baglanti.Dispose();
            dataGridView1.Columns[0].HeaderText = "Ürün ID";
            dataGridView1.Columns[1].HeaderText = "Ürün Adı";
            dataGridView1.Columns[2].HeaderText = "Ürün Açıklama";
            dataGridView1.Columns[3].HeaderText = "Ürün Fiyatı";
            dataGridView1.Columns[3].MinimumWidth = 250;


            dataGridView1.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Red;

        }
    }
}
