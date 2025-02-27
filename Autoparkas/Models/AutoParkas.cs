using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoparkas.Models
{
    public class AutoParkas
    {
        private Automobilis[] Automobiliai;

        public AutoParkas()
        {
            Automobiliai = new Automobilis[0];
        }
        public void PridetiAutomobili(Automobilis automobilis)
        {
            Automobilis[] naujasMasyvas = new Automobilis[Automobiliai.Length + 1];
            int index = 0;
            foreach(Automobilis a in Automobiliai)
            {
                naujasMasyvas[index] = a;
                index++;
            }
            naujasMasyvas[index] = automobilis;
            Automobiliai = naujasMasyvas;
        }
        public Automobilis[] GautiVisusAutomobilius()
        {
            return Automobiliai;
        }
        public Automobilis[] GautiAutomobiliusPagalMarke(string marke)
        {
            Automobilis[] automobiliai;

            int kiekis = 0;
            foreach(Automobilis a in Automobiliai)
            {
                if (a.Marke == marke)
                    kiekis++;
            }
            automobiliai = new Automobilis[kiekis];
            int index = 0;
            foreach (Automobilis a in Automobiliai)
            {
                if (a.Marke == marke)
                {
                    automobiliai[index] = a;
                    index++;
                }
            }

            return automobiliai;
        }
    }
}
