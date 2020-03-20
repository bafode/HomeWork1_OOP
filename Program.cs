/****************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ BÖLÜMÜ
** NESNEYE DAYALI PROGRAMLAMA DERSİ
** 2019-2020 BAHAR DÖNEMİ
**
** ÖDEV NUMARASI..........: 1
** ÖĞRENCİ ADI............: Bafode Camara
** ÖĞRENCİ NUMARASI.......:B181200558
** DERSİN ALINDIĞI GRUP...: A
****************************************************************************/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace projetBSM
{
    class Program
    {
        //Rasgele Tam Sayi Uretilen  Fonctionu
        public static int randomNumber(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }
        //Rasgele İsim Uretilen fonksiyonu
        public static string random_string(int size)
        {
            string dico = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
            char[] chars = new char[size];
            Random rand = new Random();

            for (int i = 0; i < size; i++)
            {
                chars[i] = dico[rand.Next(0, dico.Length)];
            }

            return new string(chars);
        }
        //Ortalama Hesaplanan Fonksionu
        public static double getAverage(double homeWork1, double homeWork2, double Vize, double projet, double final)
        {
            return homeWork1 * 0.1 + homeWork2 * 0.1 + Vize * 0.25 + projet * 0.15 + final * 0.5;
        }
        

        static void Main(string[] args)
        {
            //Ilk olarak kullanıcıdan öğrenci sayisi istiyoruz
            int numberOfStudent;
            Console.Write("Enter the number of student:");
            Console.ForegroundColor = ConsoleColor.Red;
            numberOfStudent = int.Parse(Console.ReadLine());

            //student tipinde içi boş dizi oluşturuldu ve dizi boyutu öğrenci sayısıdır.
            student[] studentObj = new student[numberOfStudent];

            //dizinin her elemen referens oluşturuldu
            for (int j = 0; j < studentObj.Length; j++)
            {
                studentObj[j] = new student();
            }

            string Files = "student.txt"; //ogrencilerin bilgileri yazacağımız dosya adı
            //Text dosyasına her öğrencinin bilgileri yazmak için
            StreamWriter sw1 = new StreamWriter(Files);

            //Değer atama işlemleri: studentObj dizideki her ogrenci için rasgele fonksiyonlari kullanarak
            for (int j = 0; j < studentObj.Length; j++)
            {
                studentObj[j].LastName = random_string(5);
                studentObj[j].Firstname = random_string(5);
                studentObj[j].id_number = Convert.ToInt32(randomNumber(200, 400));
                studentObj[j].homeWork1 = Convert.ToDouble(randomNumber(10, 100));
                studentObj[j].homeWork2 = Convert.ToDouble(randomNumber(10, 100));
                studentObj[j].Vize = Convert.ToDouble(randomNumber(10, 100));
                studentObj[j].projet = Convert.ToDouble(randomNumber(10, 101));
                studentObj[j].final = Convert.ToDouble(randomNumber(10, 101));


            }

           // ogrencilerin bilgileri dosyaya yazdırmak
            foreach (var item in studentObj)
            {
                sw1.WriteLine("{0}   {1}   {2}   {3}   {4}   {5}   {6}   {6}", item.Firstname, item.LastName,item.id_number, item.homeWork1, item.homeWork2, item.Vize, item.projet, item.final);
            }
            sw1.Close();//yazdiktan sonra dosyayı kapatmak lazım

            //Sonra yazdığım bilgiler yine okumak istiyorum
            StreamReader sr = new StreamReader(Files);//aynı student dosyayı okunmak için açıldı
          
            // stduent tipinde içi boş liste oluşturuldu
            List<student> studentObject = new List<student>();
            string Lines;
            do
            {
                Lines=sr.ReadLine();// Bir satır oku
                string[] stringSeparators = new string[] { " " };// csv formatı boşluk ayrılmış , göre parçaladık
                string[] getcolomn = Lines.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                studentObject.Add(new student // Listeye eleman ekliyoruz
                {
                    Firstname = getcolomn[0],
                    LastName = getcolomn[1],
                    id_number = int.Parse(getcolomn[2]),
                    homeWork1 = double.Parse(getcolomn[3]),
                    homeWork2 = double.Parse(getcolomn[4]),
                    Vize = double.Parse(getcolomn[5]),
                    projet = double.Parse(getcolomn[6]),
                    final = double.Parse(getcolomn[7]),


                }); ;

            } while (!sr.EndOfStream);// Dosya sonu gelene kadar
            sr.Close();//Dosyayı kapat

            //listeki her öğrencinin ortalama ve kat sayı hesaplama lşlemi getAverage fonksiyon kullanarak
            for (int i = 0; i < studentObject.Count; i++)
              {
                studentObject[i].average = getAverage(studentObject[i].homeWork1, studentObject[i].homeWork2, studentObject[i].Vize, studentObject[i].projet, studentObject[i].final);
                studentObject[i].genelmark = studentObject[i].average * 4 / 100;
              }
            //Sinifin statistik işlemleri yapma işlemleri
            int compAA = 0, compBA = 0, compBB = 0, compCB = 0, compCC = 0, compDC = 0, compDD = 0, compFD = 0, compFF = 0, compDZ = 0;
            double aaOran = 0, baOran = 0, bbOran = 0, cbOran = 0, ccOran = 0, dcOran = 0, ddOran = 0, fdOran = 0, ffOran = 0, dzOran = 0;
            for (int i = 0; i < studentObject.Count; i++)
            {
                if (studentObject[i].average >= 90)
                {
                    compAA++;//AA alanların sayısı bulma
                }
                else if (studentObject[i].average >= 85.00)
                {
                    compBA++;//BA alanların sayısı bulma
                }
                else if (studentObject[i].average >= 80.00)
                {
                    compBB++;//BB alanların sayısı bulma
                }
                else if (studentObject[i].average >= 75.00)
                {
                    compCB++;//CB alanların sayısı bulma

                }
                else if (studentObject[i].average >= 65.00)
                {
                    compCC++;//CC alanların sayısı bulma
                }
                else if (studentObject[i].average >= 58.00)
                {
                    compDC++;//DC alanların sayısı bulma
                }
                else if (studentObject[i].average >= 50.00)
                {
                    compDD++;//DD alanların sayısı bulma
                }
                else if (studentObject[i].average >= 40.00)
                {
                    compFD++;//FD alanların sayısı bulma
                }
                else if (studentObject[i].average >= 0)
                {
                    compFF++;//FF alanların sayısı bulma
                }
                else
                {
                    compDZ++;//DZ alanların sayısı bulma
                }
            }

            //her gurubun oranı bulma işlemleri
            aaOran = compAA * 100 / numberOfStudent;
            baOran = compBA * 100 / numberOfStudent;
            bbOran = compBB * 100 / numberOfStudent;
            cbOran = compCB * 100 / numberOfStudent;
            ccOran = compCC * 100 / numberOfStudent;
            dcOran = compDC * 100 / numberOfStudent;
            ddOran = compDD * 100 / numberOfStudent;
            fdOran = compFD * 100 / numberOfStudent;
            ffOran = compFF * 100 / numberOfStudent;
            dzOran = compDZ * 100 / numberOfStudent;
            int sum = compAA + compBB + compBA + compBB + compCB + compCC + compDC + compDD;

            //Yeni bir test dosyası oluşturdum ortalama sıralı yazmak için
            StreamWriter sw = new StreamWriter("AverageOrder.text");
           
            List<student> studentOrder = studentObject.OrderByDescending(x => x.average).ToList();//siralama işlemi
            Console.Clear();//tekra temizlemek için
            Console.ForegroundColor = ConsoleColor.Yellow;//yazi rengi sarı olarak değiştirdim
            Console.WriteLine(DateTime.Now);// console ekrana sistem tarih ve saati yaz
            sw.WriteLine(DateTime.Now);// Oluşturulan text dosyasına sistem tarih ve saati yaz
            Console.WriteLine("No.\tFirst_Name\tLast_Name\tİd_Student\tHomework1\thomework2\tVize\tProjet\tFinal\tAverage\tLetter_Mark\tLevel_of_succes\tGeneralMark");
            sw.WriteLine("No.\tFirst_Name\tLast_Name\tİd_Student\ttHomework1\thomework2\tVize\tProjet\tFinal\tAverage\tLetter_Mark\tLevel_of_succes\tGeneralMark");
            int k = 1;// student sıra numarası yazmak için

            //Konsol ve Text dosyasına yazdırmak için
            foreach (var item in studentOrder)
            {
                Console.WriteLine("{0,4}\t{1,-8} \t{2,-8}\t{3}\t\t{4}\t\t{5}\t\t{6}\t{7}\t{8}\t{9} \t{10,11}\t{11,11} \t{12}", k, item.Firstname, item.LastName,item.id_number, item.homeWork1, item.homeWork2, item.Vize, item.projet, item.final,item.average.ToString(".00"),item.getLttermark(),item.getLevelOfSucces(),item.genelmark.ToString("0.00"));
                sw.WriteLine("{0,4}\t{1,-8} \t{2,-8}\t{3}\t\t{4}\t\t{5}\t\t{6}\t{7}\t{8}\t{9} \t{10,11}\t{11,11} \t{12}", k, item.Firstname, item.LastName, item.id_number, item.homeWork1, item.homeWork2, item.Vize, item.projet, item.final, item.average.ToString(".00"), item.getLttermark(), item.getLevelOfSucces(), item.genelmark.ToString("0.00"));
                k++;
            }
            sw.Close();// Dosya kapatılmazsa veri kaybı yaşanabilir
            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            //sinif statistik ekrna yazdirmak için
            Console.WriteLine("***************Statistic of Class************************");
            Console.WriteLine("AA: {0}      percentage: {1}%", compAA, aaOran);
            Console.WriteLine("BA: {0}      percentage: {1}%", compBA, baOran);
            Console.WriteLine("BB: {0}      percentage: {1}%", compBB, bbOran);
            Console.WriteLine("CB: {0}      percentage: {1}%", compCB, cbOran);
            Console.WriteLine("CC: {0}      percentage: {1}%", compCC, ccOran);
            Console.WriteLine("DC: {0}      percentage: {1}%", compDC, dcOran);
            Console.WriteLine("DD: {0}      percentage: {1}%", compDD, ddOran);
            Console.WriteLine("FD: {0}      percentage: {1}%", compFD, fdOran);
            Console.WriteLine("FF: {0}      percentage: {1}%", compFF, ffOran);
            Console.WriteLine("DZ: {0}      percentage: {1}%", compDZ, dzOran);
            Console.WriteLine("The numbre of student admitted:{0} percentage of admission:{1}% ",sum,(double)(sum*100/numberOfStudent));
            Console.WriteLine("the number of failed student: {0} percentage of faillure: {1}",numberOfStudent-sum,(double)((numberOfStudent - sum)*100/numberOfStudent));
            //Başka bir test dosyası oluşturdum sinif statistik yazmak için
            StreamWriter sw2 = new StreamWriter("Statistic.text");//dosya adı:Statistic
            //sinif statistik test dosyasına yazdirmak için
            sw2.WriteLine("***************Statistic of Class************************");
            sw2.WriteLine("AA: {0}      percentage: {1}%", compAA, aaOran);
            sw2.WriteLine("BA: {0}      percentage: {1}%", compBA, baOran);
            sw2.WriteLine("BB: {0}      percentage: {1}%", compBB, bbOran);
            sw2.WriteLine("CB: {0}      percentage: {1}%", compCB, cbOran);
            sw2.WriteLine("CC: {0}      percentage: {1}%", compCC, ccOran);
            sw2.WriteLine("DC: {0}      percentage: {1}%", compDC, dcOran);
            sw2.WriteLine("DD: {0}      percentage: {1}%", compDD, ddOran);
            sw2.WriteLine("FD: {0}      percentage: {1}%", compFD, fdOran);
            sw2.WriteLine("FF: {0}      percentage: {1}%", compFF, ffOran);
            sw2.WriteLine("DZ: {0}      percentage: {1}%", compDZ, dzOran);
            sw2.WriteLine("The numbre of student admitted:" + sum);
            sw2.WriteLine("the number of failed student:" + (numberOfStudent - sum));
            sw2.Close();//dosya kapat

            //Başka bir test dosyası oluşturdum geçen ogrencilerin listesi 
            StreamWriter sw3 = new StreamWriter("list_of_admitted.text");
            //Başka bir test dosyası oluşturdum kalan ogrencilerin listesi
            StreamWriter sw4 = new StreamWriter("list_of_failed_student.text");
            sw3.WriteLine("No.\tFirst_Name\tLast_Name\tİd_Student\tHomework1\thomework2\tVize\tProjet\tFinal\tAverage\tLetter_Mark\tLevel_of_succes\tGeneralMark");
            sw4.WriteLine("No.\tFirst_Name\tLast_Name\tİd_Student\tHomework1\thomework2\tVize\tProjet\tFinal\tAverage\tLetter_Mark\tLevel_of_succes\tGeneralMark");

            //Text dosyalarına yazdırmak için
            foreach (var item in studentOrder)
            {
                if (item.average>50)
                {
                  sw3.WriteLine("{0,4}\t{1,-8} \t{2,-8}\t{3}\t\t{4}\t\t{5}\t\t{6}\t{7}\t{8}\t{9} \t{10,11}\t{11,11} \t{12}", k, item.Firstname, item.LastName, item.id_number, item.homeWork1, item.homeWork2, item.Vize, item.projet, item.final, item.average.ToString(".00"), item.getLttermark(), item.getLevelOfSucces(), item.genelmark.ToString("0.00"));
                }
                else
                {
                    sw4.WriteLine("{0,4}\t{1,-8} \t{2,-8}\t{3}\t\t{4}\t\t{5}\t\t{6}\t{7}\t{8}\t{9} \t{10,11}\t{11,11} \t{12}", k, item.Firstname, item.LastName, item.id_number, item.homeWork1, item.homeWork2, item.Vize, item.projet, item.final, item.average.ToString(".00"), item.getLttermark(), item.getLevelOfSucces(), item.genelmark.ToString("0.00"));
                }
            }
            sw3.Close();//dosya kapat
            sw4.Close();// dosya kapat
            Console.Write("\n\n press any key:");
            Console.ReadKey();
           
            
        }
    }
}
