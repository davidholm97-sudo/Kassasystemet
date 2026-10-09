using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystemet
{
    internal class UI
    {
        static Dictionary<string, Produkt> produktregister = ProduktRegister.LasinProdukter();
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
                    Console.WriteLine("tack för din tid");
            }
        }
        public static string LasaID()
        {
            while (true)
            {
                string id = Console.ReadLine().Trim().ToLower();
                if (!string.IsNullOrWhiteSpace(id))
                    return id;
                else
                Console.WriteLine("felaktig input eller produkt finns ej");
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
        public static void Kvitto(List<Varukorgsrad> varukorg, decimal total)
        {

            Console.WriteLine($"""
                ______________________________Davids Livs_____________________________
                Vara            Antal     Pris     Summa
                """);

            foreach (Varukorgsrad rad in varukorg)
            {
                Console.WriteLine($"{rad.Produkt.Namn} - {rad.Antal} {rad.Produkt.Enhet} - {rad.RadPris} kr");
            }

            Console.WriteLine("""
            ----------------------------------------------------------------------
                                        Tack för ditt köp
            ----------------------------------------------------------------------
            """);
        }

        public static void StartaNyKund()
        {
            List<Varukorgsrad> varukorgen = new List<Varukorgsrad>(); // fyll varukorgen
            
            while (true)
            {
                Console.WriteLine("Ange varans produkt-ID:");
                string id = LasaID();
                string enhet = produktregister[id].Enhet;
                Console.WriteLine($"Du sökte efter id: {id}, ");


                Console.WriteLine($"Tillagt: {produktregister[id].Namn}, hur många {enhet} vill du ha?");
                decimal antal = LasaAntal(); // läser in antal, antingen styck eller kg-vis 




                Varukorgsrad rad = new Varukorgsrad(produktregister[id], antal);
                Console.WriteLine($"Pris per enhet: {produktregister[id].Pris}");
                Console.WriteLine($"Radpris: {rad.RadPris} kr");
                varukorgen.Add(rad);
                bool fortsätta = Nyvara();


                if (fortsätta == true)
                {
                    continue;
                }
                else
                {
                    decimal total = Beräkningar.BeraknaTotal(varukorgen);
                    Kvitto(varukorgen, total);
                    break;
                }
                    
            }

        }
       
    }
}
