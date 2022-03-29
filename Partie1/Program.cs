using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string acctPath = path + @"\Comptes_1.txt";
            string trxnPath = path + @"\Transactions_1.txt";
            string sttsPath = path + @"\Statut_1.txt";

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
