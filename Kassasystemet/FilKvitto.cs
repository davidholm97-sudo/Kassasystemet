using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystemet
{
    internal class FilKvitto : IFilKvitto
    {
        public void SparaKvitto(string kvittotext)
        {
            string filnamn = $"RECEIPT_{DateTime.Now: yyyyMMdd}.txt";// vi skapar nya filer baserat på dag. som en "dagskassa" ish 
            File.AppendAllText(filnamn, kvittotext);
            Console.WriteLine(Path.GetFullPath($"\nRECEIPT_{DateTime.Now: yyyyMMdd}.txt")); // ta bort, söker fram vart receipts landar
        }
    }
}
