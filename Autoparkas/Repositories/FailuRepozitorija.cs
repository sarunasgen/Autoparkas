using Autoparkas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoparkas.Repositories
{
    public class FailuRepozitorija
    {
        private readonly string _klientuFailas;
        private readonly string _automobiliuFailas;
        public FailuRepozitorija(string klientuFailas, string automobiliuFailas)
        {
            _automobiliuFailas = automobiliuFailas;
            _klientuFailas = klientuFailas;
        }

        public void IssaugotiAutomobilius(Automobilis[] automobiliai)
        {
            StreamWriter sw = new StreamWriter(_automobiliuFailas);
            foreach(Automobilis a in automobiliai)
            {
                sw.WriteLine($"{a.Marke},{a.Modelis},{a.PirmosRegData},{a.ParosKaina}");
            }
            sw.Close();
        }

        public Automobilis[] NuskaitytiAutomobilius()
        {
            if (!File.Exists(_automobiliuFailas))
                return new Automobilis[0];

            StreamReader sr = new StreamReader(_automobiliuFailas);
            int autoKiekis = 0;
            while(!sr.EndOfStream)
            {
                string eilute = sr.ReadLine();
                autoKiekis++;
            }
            sr.Close();
            Automobilis[] nuskaitytiAutomobiliai = new Automobilis[autoKiekis];
            int index = 0;
            sr = new StreamReader(_automobiliuFailas);
            while (!sr.EndOfStream)
            {
                string eilute = sr.ReadLine();
                string[] vertes = eilute.Split(',');
                nuskaitytiAutomobiliai[index] = new Automobilis { Marke = vertes[0], Modelis = vertes[1], ParosKaina = decimal.Parse(vertes[3]), PirmosRegData = DateOnly.Parse(vertes[2]) };
                index++;
            }
            sr.Close();
            return nuskaitytiAutomobiliai;
        }

        public void IssaugotiKlientus(Klientas[] klientai)
        {
            StreamWriter sw = new StreamWriter(_klientuFailas);
            foreach (Klientas a in klientai)
            {
                sw.WriteLine($"{a.AsmensKodas},{a.VardasPavarde}");
            }
            sw.Close();
        }

        public Klientas[] NuskaitytiKlientus()
        {
            if (!File.Exists(_klientuFailas))
                return new Klientas[0];


            StreamReader sr = new StreamReader(_klientuFailas);
            int kiekis = 0;
            while (!sr.EndOfStream)
            {
                string eilute = sr.ReadLine();
                kiekis++;
            }
            sr.Close();
            Klientas[] nuskaitytiKlientai = new Klientas[kiekis];
            int index = 0;
            sr = new StreamReader(_klientuFailas);
            while (!sr.EndOfStream)
            {
                string eilute = sr.ReadLine();
                string[] vertes = eilute.Split(',');
                nuskaitytiKlientai[index] = new Klientas { AsmensKodas = long.Parse(vertes[0]), VardasPavarde = vertes[1] };
                index++;
            }
            sr.Close();
            return nuskaitytiKlientai;
        }
    }
}
