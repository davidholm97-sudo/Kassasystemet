using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystemet
{
    internal class Admin
    {
        public static void Admin_Visameny()
        {
            Console.WriteLine("""
                    ==============Meny=============
                    [1] Lägg till en produkt
                    [2] Ändra befintlig produkt
                    [3] Avsluta

                    Val:
                    """);
        }
        public static void StartaAdmin(Dictionary<string, Produkt> produktregister)
        {
            int menyVal = UI.LasaMenyVal();
            switch (menyVal)
            {
                case 1:

                    break;

                case 2:
                    break;

                case 3:
                    break;

                default:
                    break;
            }
        }
    }
}
