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
            while (true)
            {
                Admin_Visameny();
                int menyVal = UI.LasaMenyVal();
                switch (menyVal)
                {
                    case 1:

                        break;

                    case 2:


                        string id = UI.LasaID();
                        Produkt produkt = produktregister[id];
                        string enhet = produktregister[id].Enhet;

                        Console.WriteLine($"Du sökte efter id: {id}, ");
                        Console.WriteLine($"Du vill ändra: {produktregister[id].Namn} \nSkriv in nya namnet för produkten");
                        string andraProduktNamn = produktregister[id].Namn;
                        decimal andraProduktPris = produktregister[id].Pris;

                        Console.WriteLine("Ange det nya namnet, eller klicka ENTER för att ändra pris");
                        andraProduktNamn = Console.ReadLine().Trim();
                        if (andraProduktNamn == "")
                            continue;

                            produkt.AndraNamn(andraProduktNamn);
                        produkt.AndraPris(andraProduktPris);

                        break;

                    case 3:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("felaktig input, testa igen");
                        continue;
                }
            }
        }
    }
}
