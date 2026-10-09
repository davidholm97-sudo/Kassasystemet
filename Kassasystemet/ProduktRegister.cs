using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Kassasystemet
{
    internal class ProduktRegister
    {
        public static Dictionary<string, Produkt> LasinProdukter()
        {
            string filväg = "produkter.txt";
            Dictionary<string, Produkt> produktregister = new Dictionary<string, Produkt>();
            if (File.Exists(filväg))
            foreach (var rad in File.ReadLines(filväg))
            {
                string[] delar = rad.Split(';');
                    if (delar.Length >= 4)
                    {
                        string id = delar[0];
                        string namn = delar[1];
                        decimal pris;
                        decimal.TryParse(delar[2],out pris);
                        string enhet = delar[3];
                        Produkt produkt = new Produkt(id, namn, pris, enhet);

                        produktregister[id] = produkt;
                    }
            }
            return produktregister;
        }
    }
}
