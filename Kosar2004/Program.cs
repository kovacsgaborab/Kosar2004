using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Net.Http.Headers;

namespace Kosar2004
{
    class Program
    {
        static List<Meccs> Meccsek = new List<Meccs>();

        static Dictionary<string, int> dicstionary = new Dictionary<string, int>();

        static void Masodik()
        {
            StreamReader sr = new StreamReader("eredmenyek.csv");

            sr.ReadLine();


            while (!sr.EndOfStream)
            {
                string[] adat = sr.ReadLine().Split(';');
                //Meccsek.Add(new Meccs(sr.ReadLine()));
                Meccsek.Add(new Meccs(adat[0], adat[1], Convert.ToInt32(adat[2]), Convert.ToInt32(adat[3]), adat[4], adat[5]));
            }

            sr.Close();
        }

        static void Harmadik()
        {

            //var hazai = from m in Meccsek where m.Hazai == "Real Madrid" select new { Hazai = m.Hazai };

            //int hazaiDb = hazai.ToList().Count;   //listává alakítjuk, hogy alkalmazhassuk rajta a Countot

            //var idegen = from m in Meccsek where m.Idegen == "Real Madrid" select new { Idegen = m.Idegen };

            //int idegenDb = idegen.ToList().Count;

            //Console.WriteLine($"3. Feladat: Hazai : {hazaiDb} Idegen: {idegenDb}");



            int hazai = 0;
            int idegen = 0;

            foreach (var r in Meccsek)
            {
                if (r.Hazai.Contains("Real Madrid"))
                {
                    hazai++;
                }
            }

            foreach (var r in Meccsek)
            {
                if (r.Idegen.Contains("Real Madrid"))
                {
                    idegen++;
                }
            }

            Console.WriteLine($"3. Feladat: Hazai: {hazai}, Idegen: {idegen}");
        }

        static void Negyedik()
        {
            //var dontetlen = from m in Meccsek where m.IPont == m.HPont select m;

            //int dbdontetlen = dontetlen.ToList().Count;

            //if (dbdontetlen > 0)
            //{
            //    Console.Write("Volt döntetlen mérkőzés");
            //}
            //else
            //{
            //    Console.Write("Nem volt döntetlen mérkőzés");
            //}

            bool dontetlen = false;

            foreach (var m in Meccsek)
            {
                if (m.HPont == m.IPont)
                {
                    dontetlen = true;
                }
            }

            Console.Write("4. feladat: ");

            if (dontetlen == true)
            {
                Console.Write("Volt döntetlen mérkőzés");
            }
            else
            {
                Console.Write("Nem volt döntetlen mérkőzés");
            }
        }

        static void Otodik()
        {
            //var barca = from m in Meccsek where m.Hazai.Contains("Barcelona") select new { Hazai = m.Hazai };

            //var barcaNev = barca.ToArray()[0].Hazai;

            //Console.WriteLine("\n5. feladat: {0}", barcaNev);

            string nev = "";

            foreach (var m in Meccsek)
            {
                if (m.Hazai.Contains("Barcelona"))
                {
                    nev = m.Hazai;
                }
            }

            Console.WriteLine($"\n5. feladat: A Barcelonai csapat neve: {nev}");
        }

        static void Hatodik()
        {
            Console.WriteLine("6. feladat: ");

            //var november = from m in Meccsek where m.Ido == "2004-11-21" select new { Hazai = m.Hazai, Idegen = m.Idegen, HP = m.HPont, IP = m.IPont };

            //foreach (var n in november)
            //{
            //    Console.WriteLine($"\t{n.Hazai} {n.Idegen} ({n.HP}:{n.IP})");
            //}

            foreach (var m in Meccsek)
            {
                if (m.Ido.Contains("2004-11-21"))
                {
                    Console.WriteLine($"\t{m.Hazai} {m.Idegen} ({m.HPont}:{m.IPont})");
                }
            }
        }

        static void Hetedik()
        {
            var stadionok = from m in Meccsek orderby m.Hely group m by m.Hely into stadion select stadion;

            Console.WriteLine("7. feladat:");

            foreach (var stadion in stadionok)
            {
                if (stadion.Count() > 20) 
                {
                    Console.WriteLine($"\t{stadion.Key} - {stadion.Count()}");
                }
            }
        }

        static void Nyolcadik()
        {
            //meccsek.txt-be kiírni a meccsek eredményeit Hazai Idegen eredmények

            StreamWriter sw = new StreamWriter("meccsek.txt");

            foreach (var m in Meccsek)
            {
                sw.WriteLine($"{m.Hazai} - {m.Idegen} ({m.HPont}:{m.IPont})");
            }

            /*foreach (var m in Meccsek)            //Metódussal
            {
                sw.WriteLine(m.Atalakit());
            }*/
            sw.Close();
        }

        static void Main(string[] args)
        {
            //7up Joventut; Adecco Estudiantes; 81; 73; Palacio Mun. De Deportes De Badalona; 2005 - 04 - 03

            Masodik();
            Harmadik();
            Negyedik();
            Otodik();
            Hatodik();
            Hetedik();
            Nyolcadik();
            


            Console.ReadLine();
        }
    }
}
