using ProjeFaturalama.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProjeFaturalama.controller
{
   public class Urun
    {
        public static bool UrunEkle(string urunAdi, string urunAciklama, decimal fiyati)
        {
            bool result = false;
            string sorgu = "insert into urunler VALUES (@urunAdi,@urunAciklama,@UrunFiyati)";
            SqlConnection Baglanti = new SqlConnection(Model.Model.conStr);
            SqlCommand komut = new SqlCommand(sorgu, Baglanti);
            komut.Parameters.AddWithValue("@urunAdi", urunAdi);
            komut.Parameters.AddWithValue("@urunAciklama", urunAciklama);
            komut.Parameters.AddWithValue("@UrunFiyati", fiyati);
            Baglanti.Open();
            try
            {
                result = komut.ExecuteNonQuery() > 0 ? true : false;

            }
            finally
            {
                Baglanti.Close();
                Baglanti.Dispose();
            }
            return result;
        }

        public static UrunBilgileri UrunSelect(string urunID)
        {
            UrunBilgileri item = new UrunBilgileri();
            try
            {
                SqlConnection Baglanti = new SqlConnection(Model.Model.conStr);
                string sorgu = "select * from urunler where UrunID="+ urunID+"";
                SqlCommand komut = new SqlCommand(sorgu, Baglanti);
 
                Baglanti.Open();
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    item.urunAdi = oku["urunAdi"].ToString();
                    item.urunAciklama = oku["urunAciklama"].ToString();
                    item.UrunFiyati = (decimal)oku["UrunFiyati"];

                }
                oku.Close();
                Baglanti.Close();
                Baglanti.Dispose();



            }
            catch (Exception)
            { }

            return item;

        }

        public static bool UrunDuzenle(int urunID, string urunAdi, string urunAciklama, decimal fiyati)
        {
            bool result = false;

            string sorgu = "update urunler set urunAdi = @urunAdi, urunAciklama = @urunAciklama, UrunFiyati = @UrunFiyati where UrunID = " + urunID + "";
            SqlConnection Baglanti = new SqlConnection(Model.Model.conStr);
            SqlCommand komut = new SqlCommand(sorgu, Baglanti);
            komut.Parameters.AddWithValue("@urunAdi", urunAdi);
            komut.Parameters.AddWithValue("@urunAciklama", urunAciklama);
            komut.Parameters.AddWithValue("@UrunFiyati", fiyati);
            Baglanti.Open();
            try
            {
                result = komut.ExecuteNonQuery() > 0 ? true : false;

            }
            finally
            {
                Baglanti.Close();
                Baglanti.Dispose();
            }


            return result;
        }

        public static bool UrunSil(int id)
        {
            bool result = false;

            string musterisil = "Delete from urunler where UrunID=@UrunID";
            SqlConnection Baglanti = new SqlConnection(Model.Model.conStr);
            SqlCommand komut1 = new SqlCommand(musterisil, Baglanti);
            komut1.Parameters.AddWithValue("@UrunID", id);
            Baglanti.Open();
            try
            {
                result = komut1.ExecuteNonQuery() > 0 ? true : false;

            }
            finally
            {
                Baglanti.Close();
                Baglanti.Dispose();
            }

            return result;
        }
    }
}
