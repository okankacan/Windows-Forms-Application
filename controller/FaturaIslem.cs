using ProjeFaturalama.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProjeFaturalama.controller
{
    public class FaturaIslem
    {
        public static DataTable UrunBilgileri()
        {
            SqlConnection Baglanti = new SqlConnection(Model.Model.conStr);
            DataTable dt = new DataTable();
            try
            {
                
                Baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT * from urunler", Baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
          
            }
            finally 
            {
                Baglanti.Close();
                Baglanti.Dispose();
            }
        

            return dt;
        }

        public static DataTable MusteriBilgileri()
        {
            SqlConnection Baglanti = new SqlConnection(Model.Model.conStr);
            DataTable dt = new DataTable();
            try
            {
                Baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT * from MusteriBilgileri", Baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
            }
            finally 
            {
                Baglanti.Close();
                Baglanti.Dispose();
            }

            return dt;
        }

        public static bool FaturaEkle(string urunAdi, int adet, string MusteriKimlik, decimal ToplamFiyat, string FaturaNo, DateTime Tarih)
        {
            bool result = false;
            string sorgu = "insert into faturalar VALUES (@urunAdi,@adet,@MusteriKimlik,@ToplamFiyat,@FaturaNo,@Tarih)";
            SqlConnection Baglanti = new SqlConnection(Model.Model.conStr);
            SqlCommand komut = new SqlCommand(sorgu, Baglanti);
            komut.Parameters.AddWithValue("@urunAdi", urunAdi);
            komut.Parameters.AddWithValue("@adet", adet);
            komut.Parameters.AddWithValue("@MusteriKimlik", MusteriKimlik);
            komut.Parameters.AddWithValue("@ToplamFiyat", Convert.ToDecimal(ToplamFiyat));
            komut.Parameters.AddWithValue("@FaturaNo", FaturaNo);
            komut.Parameters.AddWithValue("@Tarih", Tarih);
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

        public static bool FaturaSil(int id)
        {
            bool result = false;

            string musterisil = "Delete from faturalar where FutaraID=@FutaraID";
            SqlConnection Baglanti = new SqlConnection(Model.Model.conStr);
            SqlCommand komut1 = new SqlCommand(musterisil, Baglanti);
            komut1.Parameters.AddWithValue("@FutaraID", id);
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

        public static FaturalarBilgileri FaturaSelect(int FutaraID)
        {
            FaturalarBilgileri item = new FaturalarBilgileri();
            try
            {
                SqlConnection Baglanti = new SqlConnection(Model.Model.conStr);
                string sorgu = "select * from faturalar where FutaraID=" + FutaraID + "";
                SqlCommand komut = new SqlCommand(sorgu, Baglanti);

                Baglanti.Open();
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    item.FutaraID = (int)oku["FutaraID"];
                    item.FaturaNo = oku["FaturaNo"].ToString();
                    item.MusteriKimlik = (int)oku["MusteriKimlik"];
                    item.tarih =(DateTime) oku["tarih"];
                    item.ToplamFiyat = (decimal)oku["ToplamFiyat"];
                    item.UrunAdet= (int)oku["UrunAdet"];
                    item.UrunAdi = oku["UrunAdi"].ToString();

                }
                oku.Close();
                Baglanti.Close();
                Baglanti.Dispose();



            }
            catch (Exception)
            { }

            return item;

        }

        public static bool FaturaDuzenle(int id,string urunAdi, int adet, string MusteriKimlik, decimal ToplamFiyat, string FaturaNo, DateTime Tarih)
        {
            bool result = false;

            string sorgu = "update faturalar set UrunAdi = @urunAdi, UrunAdet = @adet, MusteriKimlik = @MusteriKimlik, ToplamFiyat = @ToplamFiyat, FaturaNo=@FaturaNo, tarih=@tarih where FutaraID = " + id + "";

             SqlConnection Baglanti = new SqlConnection(Model.Model.conStr);
            SqlCommand komut = new SqlCommand(sorgu, Baglanti);
            komut.Parameters.AddWithValue("@urunAdi", urunAdi);
            komut.Parameters.AddWithValue("@adet", adet);
            komut.Parameters.AddWithValue("@MusteriKimlik", MusteriKimlik);
            komut.Parameters.AddWithValue("@ToplamFiyat", Convert.ToDecimal(ToplamFiyat));
            komut.Parameters.AddWithValue("@FaturaNo", FaturaNo);
            komut.Parameters.AddWithValue("@Tarih", Tarih);
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

    }
}
