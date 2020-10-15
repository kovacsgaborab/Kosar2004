using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

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

            //int hazaiDb = hazai.ToList().Count;

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
            
        }

        static void Main(string[] args)
        {
            //7up Joventut; Adecco Estudiantes; 81; 73; Palacio Mun. De Deportes De Badalona; 2005 - 04 - 03

            Masodik();
            Harmadik();
            Negyedik();
            Otodik();
            Hatodik();

            


            Console.ReadLine();
        }
    }
}
