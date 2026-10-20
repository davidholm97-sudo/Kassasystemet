using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Kassasystemet
{
    internal class KampanjFil
    {
        public static List<Kampanj> LasaKampanj(Dictionary<string, Produkt> produktregister)
        {
            string kampanjFilvag = "Kampanjfil.txt";
            List<Kampanj> kampanjer = new List<Kampanj>();
            if (!File.Exists(kampanjFilvag))
                return kampanjer;

            foreach (var rad in File.ReadLines(kampanjFilvag))
            {
                string[] delar = rad.Split(';');
                if (delar.Length >= 5)
                {
                    string kampanjTyp = delar[0].Trim().ToLower();
                    string id = delar[1].Trim();
                    if (!produktregister.TryGetValue(id, out Produkt produkt))
                    {
                        Console.WriteLine($"Produkten {id} finns inte.");
                        continue;
                    }
                    if (!decimal.TryParse(delar[2], out decimal rabattVärde))
                    {
                        Console.WriteLine($"ogiltigt rabattvärde för produkt {id}");
                        continue;
                    }
                    DateTime startDatum = DateTime.Parse(delar[3]);
                    DateTime slutDatum = DateTime.Parse(delar[4]);
                    Kampanj kampanj;
                    if (kampanjTyp == "procentkampanj")
                    {
                        if (rabattVärde <= 0 || rabattVärde >= 100)
                        {
                            Console.WriteLine($"Ogiltig rabattprocent för produkt {id}.");
                            continue;
                        }
                        kampanj = new KampanjProcent(produkt, startDatum, slutDatum, rabattVärde);
                    }
                    else if (kampanjTyp == "fastkampanj")
                    {
                        if (rabattVärde <= 0 || rabattVärde > produkt.Pris)
                        {
                            Console.WriteLine($"Ogiltig rabatt för produkt {id}.");
                            continue;
                        }
                        kampanj = new KampanjPris(produkt, startDatum, slutDatum, rabattVärde);
                    }
                    else
                        continue;
                    kampanjer.Add(kampanj);
                }
            }
                    return kampanjer;
        }
        public static void SparaKampanjer(List<Kampanj> kampanjer)
        {
            string kampanjFilvag_ = "Kampanjfil.txt";
            KampanjFil.SparaKampanjer(kampanjer);
            if (kampanj is KampanjProcent procent)
            {

            }
            else if (kampanj is KampanjPris fastRabatt)
            {

            }



            File.WriteAllLines(kampanjFilvag_,  );
        }
        
    }
}
