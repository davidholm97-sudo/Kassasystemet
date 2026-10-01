using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystemet
{
    public class Produkt
    {
        public string Id;
        public string Namn;
        public decimal Pris;
        public string Enhet;


        public Produkt(string id, string namn, decimal pris, string enhet)
        {
            Id = id;

            Namn = namn;

            Pris = pris;

            Enhet = enhet;

        }
    }
}
