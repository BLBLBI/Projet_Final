using System;
using System.IO;

namespace Partie1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string acctPath = path + @"\Comptes_1.txt";
            string trxnPath = path + @"\Transactions_1.txt";
            string sttsPath = path + @"\Statut_1.txt";

            //TODO: Votre implémentation
            Banque b = new Banque();

            b.InputComptes(acctPath);

            b.InputTransaction(trxnPath);

            b.OutputStatus(sttsPath);

            // Keep the console window open
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
