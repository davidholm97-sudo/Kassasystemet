using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystemet
{
    internal class UI // här finns inmatning och utskrifter
    {
        static Dictionary<string, Produkt> produktregister = ProduktRegister.LasinProdukter();
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
                Console.Write("Ska fler varor skall läggas till? (ja/Nej): ");
                string fortsätta = Console.ReadLine().ToLower().Trim();
                if (fortsätta == "ja")
                {
                    return true;
                }
                else if (fortsätta == "nej")
                {
                    return false;
                }
                else
                    Console.WriteLine("felaktig input");
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
                Console.WriteLine("felaktig input");
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
        public static void Kvitto(List<Varukorgsrad> varukorg, decimal brutto, decimal netto)
        {
            Console.WriteLine($"""
                ______________________________Davids Livs_____________________________
                Vara            Antal     Pris     Summa
                """);
            var sortByName = varukorg
            .OrderBy(sort => sort.Produkt.Namn);
            foreach (Varukorgsrad rad in sortByName)
            {
                
                Console.WriteLine($"{rad.Produkt.Namn} - {rad.Antal} {rad.Produkt.Enhet} - {rad.RadPris} kr");
            }

            Console.WriteLine($"""
            Nettopris:                              {netto}
            Totalpris:                              {brutto}
            ----------------------------------------------------------------------
                                        Tack för ditt köp
            ----------------------------------------------------------------------
            """);
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
                Console.WriteLine($"Pris per enhet: {produktregister[id].Pris}");
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
                    Kvitto(kundberakning.Hamtarader(), brutto, netto);
                    break;
                }
                    
            }

        }
       
    }
}
