using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace dnmKütüp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("KULLANICI-GÖREVLİ");
            string insan = Console.ReadLine();
            insan = insan.ToUpper();

            switch (insan)
            {
                case "KULLANICI":
                    Üye x = new Üye();
                    string ad;
                    string soyad;
                    string kullanıcıAdı;
                    string email;
                    string sifre;
                    string şifretkr;

                    Console.WriteLine("Kayıt(K)-Giriş(G)");
                    char harf = Convert.ToChar(Console.ReadLine());
                    
                    switch (harf)
                    {
                        case 'K'://KAYIT
                            Console.WriteLine("-----KAYIT İŞLEMLERİ----- \n");

                            do
                            {
                                Console.WriteLine("Adınız :");
                                ad = Console.ReadLine();

                                do
                                {
                                    Console.WriteLine("Adınızı tekrardan yazınız :");
                                    ad= Console.ReadLine();
                                }
                                while (x.kontrol(ad) == true);



                            } while (x.boşMu(ad) == true);



                            do
                            {
                                Console.WriteLine("Soyadınız :");
                                soyad = Console.ReadLine();

                                do
                                {
                                    Console.WriteLine("Soyadınızı tekrardan yazınız :");
                                    soyad = Console.ReadLine();
                                }
                                while (x.kontrol(soyad) == true);



                            } while (x.boşMu(soyad) == true);

                            do
                            {
                                Console.Write("Kullanıcı Adınız :");
                                kullanıcıAdı = Console.ReadLine();
                            } while (x.boşMu(kullanıcıAdı) == true);



                            do
                            {
                                Console.Write("Mail Adresiniz :");
                                email = Console.ReadLine();
                            } while (x.boşMu(email) == true);
                            


                            do
                            {
                                Console.WriteLine("Şifrenizi giriniz :");
                                sifre = Console.ReadLine();
                                Console.Write("Şifrenizi tekrar giriniz :");
                                şifretkr = Console.ReadLine();
                                
                            } while (sifre != şifretkr);

                            string satır = ad + "*" + soyad + "*" + kullanıcıAdı + "*" + email + "*" + sifre + "*" + şifretkr;
                            //AYSE*DEMİR*AYS
                            x.Ekle(satır);
                            Console.WriteLine(">>>>>-İŞLEMİNİZ KAYDEDİLMİŞTİR-<<<<<");
                            break;
                        

                        case 'G'://GİRİŞ
                            Console.WriteLine("----GİRİŞ İŞLEMLERİ----\n");

                            do
                            {
                                Console.Write("Kullanıcı Adınızı Giriniz :");
                                kullanıcıAdı = Console.ReadLine();
                                Console.Write("Şifrenizi giriniz :");
                                sifre = Console.ReadLine();

                                if (x.varMi(kullanıcıAdı, sifre))
                                {
                                    Console.WriteLine(">>>-GİRİŞ YAPILDI-<<<");
                                    Console.WriteLine("Sayfa Oluştur(S)-Bilgilerim(B)-Kitap Oluştur(K)-Ödünç Al(Ö)");
                                    //BİLGİLERİM
                                    char sec = Convert.ToChar(Console.ReadLine());
                                    sec = char.ToUpper(sec);
                                   
                                    
                                    switch (sec)
                                    {
                                        case 'S':
                                            Sayfa s = new Sayfa();
                                            bool durum = false;
                                            Console.WriteLine("Çıkış yapmak için 1'e işleminizi yapmak için 2'ye tuşlayınız");


                                            while (!durum)
                                            {
                                                string sayı = Console.ReadLine();
                                                if (sayı == "1")
                                                {
                                                    Console.WriteLine("\n***PROGRAMDAN ÇIKILDI***\n");
                                                    break;
                                                }

                                                else if (sayı == "2")
                                                {
                                                    Console.WriteLine("Oluşturulacak dosyanın adını giriniz");
                                                    string dsyS = Console.ReadLine() + ".txt";

                                                    if (s.varmiDosya(dsyS) == true)
                                                    { Console.WriteLine("\n---BgÖYLE BİR DOSYA MEVCUT---\n"); }
                                                    else
                                                    {
                                                        s.dosyaOluştur();
                                                        s.syfOluştur();
                                                    }

                                                }

                                            }
                                            break;



                                        case 'K':

                                            Kitap k = new Kitap();

                                            List<string> dosyaAdlari = k.DosyaAdAl(); // Kullanıcıdan dosya adlarını al

                                            if (dosyaAdlari.Count > 0)
                                            {

                                                Console.WriteLine("Oluşturulacak dosyanın adını giriniz");
                                                string hedefDosyaAdi = Console.ReadLine() + ".txt";
                                                //= "birlesmisDosya.txt"; // Birleştirilen dosyanın adı

                                                if (File.Exists(hedefDosyaAdi))
                                                {
                                                    Console.WriteLine("Böyle bir dosya mevcut");
                                                }
                                                else
                                                {
                                                    k.BirlestirVeKaydet(dosyaAdlari, hedefDosyaAdi);
                                                }

                                            }
                                            else
                                            {
                                                Console.WriteLine("Hiç dosya adı girilmedi. Program sonlandırılıyor.");
                                            }
                                            break;





                                        case 'Ö':
                                            Kitap ki = new Kitap();
                                            ki.Listele();
                                            Console.WriteLine("Kitabın adı :");
                                            string kitapA = Console.ReadLine();
                                            
                                            ki.KitapAl(kitapA);

                                            break;




                                        case 'B':
                                            break;
                                    }

                                    break;

                                }
                                else
                                    Console.WriteLine(">>>-HATALI GİRİŞ-<<<");
                              
                            }while (x.boşMu(kullanıcıAdı,sifre) == false);
                        break;
                    }

                    break;

               

                case "GÖREVLİ":

                    Görevli g = new Görevli();
                    string adıG;
                    string soyadıG;
                    string tcnoG;
                    string emailG;
                    string telnoG;
                    string parolaG;
                    string parolatkrG;

                    Console.WriteLine("Kayıt(K)-Giriş(G)");
                    char harfG = Convert.ToChar(Console.ReadLine());

                    switch (harfG)
                    {
                        case 'K'://KAYIT
                            
                            Console.WriteLine("-----KAYIT İŞLEMLERİ----- \n");

                            do
                            {
                                Console.WriteLine("Adınız :");
                                adıG = Console.ReadLine();

                                do
                                {
                                    Console.WriteLine("Adınızı tekrardan yazınız :");
                                    adıG = Console.ReadLine();
                                }
                                while (g.kontrol(adıG) == true);

                            } while (g.boşMuG(adıG) == true);



                            do
                            {
                                Console.WriteLine("Soyadınız :");
                                soyad = Console.ReadLine();

                                do
                                {
                                    Console.WriteLine("Soyadınızı tekrardan yazınız :");
                                    soyadıG = Console.ReadLine();
                                }
                                while (g.kontrol(soyadıG) == true);

                            } while (g.boşMuG(soyadıG) == true);

                            do
                            {
                                Console.Write("Kimlik Numaranız :");
                                tcnoG = Console.ReadLine();
                                do
                                {
                                    Console.WriteLine("Kimlik Numaranızı tekrar giriniz :");
                                } while (g.boşMuG(tcnoG) == true);
                            } while (tcnoG.Length != 11);

                           

                            Console.Write("Mail Adresiniz");
                            emailG = Console.ReadLine();

                            do
                            {
                                Console.WriteLine("Şifrenizi giriniz :");
                                parolaG = Console.ReadLine();
                                Console.Write("Şifrenizi tekrar giriniz :");
                                parolatkrG = Console.ReadLine();
                            } while (parolaG != parolatkrG);

                            string satırG = adıG + "^" + soyadıG + "^" + tcnoG + "^" + emailG + "^" + parolaG + "^" + parolatkrG;

                            g.Ekle(satırG);
                            Console.WriteLine(">>>>>-İŞLEMİNİZ KAYDEDİLMİŞTİR-<<<<<");
                            break;


                        case 'G'://GİRİŞ
                            Console.WriteLine("----GİRİŞ İŞLEMLERİ----\n");

                            do
                            {
                                Console.Write("Adınız:");
                                adıG = Console.ReadLine();
                                Console.Write("Soyadınız");
                                soyadıG = Console.ReadLine();
                                Console.Write("Şifreniz:");
                                parolaG = Console.ReadLine();
                                if (g.varMi(adıG, soyadıG, parolaG))
                                {
                                    Console.WriteLine(">>>-GİRİŞ YAPILDI-<<<\n\n");

                                    Console.WriteLine(">>BİLGİLERİM - KİTAP İŞLEMLERİ<<");
                                    string isler = Console.ReadLine();
                                    isler = isler.ToUpper();

                                    switch (isler)
                                    {
                                        case "BİLGİLERİM":

                                            //BİLGİLERİMİ GÖRÜNTÜLE
                                            //BİLGİLERİMİ GÜNCELLE

                                            break;

                                        case "KİTAP İŞLEMLERİ":
                                            //ödünç verecek
                                            //Kütüp oluştur
                                            Console.Write("Kitap Adı :");
                                            string adıKi = Console.ReadLine();
                                            Console.Write("Yazarı :");
                                            string yazar= Console.ReadLine();
                                            Console.Write("Türü :");
                                            string tur = Console.ReadLine();
                                            string satırkitap = adıKi + "/" + yazar + "/" + tur;
                                            Kitap k = new Kitap();
                                            k.ekleK(satırkitap);

                                            break;
                                    }

                                    break;
                                }
                                else
                                    Console.WriteLine(">>>-HATALI GİRİŞ-<<<");
                            } while (g.boşMu(adıG, soyadıG, parolaG));


                            break;
                    }

                    break;
            }

           
           


            

            


            Console.ReadLine();
        }
    }
}
