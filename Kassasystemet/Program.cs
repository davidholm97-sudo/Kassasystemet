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
                        Admin.Admin_Visameny();
                        //Admin.StartaAdmin();
                        break;

                    case 3:
                        
                        Environment.Exit(0);
                        break;

                    default:
                        break;

                }
            }
        }
    }
}
