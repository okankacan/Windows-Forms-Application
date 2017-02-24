using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjeFaturalama.Model
{
    public class MusteriBilgileri
    {
        private int MusteriKimlik_;
        public int MusteriKimlik
        {
            get { return this.MusteriKimlik_; }
            set { this.MusteriKimlik_ = value; }
        }

        private string adi_;
        public string adi
        {
            get { return this.adi_; }
            set { this.adi_ = value; }
        }

        private string soyadi_;
        public string soyadi
        {
            get { return this.soyadi_; }
            set { this.soyadi_ = value; }
        }

        private string tel_;
        public string tel
        {
            get { return this.tel_; }
            set { this.tel_ = value; }
        }

        private string adres_;
        public string adres
        {
            get { return this.adres_; }
            set { this.adres_ = value; }
        }
    }
 
}
