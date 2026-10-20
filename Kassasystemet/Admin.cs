using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystemet
{
    internal class Admin
    {
       
        public static void StartaAdmin(Dictionary<string, Produkt> produktregister, List<Kampanj> kampanjer)
        {
            while (true)
            {
                UI.Admin_Visameny();
                int menyVal = UI.LasaMenyVal();
                string sokFilvag = ".\\produkter.txt";

                switch (menyVal)
                {

                    case 1:
                        int hogstaID = produktregister.Keys.Select(id => int.Parse(id)).Max();
                        string nyttId = (hogstaID +1).ToString();

                        Console.WriteLine($"Lägg till namn, pris och enhet för ID {nyttId} eller skriv -AVSLUTA- för att gå tilbaka till menyn: ");
                        Console.WriteLine("Vänligen ange Namn: ");

                        string namn = Console.ReadLine().Trim().ToLower();

                            if (namn == "avsluta" && namn.Length > 0)
                                break;
                        namn = char.ToUpper(namn[0]) + namn.Substring(1);

                        decimal pris;
                        Console.WriteLine("Vänligen ange Pris: ");
                        if (!decimal.TryParse(Console.ReadLine(), out pris) || pris <= 0)
                        {
                            Console.WriteLine("Ogiltigt Pris.");
                            break;
                        }

                        Console.WriteLine("Vänligen ange enhet, Styck eller Kg: ");
                            string enhet = Console.ReadLine().Trim().ToLower();
                        if (enhet != "styck" && enhet != "kg")
                        {
                            Console.WriteLine("Ogiltig enhet");
                            break;
                        }
                            enhet = char.ToUpper(enhet[0]) + enhet.Substring(1);

                        Produkt nyProdukt = new Produkt(nyttId, namn, pris, enhet);
                        produktregister.Add(nyttId, nyProdukt);
                        Console.WriteLine($"Produkten {namn} har lagts till i  kassasystemet. ");
                        File.AppendAllLines(sokFilvag, produktregister.Values.Select(produkt => $"{produkt.Id};{produkt.Namn};{produkt.Pris};{produkt.Enhet}"));
                        break;
                        
                    case 2:

                        string idsök = UI.LasaID();
                        Produkt produkt = produktregister[idsök];

                        Console.WriteLine($"Du sökte efter id: {idsök}, ");
                        Console.WriteLine($"Du vill ändra: {produktregister[idsök].Namn} \nAnge det nya namnet, eller klicka ENTER för att ändra pris");
                        string andraProduktNamn = produktregister[idsök].Namn;
                        decimal andraProduktPris = produktregister[idsök].Pris;

                        andraProduktNamn = Console.ReadLine().Trim();
                        if (andraProduktNamn == "")
                        {
                            Console.WriteLine("Ange nya priset: ");
                            if (decimal.TryParse(Console.ReadLine(), out andraProduktPris) && andraProduktPris > 0)
                            {
                                produkt.AndraPris(andraProduktPris);
                            }
                            else
                                Console.WriteLine("Ogiltigt pris");
                        }
                        else 
                        {
                            produkt.AndraNamn(andraProduktNamn);
                            Console.WriteLine("Ange nya priset");
                            if (decimal.TryParse(Console.ReadLine(), out andraProduktPris) && andraProduktPris > 0)
                            {
                                produkt.AndraPris(andraProduktPris);
                            }
                            else
                                Console.WriteLine("Ogiltigt pris");

                        }
                        File.WriteAllLines(sokFilvag, produktregister.Values.Select(p => $"{p.Id};{p.Namn};{p.Pris};{p.Enhet}"));
                        
                        break;

                    case 3:
                        while (true)
                        {
                            UI.Admin_KampanjMeny();
                            int menyval_ = UI.LasaMenyVal();
                            switch (menyval_)
                            {
                                case 1:
                                    string idsök_ = UI.LasaID();
                                    Produkt produkt_ = produktregister[idsök_];
                                    decimal rabattprocent;
                                    Console.WriteLine($"Du sökte efter id: {produkt_.Namn}, \npriset är {produkt_.Pris} & det är {produkt_.Enhet} pris. ");
                                    Console.WriteLine("Hur många procent rabatt vill du ha i denna kampanj? ");
                                    while (true)
                                    {
                                        if (decimal.TryParse(Console.ReadLine().Trim(), out rabattprocent) && rabattprocent > 0 && rabattprocent < 100)
                                            break;
                                        else Console.WriteLine("ange en rabattprocent mellan 1-99");
                                    }
                                    DateTime startdatum = DateTime.Today;
                                    DateTime slutdatum;
                                    Console.WriteLine("Ange ett slutdatum för kampanjen, följ formatet yyyy-mm-dd: ");
                                    while (true)
                                    {
                                        if (DateTime.TryParse(Console.ReadLine(), out slutdatum) && slutdatum > startdatum)
                                            break;
                                        else Console.WriteLine("Oglitigt datum");
                                    }
                                        KampanjProcent nyKampanj = new KampanjProcent(produkt_, startdatum, slutdatum, rabattprocent);
                                        kampanjer.Add(nyKampanj);
                                    break;

                                case 2:
                                    string idSök_ = UI.LasaID();
                                    Produkt produktfast = produktregister[idSök_];
                                    decimal rabattfast;
                                    Console.WriteLine($"Du sökte efter id: {produktfast.Namn}, \npriset är {produktfast.Pris} & det är {produktfast.Enhet} pris. ");
                                    Console.WriteLine("Hur många kronor rabatt vill du ha i denna kampanj? ");
                                    while (true)
                                    {
                                        if (decimal.TryParse(Console.ReadLine().Trim(), out rabattfast) && rabattfast > 0 && rabattfast < produktfast.Pris)
                                            break;
                                        else Console.WriteLine("ange korrekt rabattmängd");
                                    }
                                    DateTime startdatum_ = DateTime.Today;
                                    DateTime slutdatum_;
                                    Console.WriteLine("Ange ett slutdatum för kampanjen, följ formatet yyyy-mm-dd: ");
                                    while (true)
                                    {
                                        if (DateTime.TryParse(Console.ReadLine(), out slutdatum_) && slutdatum_ > startdatum_)
                                            break;
                                        else Console.WriteLine("Oglitigt datum");
                                    }
                                    KampanjPris nyKampanj_ = new KampanjPris(produktfast, startdatum_, slutdatum_, rabattfast);
                                    kampanjer.Add(nyKampanj_);
                                    break;


                                case 0:
                                    return;

                            }
                        }



                    case 0:
                        return;

                    default:
                        Console.WriteLine("felaktig input, testa igen");
                        continue;
                }
            }
        }
    }
}
