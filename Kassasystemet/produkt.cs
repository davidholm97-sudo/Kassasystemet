using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystemet
{
    public class Produkt
    {
        public string Id { get; }
        public string Namn { get; private set; }
        public decimal Pris {  get; private set; }
        public string Enhet { get; }


        public Produkt(string id, string namn, decimal pris, string enhet)
        {
            if (string.IsNullOrWhiteSpace(id)) 
                throw new ArgumentException("Produkt-ID får inte vara tomt!", nameof(id));
            Id = id.Trim();

            AndraNamn(namn);

            AndraPris(pris);

            Enhet = enhet;

        }
        public void AndraNamn(string namn)
        {
            if (string.IsNullOrWhiteSpace(namn))
                throw new ArgumentException("Produktnamnet får inte vara tomt!", nameof(namn));
            Namn = namn;
        }
        public void AndraPris(decimal pris)
        {
            if (pris <= 0)
                throw new ArgumentException("Priset får inte vara negativt eller noll", nameof(pris));

            Pris = pris;
        }
    }
}
