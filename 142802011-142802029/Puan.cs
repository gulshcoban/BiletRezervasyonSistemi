using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _142802011_142802029
{
    public class Puan : OdemeTipi
    {
        public override string Odeme()
        {
            throw new NotImplementedException();
        }
        public decimal Puanlar { get; set; }
        public Bilet Bilet { get; set; }

        public Puan(Bilet b)
        {
            this.Bilet = b;
        }
        public decimal PuanHesapla()
        {
            this.Puanlar += Bilet.Fiyat / 1000;
            return Puanlar;
        }
    }
}
