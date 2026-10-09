using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystemet
{
    public class Varukorgsrad
    {
        public Produkt Produkt { get; }
        public decimal Antal {  get; }
        public decimal Enhetspris { get; }
        public decimal RadPris => Enhetspris * Antal;

        public Varukorgsrad(Produkt produkt, decimal antal)
        {
            if (produkt is null)
                throw new ArgumentNullException(nameof(produkt));//om null kasta skiten

            if (antal <= 0)
                throw new ArgumentException("antalen måste vara positivt", nameof(antal));
            Produkt = produkt;
            Antal = antal;
            Enhetspris = produkt.Pris;
        }



    }

}
