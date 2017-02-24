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
    public partial class Form2 : Form
    {
        public string VeriTut;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            musterikayit Musteri = new musterikayit();
            Musteri.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            VeriTut = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            if (VeriTut != null)
            {
                MusteriDuzenle MusteriDuzelt = new MusteriDuzenle();
                MusteriDuzelt.Show();
            }
            else
            {
                MessageBox.Show("Önce Müşterinize ait satırından bir değer seçin", "Hata Mesajı");
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

                    var result = Musteriler.MusteriSil(Convert.ToInt32(VeriTut.ToString()));
                    if (result == true)
                    {

                        MusteriBilgileriCek();
                    }
                }

            }
            catch (Exception)
            { }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;

            try
            {
                if ((textBox1.Text == "") || (textBox1.Text == " "))
                {
                    MusteriBilgileriCek();

                }
                else
                {

                }
            }
            catch (Exception)
            { 
            }
        }

        public void MusteriBilgileriCek()
        {
           
            SqlConnection Baglanti = new SqlConnection(Model.Model.conStr);
            Baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * from MusteriBilgileri", Baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            Baglanti.Close();
            Baglanti.Dispose();
            dataGridView1.Columns[0].HeaderText = "Müşteri Kimlik";
            dataGridView1.Columns[1].HeaderText = "Müşteri Adı";
            dataGridView1.Columns[2].HeaderText = "Müşteri Soyadı";
            dataGridView1.Columns[3].HeaderText = "Telefon No";
            dataGridView1.Columns[4].HeaderText = "Müşteri Adres";
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
                        whereKosulu += "adi LIKE '" + item.ToUpper() + "%' OR soyadi LIKE '" + item.ToUpper() + "%' OR tel LIKE '" + item.ToUpper() + "%' OR adres LIKE '" + item.ToUpper() + "%'";
                    }
                    else
                    {
                        whereKosulu += "adi LIKE '" + item.ToUpper() + "%' OR soyadi LIKE '" + item.ToUpper() + "%' OR tel LIKE '" + item.ToUpper() + "%' OR adres LIKE '" + item.ToUpper() + "%'";
                    }
                }
                else
                {
                    if ((i + 1) == keywordList.Count)
                    {
                        whereKosulu += "adi LIKE '" + item.ToUpper() + "%' OR soyadi LIKE '" + item.ToUpper() + "%' OR tel LIKE '" + item.ToUpper() + "%' OR adres LIKE '" + item.ToUpper() + "%'";
                    }
                    else
                    {
                        whereKosulu += "adi LIKE '" + item.ToUpper() + "%' OR soyadi LIKE '" + item.ToUpper() + "%' OR tel LIKE '" + item.ToUpper() + "%' OR adres LIKE '" + item.ToUpper() + "%'";
                    }
                }
            }
            SqlConnection Baglanti = new SqlConnection(Model.Model.conStr);
            Baglanti.Open();
            var sorgu22 = "SELECT * FROM MusteriBilgileri where " + whereKosulu + "Order By MusteriKimlik DESC";
            SqlCommand listr = new SqlCommand(sorgu22, Baglanti);
            SqlDataAdapter da = new SqlDataAdapter(listr);
            DataTable dtTR = new DataTable();
            da.Fill(dtTR);
            dataGridView1.DataSource = dtTR;
            Baglanti.Close();
            Baglanti.Dispose();
            dataGridView1.Columns[0].HeaderText = "Müşteri Kimlik";
            dataGridView1.Columns[1].HeaderText = "Müşteri Adı";
            dataGridView1.Columns[2].HeaderText = "Müşteri Soyadı";
            dataGridView1.Columns[3].HeaderText = "Telefon No";
            dataGridView1.Columns[4].HeaderText = "Müşteri Adres";
 

            dataGridView1.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Red;

        }
    }
}
