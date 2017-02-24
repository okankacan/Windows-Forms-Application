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
    public partial class Faturalar : Form
    {
        public string VeriTut;
        public Faturalar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            faturaGirisi faturaGir = new faturaGirisi();
            faturaGir.Show();
        }

        private void Faturalar_Load(object sender, EventArgs e)
        {
            FaturaBilgileriAl();
        }

        public void FaturaBilgileriAl()
        {
            SqlConnection Baglanti = new SqlConnection(Model.Model.conStr);
            Baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * from faturalar", Baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            Baglanti.Close();
            Baglanti.Dispose();
            dataGridView1.Columns[0].HeaderText = "Fatura ID";
            dataGridView1.Columns[1].HeaderText = "Ürün Adı";
            dataGridView1.Columns[2].HeaderText = "Ürün Adet";
            dataGridView1.Columns[3].HeaderText = "Müşteri ";
            dataGridView1.Columns[4].HeaderText = "Toplam Fiyat ";
            dataGridView1.Columns[5].HeaderText = "Fatura No ";
            dataGridView1.Columns[6].HeaderText = "Tarih ";
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Red;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                VeriTut = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();

                
                DialogResult secenek = MessageBox.Show("Faturayı Silmek Üzeresiniz Emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNoCancel);
                if (secenek == DialogResult.Yes)
                {

                    var result = FaturaIslem.FaturaSil(Convert.ToInt32(VeriTut.ToString()));
                    if (result == true)
                    {

                        FaturaBilgileriAl();
                    }
                }

            }
            catch (Exception)
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VeriTut = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            if (VeriTut != null)
            {
                FaturaDuzenle FaturaDuzen = new FaturaDuzenle();
                FaturaDuzen.Show();
            }
            else
            {
                MessageBox.Show("Önce fatura ait satırından bir değer seçin", "Hata Mesajı");
            }
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
                        whereKosulu += "MusteriKimlik LIKE '" + item.ToUpper() + "%' OR FaturaNo LIKE '" + item.ToUpper() + "%' OR tarih LIKE '" + item.ToUpper() +  "%'";
                    }
                    else
                    {
                        whereKosulu += "MusteriKimlik LIKE '" + item.ToUpper() + "%' OR FaturaNo LIKE '" + item.ToUpper() + "%' OR tarih LIKE '" + item.ToUpper() + "%'";
                    }
                }
                else
                {
                    if ((i + 1) == keywordList.Count)
                    {
                        whereKosulu += "MusteriKimlik LIKE '" + item.ToUpper() + "%' OR FaturaNo LIKE '" + item.ToUpper() + "%' OR tarih LIKE '" + item.ToUpper() + "%'";
                    }
                    else
                    {
                        whereKosulu += "MusteriKimlik LIKE '" + item.ToUpper() + "%' OR FaturaNo LIKE '" + item.ToUpper() + "%' OR tarih LIKE '" + item.ToUpper() + "%'";
                    }
                }
            }
            SqlConnection Baglanti = new SqlConnection(Model.Model.conStr);
            Baglanti.Open();
            var sorgu22 = "SELECT * FROM faturalar where " + whereKosulu + "Order By FutaraID DESC";
            SqlCommand listr = new SqlCommand(sorgu22, Baglanti);
            SqlDataAdapter da = new SqlDataAdapter(listr);
            DataTable dtTR = new DataTable();
            da.Fill(dtTR);
            dataGridView1.DataSource = dtTR;
            Baglanti.Close();
            Baglanti.Dispose();
            dataGridView1.Columns[0].HeaderText = "Fatura ID";
            dataGridView1.Columns[1].HeaderText = "Ürün Adı";
            dataGridView1.Columns[2].HeaderText = "Ürün Adet";
            dataGridView1.Columns[3].HeaderText = "Müşteri ";
            dataGridView1.Columns[4].HeaderText = "Toplam Fiyat ";
            dataGridView1.Columns[5].HeaderText = "Fatura No ";
            dataGridView1.Columns[6].HeaderText = "Tarih ";
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Red;

        }
    }
}
