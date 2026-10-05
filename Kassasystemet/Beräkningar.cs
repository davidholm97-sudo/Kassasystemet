using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Kassasystemet
{
    internal class Beräkningar
    {

        public static decimal BeraknaTotal(List<Varukorgsrad> varukorg)
        {
            decimal total = 0;

            foreach (Varukorgsrad rad in varukorg)
                total += rad.RadPris;

            decimal totalMedMoms = total * 1.25m;

            return totalMedMoms;
        }
    }
}
