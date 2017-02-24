using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjeFaturalama.Model
{
    public class UrunBilgileri
    {
        private int UrunID_;
        public int UrunID
        {
            get { return this.UrunID_; }
            set { this.UrunID_ = value; }
        }

        private string urunAdi_;
        public string urunAdi
        {
            get { return this.urunAdi_; }
            set { this.urunAdi_ = value; }
        }

        private string urunAciklama_;
        public string urunAciklama
        {
            get { return this.urunAciklama_; }
            set { this.urunAciklama_ = value; }
        }

        private decimal UrunFiyati_;
        public decimal UrunFiyati
        {
            get { return this.UrunFiyati_; }
            set { this.UrunFiyati_ = value; }
        }
    }
}
