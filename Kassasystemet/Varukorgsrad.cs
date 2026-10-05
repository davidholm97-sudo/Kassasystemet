using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystemet
{
    public class Varukorgsrad
    {
        public Produkt Produkt;
        public decimal Antal;
        public decimal RadPris;

        public Varukorgsrad(Produkt produkt, decimal antal)
        {
            
            Produkt = produkt;
            Antal = antal;
            RadPris = produkt.Pris * Antal;

        }



    }

}
