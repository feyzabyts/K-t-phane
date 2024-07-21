using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dnmKütüp1
{
    internal class Üye
    {

        public string dosyaY = "Üyelerim.txt";


        public void Ekle(string satır)
        {
            StreamWriter yazılacakN = new StreamWriter(dosyaY, true);
            yazılacakN.WriteLine(satır);
            yazılacakN.Close();

        }


        public bool varMi(string kullanıcıAdı, string sifre)
        {
            StreamReader okunacakN = new StreamReader(dosyaY);
            string satir = "";

            bool sonuc = false;

            while (okunacakN.EndOfStream == false)
            {

                string satır = okunacakN.ReadLine();
                string[] parcam = satır.Split('*');

                if ((parcam[2] == kullanıcıAdı) && (parcam[4] == sifre))
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
                    Console.WriteLine("Lütfen Ad ve Soyad kısmında sadece harf giriniz");
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
                    Console.WriteLine("Lütfen Ad ve Soyad kısmında sadece harf giriniz");
                    sonuc = true;
                    break;
                }
            }
            return sonuc;
        }

        public bool boşMu(string değer)
        {

            bool sonuc = false;
            if (string.IsNullOrEmpty(değer))
            {
                Console.WriteLine("Boş geçilemez");
                sonuc = true;
            }

            return sonuc;

        }

        public bool boşMu(string kullancı,string sifre)
        {

            bool sonuc = false;
            if (string.IsNullOrEmpty(kullancı)&& string.IsNullOrEmpty(sifre))
            {
                Console.WriteLine("Kullanıcı Adı veya Şifre boş geçilemez");
                sonuc = true;
            }

            return sonuc;

        }

       
    }
}
