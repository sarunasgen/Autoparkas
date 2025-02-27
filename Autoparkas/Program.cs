using Autoparkas.Models;
using System;

namespace Autoparkas
{
    public class Program
    {
        public static void Main()
        {
            AutoParkas manoAutoparkas = new AutoParkas();
            
            while(true)
            {
                Console.WriteLine("1. Prideti Automobili");
                Console.WriteLine("2. Rodyti Visus Automobilius");
                Console.WriteLine("3. Rasti Automobili Pagal Marke");
                Console.WriteLine("0. Baigti Darba");
                if(int.TryParse(Console.ReadLine(), out int pasirinkimas))
                {
                    switch(pasirinkimas)
                    {
                        case 1:
                            Console.WriteLine("Iveskite marke:");
                            string marke = Console.ReadLine();

                            Console.WriteLine("Iveskite modeli:");
                            string modelis = Console.ReadLine();

                            Console.WriteLine("Iveskite pirmosios registracijos data:");
                            DateOnly pirmRegData = DateOnly.Parse(Console.ReadLine());

                            Console.WriteLine("Iveskite paros kaina:");
                            decimal parosKaina = decimal.Parse(Console.ReadLine());

                            Automobilis naujasAuto = new Automobilis
                            {
                                Marke = marke,
                                Modelis = modelis,
                                PirmosRegData = pirmRegData,
                                ParosKaina = parosKaina
                            };

                            manoAutoparkas.PridetiAutomobili(naujasAuto);
                            break;
                        case 2:
                            Automobilis[] visiAuto = manoAutoparkas.GautiVisusAutomobilius();
                            foreach(Automobilis a in visiAuto)
                            {
                                Console.WriteLine($"{a.Marke} {a.Modelis} {a.PirmosRegData} {a.ParosKaina}");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Iveskite marke:");
                            string ieskomaMarke = Console.ReadLine();

                            Automobilis[] rastiAuto = manoAutoparkas.GautiAutomobiliusPagalMarke(ieskomaMarke);
                            foreach (Automobilis a in rastiAuto)
                            {
                                Console.WriteLine($"{a.Marke} {a.Modelis} {a.PirmosRegData} {a.ParosKaina}");
                            }
                            break;
                        case 0:
                            return;
                            break;
                    }
                }
            }
        }
    }
}