﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosar2004
{
    class Program
    {
        static List<Meccs> Meccsek = new List<Meccs>();
        static void Main(string[] args)
        {
            //7up Joventut; Adecco Estudiantes; 81; 73; Palacio Mun. De Deportes De Badalona; 2005 - 04 - 03



            var m = new Meccs("7up Joventut", "Adecco Estudiantes", 81, 73, "Palacio Mun. De Deportes De Badalona", "2005 - 04 - 03");

            Console.WriteLine($"{m.Hazai} - {m.Idegen} ({m.HPont}:{m.IPont})");

            Console.ReadLine();
        }
    }
}
