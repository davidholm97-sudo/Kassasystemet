using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystemet
{
    internal class Admin
    {
       
        public static void StartaAdmin(Dictionary<string, Produkt> produktregister)
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
                        File.WriteAllLines(sokFilvag, produktregister.Values.Select(produkt => $"{produkt.Id};{produkt.Namn};{produkt.Pris};{produkt.Enhet}"));
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
                        File.WriteAllLines(sokFilvag, produktregister.Values.Select(produktregister => $"{produkt.Id};{produkt.Namn};{produkt.Pris};{produkt.Enhet}"));

                        break;

                    case 3:
                        return;

                    default:
                        Console.WriteLine("felaktig input, testa igen");
                        continue;
                }
            }
        }
    }
}
