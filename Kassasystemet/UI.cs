using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystemet
{
    internal class UI
    {
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
            int.TryParse.Console.ReadLine(out användarinput);
            switch (användarinput)
                case "1":
                {

                }
            }


        public static string Nyvara()
        {
            while (true)
            {
                Console.Write("Ska fler varor skall läggas till? (ja/Nej): ");
                string fortsätta = Console.ReadLine().ToLower().Trim();
                if (fortsätta == "ja" || fortsätta == "nej")
                {
                    return fortsätta;
                }
                else
                {
                    Console.WriteLine("felaktig input, försök igen");
                }
            }
        }
        public static string LasaID()
        {
            while (true)
            {
                string id = Console.ReadLine().Trim().ToLower();
                if (!string.IsNullOrWhiteSpace(id))
                {
                    return id;
                }
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

        public static void StartaNyKund()
        {
            Console.WriteLine("Ange varans produkt-ID:");

            string id = LasaID();

            Console.WriteLine($"du skrev {id}");
        }
    }
}
