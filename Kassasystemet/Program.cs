using System.ComponentModel;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;

namespace Kassasystemet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                UI.Visameny();

                int menyval = UI.LasaMenyVal();

                switch (menyval)
                {
                    case 1:
                        UI.StartaNyKund();
                        break;

                    case 2:
                        /*Admin.VisaAdmin();*/
                        break;

                    case 3:
                        
                        Environment.Exit(0);
                        break;

                    default:
                        break;




                }

            }

            /*
            Console.WriteLine("Välkommen till Kassan");

                string[] rader = File.ReadAllLines("produkter.txt");
                Dictionary<string, Produkt> produkter = new Dictionary<string, Produkt>();
                    foreach (string rad in rader)
                    {
                        string[] delar = rad.Split(';');
                        produkter.Add(id, produkt);
                    }
                    if (produkter.ContainsKey("255"))
                    {
                        Console.WriteLine(produkter["255"]);
                    }

                int användarsvar = Convert.ToInt32(Console.ReadLine().Trim());
              
                switch (användarsvar)
                {
                    case 1:
                        Console.WriteLine("Ny kund! vänligen ange <PRODUKTID> samt <ANTAL/KG> ");
                        id = UI.LasaID();
                        fortsätta = UI.Nyvara();
                        if (fortsätta == "ja")
                        {

                        }
                        else
                        {
                            Console.WriteLine("Klicka på valfri knapp för att komma tillbaka till menyn: ");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        continue;

                    case 2:
                        Console.WriteLine("Admin");
                        break;

                    case 3:
                        Console.WriteLine("Tack och hej leverpastej");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("ogiltig input");
                        continue;
                }
            */
        }
    }
}
