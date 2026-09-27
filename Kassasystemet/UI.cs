using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystemet
{
    internal class UI
    {
        public static void Visameny()
        {
            Console.WriteLine("""
                    ==============Meny=============
                    [1] Ny Kund
                    [2] Admin
                    [3] Avsluta

                    Val:
                    """);

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
        public string LasaID()
        {
            string id = Console.ReadLine().Trim().ToLower();
            if (string.IsNullOrWhiteSpace(id))
            {
                cw
            }
            return id;
        }







    }
}
