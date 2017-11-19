using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _142802011_142802029
{
    public class Bilet : Yolcu
    {
        public string Kalkis { get; set; }
        public string Varis { get; set; }
        public DateTime GidisTarihi { get; set; }
        public DateTime DönüsTarihi { get; set; }
        public string OdemeTipi { get; set; }
        public decimal Fiyat { get; set; }
        private const decimal HAT1 = 40M;
        private const decimal HAT2 = 50M;
        private const decimal HAT3 = 60M;
        public string YonTipi { get; set; }

        public Bilet()
        {

        }

        public Bilet(string odeme)
        {
            this.OdemeTipi = odeme;
        }

        public int BiletNoOlustur()
        {
            int ID;
            Random rnd = new Random();
            ID = rnd.Next(1, 1000);
            return ID;
        }
        protected decimal FiyatHesapla(string kalkis, string varis)
        {
            if ((kalkis == "İzmir" && varis == "Ankara") || (kalkis == "Ankara" && varis == "İzmir"))
            {
                this.Fiyat = HAT1;

            }
            if ((kalkis == "İzmir" && varis == "İstanbul") || (kalkis == "İstanbul" && varis == "İzmir"))
            {
                this.Fiyat = HAT2;

            }
            if ((kalkis == "İstanbul" && varis == "Ankara") || (kalkis == "Ankara" && varis == "İstanbul"))
            {
                this.Fiyat = HAT3;
            }
            return Fiyat;
        }
        public virtual string BiletTipi()
        {
            string mesaj = "";
            return mesaj;
        }
        public virtual decimal TekYonFiyat(string kalkis, string varis)
        {
            this.Fiyat = FiyatHesapla(kalkis, varis);
            return this.Fiyat;
        }
        public virtual decimal CiftYonFiyat(string kalkis, string varis)
        {
            this.Fiyat = FiyatHesapla(kalkis, varis);
            return this.Fiyat * 2;
        }
    }
}
