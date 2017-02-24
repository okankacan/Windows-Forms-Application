using ProjeFaturalama.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProjeFaturalama.controller
{
    public class Musteriler
    {
        public static bool MusteriEkle(string adi, string soyadi, string tel, string adres)
        {
            bool result = false;
            string sorgu = "insert into MusteriBilgileri VALUES (@adi,@soyadi,@tel,@adres)";
            SqlConnection Baglanti = new SqlConnection(Model.Model.conStr);
            SqlCommand komut = new SqlCommand(sorgu, Baglanti);
            komut.Parameters.AddWithValue("@adi", adi);
            komut.Parameters.AddWithValue("@soyadi", soyadi);
            komut.Parameters.AddWithValue("@tel", tel);
            komut.Parameters.AddWithValue("@adres", adres);
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

        public static MusteriBilgileri MusteriSelect(string IdAl)
        {
            MusteriBilgileri item = new MusteriBilgileri();
            try
            {
                SqlConnection Baglanti = new SqlConnection(Model.Model.conStr);
                string sorgu = "select * from MusteriBilgileri where MusteriKimlik=" + Convert.ToInt32(IdAl);
                SqlCommand komut = new SqlCommand(sorgu, Baglanti);
                Baglanti.Open();
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    item.adi = oku["adi"].ToString();
                    item.soyadi = oku["soyadi"].ToString();
                    item.tel = oku["tel"].ToString();
                    item.adres = oku["adres"].ToString();
                }
                oku.Close();
                Baglanti.Close();
                Baglanti.Dispose();

             

            }
            catch (Exception)
            { }

            return item;

        }

        public static bool MusteriDuzenle(int id, string adi, string soyadi, string tel, string adres)
        {
            bool result = false;

            string sorgu = "update MusteriBilgileri set adi = @adi, soyadi = @soyadi, tel = @tel, adres = @adres where MusteriKimlik = " + id + "";
            SqlConnection Baglanti = new SqlConnection(Model.Model.conStr);
            SqlCommand komut = new SqlCommand(sorgu, Baglanti);
            komut.Parameters.AddWithValue("@adi", adi);
            komut.Parameters.AddWithValue("@soyadi", soyadi);
            komut.Parameters.AddWithValue("@tel", tel);
            komut.Parameters.AddWithValue("@adres", adres);
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

        public static bool MusteriSil(int id)
        {
            bool result = false;

            string musterisil = "Delete from MusteriBilgileri where MusteriKimlik=@MusteriKimlik";
            SqlConnection Baglanti = new SqlConnection(Model.Model.conStr);
            SqlCommand komut1 = new SqlCommand(musterisil, Baglanti);
            komut1.Parameters.AddWithValue("@MusteriKimlik", id);
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
