using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystemet
{
    internal abstract class Kampanj 
    {
        public Produkt Produkt_ {  get; }
        public DateTime Startdatum { get; }
        public DateTime Slutdatum { get; }

        public Kampanj(Produkt produkt, DateTime startDatum, DateTime slutDatum )
        {
            if (produkt is null)
                throw new ArgumentNullException(nameof(produkt));//om null kasta skiten.. igen
            if (startDatum > slutDatum)
                throw new ArgumentException("slutdatum får inte ligga före startdatum");
            Produkt_ = produkt;
            Startdatum = startDatum;
            Slutdatum = slutDatum;

        }
        public bool AktivKampanj()
        {
            DateTime dagensDatum = DateTime.Today;
            return dagensDatum >= Startdatum && dagensDatum <= Slutdatum;
        }
        public abstract decimal Kampanjberakningar();


    }
}

