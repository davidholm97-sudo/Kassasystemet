using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystemet
{
    internal class KampanjPris : Kampanj 
    {
        public decimal Rabattpris { get; }

        public KampanjPris(Produkt produkt, DateTime startDatum, DateTime slutDatum, decimal rabattPris) : base(produkt, startDatum, slutDatum)
        {
            if (rabattPris <= 0 || rabattPris >= Produkt_.Pris )
                throw new ArgumentOutOfRangeException(nameof(rabattPris));
            Rabattpris = rabattPris;
        }
        public override decimal Kampanjberakningar()
        {
            decimal rabatteratPris = 0;
            rabatteratPris = Produkt_.Pris - Rabattpris;

            return rabatteratPris;
            
        }
    }
}
