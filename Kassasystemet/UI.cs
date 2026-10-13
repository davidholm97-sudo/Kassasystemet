using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystemet
{
    internal class UI // här finns inmatning och utskrifter
    {
        public static Dictionary<string, Produkt> produktregister = ProduktRegister.LasinProdukter();
        public UI()
        {

        }
        public static void Visameny()
        {
            Console.WriteLine("""
                    ==============Meny=============
                    [1] Ny Kund
                    [2] Admin
                    [3] Avsluta

                    Val:
                    """);
        }
        public static bool Nyvara()
        {
            while (true)
            {
                Console.WriteLine("PAY för att avsluta, ENTER för att lägga till fler produkter");
                string fortsätta = Console.ReadLine().ToUpper().Trim();
                if (fortsätta == "PAY")
                {
                    return false;
                }
                else if (fortsätta == "")
                {
                    return true;
                }
                else
                    Console.WriteLine("Felaktig input");
            }
        }
        public static int LasaMenyVal()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int val))
                {
                    return val;
                }
                Console.WriteLine("Felaktig input");
            }
        }

        public static decimal LasaAntal()
        {
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out decimal antal) && antal > 0)
                {
                    return antal;
                }

                Console.WriteLine("Felaktig input, ange ett positivt tal.");
            }
        }
        public static void SparaKvitto(string kvittotext)
        {
            string filnamn = $"RECEIPT_{DateTime.Now: yyyyMMdd}.txt";// vi skapar nya filer baserat på dag. som en "dagskassa" ish 
            File.AppendAllText(filnamn, kvittotext);
            Console.WriteLine(Path.GetFullPath("Receipts.txt")); // ta bort, söker fram vart receipts landar
        }
        public static string Kvitto(List<Varukorgsrad> varukorg, decimal brutto, decimal netto)
        {
            string kvitto = "";
            DateTime kvittotid = DateTime.Now;
            kvitto += ($"""
                ______________________________Davids Livs_____________________________
                Vara                        Antal           Pris     

                """ + Environment.NewLine);
            var sortByName = varukorg
            .OrderBy(sort => sort.Produkt.Namn); // sortering för skoj 
            foreach (Varukorgsrad rad in sortByName)
            {
                kvitto += ($"\n{rad.Produkt.Namn, -18} - {rad.Antal,8} {rad.Produkt.Enhet,6}   - {rad.RadPris,9:F2} kr" + Environment.NewLine);

            }

            kvitto +=($"""

            Nettopris:                                  {netto:F2}kr
            Totalpris:                                  {brutto:F2}kr
            Tidpunkt:                                   {kvittotid:yyyy-MM-dd HH:mm}

            ----------------------------------------------------------------------
                                        Tack för ditt köp
            ----------------------------------------------------------------------
            """ + Environment.NewLine); // skriver ut netto brutto med två decimaler
            return kvitto;
        }
        public static string LasaID()
        {
            while (true)
            {
                Console.WriteLine("Ange varans produkt-ID:");
                string id = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrWhiteSpace(id))
                {
                    continue;
                }
                if (!produktregister.ContainsKey(id))
                {
                    Console.WriteLine("produkten finns inte");
                    continue;
                }
                return id;

            }
        }

        public static void StartaNyKund()
        {
            Kundberakning kundberakning = new Kundberakning();
            while (true)
            {
                string id = LasaID();
                string enhet = produktregister[id].Enhet;

                Console.WriteLine($"Du sökte efter id: {id}, ");
                Console.WriteLine($"Tillagt: {produktregister[id].Namn}, hur många {enhet} vill du ha?");
                decimal antal = LasaAntal(); // läser in antal, antingen styck eller kg-vis 

                Varukorgsrad rad = kundberakning.LaggTill(produktregister[id], antal);
                Console.WriteLine($"Pris per {enhet}: {produktregister[id].Pris}");
                Console.WriteLine($"Radpris: {rad.RadPris} kr");
                bool fortsätta = Nyvara();

                if (fortsätta == true)
                {
                    continue;
                }
                else
                {
                    decimal brutto = kundberakning.BeraknaTotalPris();
                    decimal netto = kundberakning.BeraknaNettoPris();
                    string kvittotext = Kvitto(kundberakning.Hamtarader(), brutto, netto);
                    Console.WriteLine(kvittotext);
                    SparaKvitto(kvittotext);
                    break;
                }
                    
            }

        }
       
    }
}
