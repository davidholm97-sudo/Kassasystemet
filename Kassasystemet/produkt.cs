using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystemet
{
    public class Produkt
    {
        public string Id { get; private set; }
        public string Namn { get; set; }
        public decimal Pris {  get; set; }
        public string Enhet { get; set; }


        public Produkt(string id, string namn, decimal pris, string enhet)
        {
            Id = id;

            Namn = namn;

            Pris = pris;

            Enhet = enhet;

        }
    }
}
