using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Kassasystemet
{
    internal class Kundberakning // Ansvarar för att lägga till produkten i varukorgen 
    {
        private readonly List<Varukorgsrad> varukorgen = new List<Varukorgsrad>();

        public decimal BeraknaTotalPris()
        {
            decimal brutto = 0;

            foreach (Varukorgsrad rad in varukorgen)
                brutto += rad.RadPris;

            return brutto;
        }
        public decimal BeraknaNettoPris()
        {
            decimal netto = 0;

            foreach (Varukorgsrad rad in varukorgen)
                netto += rad.RadPris;

            return netto / 1.25m;
        }
        public Varukorgsrad LaggTill(Produkt produkt, decimal antal, decimal enhetsPris)
        {
            Varukorgsrad rad = new Varukorgsrad(produkt, antal, enhetsPris);
            varukorgen.Add(rad);

            return rad;
        }
        public List<Varukorgsrad> Hamtarader()
        {
            return new List<Varukorgsrad>(varukorgen);
        }
    }
}
