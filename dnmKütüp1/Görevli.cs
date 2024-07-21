using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dnmKütüp1
{
    internal class Görevli
    {

        public string dosyaYG = "Görevlilerim.txt";


        public void Ekle(string satır)
        {
            StreamWriter yazılacakN = new StreamWriter(dosyaYG, true);
            yazılacakN.WriteLine(satır);
            yazılacakN.Close();

        }

        public bool varMi(string ad, string soyad, string sifre)
        {
            StreamReader okunacakN = new StreamReader(dosyaYG);
            // string satir = "";

            bool sonuc = false;

            while (okunacakN.EndOfStream == false)
            {
                string satır = okunacakN.ReadLine();
                string[] parca = satır.Split('^');

                if ((parca[0] == ad) && (parca[1] == soyad) && parca[4] == sifre)
                    sonuc = true;

            }
            okunacakN.Close();
            return sonuc;


        }

        public bool kontrol(string ad)
        {
            char[] karakter = ad.ToCharArray();
            bool sonuc = false;
            for (int i = 0; i < ad.Length; i++)
            {
                if (Char.IsSymbol(karakter[i]) || Char.IsNumber(karakter[i]))
                {
                    Console.WriteLine("Lütfen Ad kısmını sadece harf kullanarak giriniz");
                    sonuc = true;
                    break;
                }
            }
            return sonuc;
        }


        public bool kontrolS(string soyad)
        {
            char[] karakter = soyad.ToCharArray();
            bool sonuc = false;
            for (int i = 0; i < soyad.Length; i++)
            {
                if (Char.IsSymbol(karakter[i]) || Char.IsNumber(karakter[i]))
                {
                    Console.WriteLine("Lütfen Soyadı kısmını sadece harf kullanarak giriniz");
                    sonuc = true;
                    break;
                }
            }
            return sonuc;
        }

        public bool boşMuG(string değer)
        {

            bool sonuc = false;
            if (string.IsNullOrEmpty(değer))
            {
                Console.WriteLine("Boş geçilemez");
                sonuc = true;
            }

            return sonuc;

        }
        public bool boşMu(string isim, string soyisim,string sifreG)
        {

            bool sonuc = false;
            if (string.IsNullOrEmpty(isim) && string.IsNullOrEmpty(soyisim) && string.IsNullOrEmpty(sifreG))
            {
                Console.WriteLine("Ad, Soyad veya Şifre boş bırakılamaz");
                sonuc = true;
            }

            return sonuc;

        }


        public void bilgiYaz(string adı, string soyadı, string tcsi, string email, string sifre)
        {
            Console.WriteLine("Adınız:" + adı);
            Console.WriteLine("Soyadınız :" + soyadı);
            Console.WriteLine("Kullanıcı Adınız :" + tcsi);
            Console.WriteLine("E-Mail Adresiniz :" + email);
            Console.WriteLine("Şİfreniz :" + sifre);

        }









        public void onay()
        {
            string söz = Console.ReadLine();
            söz = söz.ToUpper();

            switch (söz)
            {
                case "ONAYLA":
                    Console.WriteLine("** EKLENDİ **"); break;
            }

        }

        public void iptal()
        {
            string söz = Console.ReadLine();
            söz = söz.ToUpper();

            switch (söz)
            {
                case "ONAYLAMA":
                    Console.WriteLine("**! REDDEDİLDİ !**"); break;
            }

        }
    }
}
