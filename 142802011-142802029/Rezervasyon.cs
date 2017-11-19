using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _142802011_142802029
{
    public class Rezervasyon
    {
        public List<Bilet> Biletler { get; set; }
        public int YolcuSayisi { get; set; }
        public Rezervasyon()
        {
            this.Biletler = new List<Bilet>();
        }
        public void RezervasyonEkle(Bilet b)
        {
            Biletler.Add(b);
        }
        public string RezervasyonListele()
        {
            string mesaj = "";
            foreach (var b in Biletler)
            {
                mesaj += "\nBilet No:" + b.BiletNoOlustur().ToString() +
                        "\nYolcu Sayisi:" + this.YolcuSayisi.ToString() +
                        "\nKalkis:" + b.Kalkis +
                        "\nVaris:" + b.Varis +
                        "\nGidis Tarihi:" + b.GidisTarihi.ToShortDateString() +
                        "\nDönüs Tarihi:" + b.DönüsTarihi.ToShortDateString() +
                        "\nAd:" + b.Ad +
                        "\nSoyad:" + b.Soyad +
                        "\nTC Kimlik No:" + b.TCNo.ToString() +
                        "\nÖdeme Tipi:" + b.OdemeTipi +
                        "\nFiyat:" + b.Fiyat.ToString() + "TL" +
                        "\nBilet Tipi:" + b.BiletTipi() +
                        "\nYön Tipi:" + b.YonTipi + Environment.NewLine;
            }
            return mesaj;
        }
    }
}
