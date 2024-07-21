using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dnmKütüp1
{
    internal class Kitap
    {
        public void BirlestirVeKaydet(List<string> dosyaAdlari, string hedefDosyaAdi)
        {
            List<string> icerikler = new List<string>();

            // Dosyaların içeriğini okuyup birleştirme
            foreach (string dosyaAdi in dosyaAdlari)
            {
                string dosyaIcerik = File.ReadAllText(dosyaAdi);
                icerikler.Add(dosyaIcerik);
            }

            // Birleştirilmiş dosyayı oluşturup yazma
            string hedefDosyaYolu = Path.Combine(Environment.CurrentDirectory, hedefDosyaAdi);
            File.WriteAllText(hedefDosyaYolu, string.Join(Environment.NewLine, icerikler));

            Console.WriteLine("Yazarın Adı :");
            string yazar = Console.ReadLine();
            Console.WriteLine("Yazarın Soyadı:");
            string yazarsoyad = Console.ReadLine();
            Console.WriteLine("Kitabın Adı :");
            string adı = Console.ReadLine();

            string satırcık = yazar + "/" + yazarsoyad + "/" + adı;
            EkleK(satırcık);
            Console.WriteLine("Bilgileriniz Kaydedilmiştir\n");
            Console.WriteLine("Dosyalar birleştirildi ve yeni dosya oluşturuldu.\n");

            Console.WriteLine("Bilgi almak ister misin? -E-  -H- \n");
            char answer = Convert.ToChar(Console.ReadLine());
            answer = char.ToUpper(answer);

            switch (answer)
            {
                case 'E':
                    bilgiAl(yazar, yazarsoyad, adı);
                    break;
                case 'H':
                    //bu kısıma contınue gelebilir ona göre bir bak
                    break;
            }


        }



        public List<string> DosyaAdAl()
        {
            List<string> dosyaAdlari = new List<string>();

            Console.WriteLine("Birleştirmek istediğiniz dosya yolunu girin (Çıkmak için boş bırakın):");

            while (true)
            {
                Console.Write("Dosya adı (boş bırakıp ENTER'a basın): ");
                string dosyaAdi = Console.ReadLine();

                if (string.IsNullOrEmpty(dosyaAdi))
                {
                    break; // Kullanıcı boş giriş yaparsa döngüden çık
                }

                if (File.Exists(dosyaAdi) == true)
                {
                    dosyaAdlari.Add(dosyaAdi);
                }
                else
                {
                    Console.WriteLine($"'{dosyaAdi}' adında bir dosya bulunamadı.");
                }
            }

            return dosyaAdlari;
        }


        public bool bilgiAl(string adı, string soyad, string kitapadı)
        {
            StreamReader okunacakN = new StreamReader(dosyaK);
            string satir = "";

            bool sonuc = false;

            while (okunacakN.EndOfStream == false)
            {

                string satır = okunacakN.ReadLine();
                string[] parcam = satır.Split('*');

                if ((parcam[0] == adı) && (parcam[1] == soyad) & parcam[2] == kitapadı)
                {
                    if (sonuc = true) { Console.WriteLine("Yazar :" + adı + soyad); Console.WriteLine("Kitap Adı :" + kitapadı); }
                }
                else
                    Console.WriteLine("Yanlış Bilgi");


            }
            okunacakN.Close();
            return sonuc;

        }


        public string dosyaK = "kkbilgileri.txt";
        public void EkleK(string satır)
        {

            StreamWriter yazılacakN = new StreamWriter(dosyaK, true);
            yazılacakN.WriteLine(satır);
            yazılacakN.Close();
        }


        public string dosyaYol = "gKitaplar.txt";
        Görevli göv = new Görevli();

         public void ekleK(string sat)
        {

            StreamWriter yazılacakN = new StreamWriter(dosyaYol, true);
            yazılacakN.WriteLine(sat);
            yazılacakN.Close();
        }

        public void Listele()
        {
            StreamReader oku = new StreamReader(dosyaK);
            string içerik = "";
            while (oku.EndOfStream == false)
            {
                içerik += oku.ReadLine();
            }
            oku.Close();
        }

        public void KitapAl(string kitapadı)
        {
            Console.WriteLine("--GÖREVLİYE YÖNLENDİRİLİYORSUNUZ--");
            Console.Beep(500, 3000);
            Console.Write(" Görevli Adı :");
            string ad = Console.ReadLine();
            Console.Write("Soyadı :");
            string soyad = Console.ReadLine();
            Console.Write("Şifre :");
            string sfr = Console.ReadLine();
            göv.varMi(ad, soyad, sfr);

            //aa/bb/cc
            //dd/vv/ıı

            string[] parcalar = File.ReadAllLines(dosyaYol, Encoding.Default);
            File.Delete(dosyaYol);
            StreamWriter yaz = File.AppendText(dosyaYol);
            Console.WriteLine("Onaylamak ister misiniz");
            string cevap = Console.ReadLine();
            if (cevap == "ONAY")
            {
                for (int i = 0; i < parcalar.Length; i++)
                {



                    if ((parcalar[i].Split('*')[0].ToString() != kitapadı))
                    {
                        yaz.WriteLine(parcalar[i]);
                        Console.WriteLine("Kayıtlarda böyle bir kitap yok.");
                    }


                }
                yaz.Close();
            }
            else
                Console.WriteLine("ONAYLANMADI");




        }






    }
}
