using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjeFaturalama.Model
{
    public class FaturalarBilgileri
    {
        private int FutaraID_;
        public int FutaraID
        {
            get { return this.FutaraID_; }
            set { this.FutaraID_ = value; }
        }

        private string UrunAdi_;
        public string UrunAdi
        {
            get { return this.UrunAdi_; }
            set { this.UrunAdi_ = value; }
        }

        private int UrunAdet_;
        public int UrunAdet
        {
            get { return this.UrunAdet_; }
            set { this.UrunAdet_ = value; }
        }


        private int MusteriKimlik_;
        public int MusteriKimlik
        {
            get { return this.MusteriKimlik_; }
            set { this.MusteriKimlik_ = value; }
        }

        private decimal ToplamFiyat_;
        public decimal ToplamFiyat
        {
            get { return this.ToplamFiyat_; }
            set { this.ToplamFiyat_ = value; }
        }

        private string FaturaNo_;
        public string FaturaNo
        {
            get { return this.FaturaNo_; }
            set { this.FaturaNo_ = value; }
        }

        private DateTime tarih_;
        public DateTime tarih
        {
            get { return this.tarih_; }
            set { this.tarih_ = value; }
        }
    }
}
