using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _142802011_142802029
{
    public class Tam : Bilet
    {
        public override string BiletTipi()
        {
            string mesaj = "Tam";
            return mesaj;
        }
        public override decimal TekYonFiyat(string kalkis, string varis)
        {
            base.TekYonFiyat(kalkis, varis);
            return this.Fiyat;
        }
        public override decimal CiftYonFiyat(string kalkis, string varis)
        {
            base.CiftYonFiyat(kalkis, varis);
            return (this.Fiyat * 2);
        }
    }
}
