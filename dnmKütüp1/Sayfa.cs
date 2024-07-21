using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dnmKütüp1
{
    internal class Sayfa
    {


        public string dosyaS;
        public void dosyaOluştur()
        {
            Console.WriteLine("Oluşturulacak dosyanın adını tekrardan giriniz");
            dosyaS = Console.ReadLine() + ".txt";
            if (File.Exists(dosyaS) != true)
            {

                File.Create(dosyaS);
                Console.WriteLine("\n---DOSYA OLUŞTURULDU---\n");
            }
            else
            {
                // varmiDosya(dosyaS);
                Console.WriteLine("\n---BÖYLE BİR DOSYA MEVCUT---\n");


            }
        }



        public bool varmiDosya(string sayfaD)
        {
            bool sonuc = false;
            if (File.Exists(sayfaD) == true)
            {
                sonuc = true;
            }
            return sonuc;

        }


        public void Ekle(string metin)
        {
            StreamWriter yazılacakN = new StreamWriter(dosyaS, true);
            yazılacakN.WriteLine(metin);
            yazılacakN.Close();
        }


        public void syfOluştur()
        {
            Console.WriteLine("Metin giriniz...>");
            string metin = Console.ReadLine();

            string[] kelimeler = metin.Split(' ');


            if (kelimeler.Length <= 200)
            {
                Ekle(metin);
                Console.WriteLine("\n----SAYFA OLUŞTURULDU----\n");

            }
            else
            {

                Console.WriteLine("\n---SAYFA OLUŞTURULAMADI---- NOT:En fazla 200 kelime yazabilirsiniz!!!\n");
            }


        }

    }

}



