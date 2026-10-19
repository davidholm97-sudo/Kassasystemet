using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystemet
{
    internal class KampanjProcent : Kampanj
    {
        public decimal Rabattprocent { get; }
        public KampanjProcent(Produkt produkt, DateTime startDatum, DateTime slutDatum, decimal rabattProcent) : base(produkt, startDatum, slutDatum)
        {
            if (rabattProcent <= 0 || rabattProcent >= 100)
                throw new ArgumentOutOfRangeException(nameof(rabattProcent));
            Rabattprocent = rabattProcent;
        }
        public override decimal Kampanjberakningar()
        {
            decimal rabatteratPris = Produkt_.Pris - ((Produkt_.Pris / 100) * Rabattprocent);
            return rabatteratPris;
        }
    }
}
