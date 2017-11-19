using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _142802011_142802029
{
    public partial class frmBiletRezervasyon : Form
    {
        public frmBiletRezervasyon()
        {
            InitializeComponent();
        }
        public void BiletBilgisi(Bilet b)
        {
            Rezervasyon r = new Rezervasyon();
            r.YolcuSayisi = Convert.ToInt32(txtYolcuSayi.Text);
            int temp = 0;
            do
            {
                temp++;
                b.Kalkis = cmbNereden.Text;
                b.Varis = cmbNereye.Text;
                b.Ad = txtAd.Text;
                b.Soyad = txtSoyad.Text;
                b.TCNo = Convert.ToInt32(txtTCKimlikNo.Text);
                if (chbTekYön.Checked)
                {
                    b.YonTipi = "Tek Yön";
                    b.GidisTarihi = Convert.ToDateTime(dtpGidisTarihi.Value);
                    lblTutar2.Text = b.TekYonFiyat(b.Kalkis, b.Varis).ToString();
                }
                else if (chbGidisDönüs.Checked)
                {
                    b.YonTipi = "Çift Yön";
                    b.GidisTarihi = Convert.ToDateTime(dtpGidisTarihi.Value);
                    b.DönüsTarihi = Convert.ToDateTime(dtpDönüsTarihi.Value);
                    lblTutar2.Text = b.CiftYonFiyat(b.Kalkis, b.Varis).ToString();
                }
                b.Fiyat = Convert.ToInt32(lblTutar2.Text);
                if (chbEvet.Checked)
                {
                    Puan p = new Puan(b);
                    b.Fiyat = b.Fiyat - p.PuanHesapla();
                    lblTutar2.Text = b.Fiyat.ToString();
                }
                else if (chbHayır.Checked)
                {
                    lblTutar2.Text = b.Fiyat.ToString();
                }
                if (chbNakit.Checked)
                {
                    Nakit n = new Nakit();
                    Bilet b2 = new Bilet(n.Odeme());
                    b.OdemeTipi = b2.OdemeTipi;
                }
                else if (chbKrediKarti.Checked)
                {
                    KrediKarti k = new KrediKarti();
                    Bilet b2 = new Bilet(k.Odeme());
                    b.OdemeTipi = b2.OdemeTipi;
                }
            } while (temp != r.YolcuSayisi);
            r.RezervasyonEkle(b);
            txtBiletler.Text += r.RezervasyonListele();
        }


        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chbTekYön_CheckedChanged(object sender, EventArgs e)
        {
            dtpDönüsTarihi.Enabled = false;
        }

        private void chbGidisDönüs_CheckedChanged(object sender, EventArgs e)
        {
            dtpDönüsTarihi.Enabled = true;
        }

        private void btnBiletAl_Click(object sender, EventArgs e)
        {
            txtBiletler.Visible = true;
            chbTam.Checked = chbOgrenci.Checked = chbTekYön.Checked = chbGidisDönüs.Checked = chbNakit.Checked = chbKrediKarti.Checked = false;
            txtAd.Text = txtSoyad.Text = txtTCKimlikNo.Text = "";
            dtpGidisTarihi.Enabled = true;
            dtpDönüsTarihi.Enabled = true;
            cmbNereden.Text = cmbNereye.Text = "";
            lblTutar2.Text = "";
            txtYolcuSayi.Text = "";
            MessageBox.Show("Bilet alınmıştır...");
        }

        private void btnBiletKayit_Click(object sender, EventArgs e)
        {
            if (chbOgrenci.Checked)
            {
                Ogrenci o = new Ogrenci();
                BiletBilgisi(o);
            }
            else if (chbTam.Checked)
            {
                Tam t = new Tam();
                BiletBilgisi(t);
            }
            MessageBox.Show("Bilgileriniz başarıyla kaydedilmiştir..");
        }
    }
}
