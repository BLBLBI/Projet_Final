using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();

            // Fichiers entrée
            string mngrPath = path + @"\Gestionnaires_1.txt";
            string acctPath = path + @"\Comptes_1.txt";
            string trxnPath = path + @"\Transactions_1.txt";

            //Fichiers sortie
            string sttsAcctPath = path + @"\StatutOpe_1.txt";
            string sttsTrxnPath = path + @"\StatutTra_1.txt";
            string mtrlPath = path + @"\Metrologie_1.txt";

            //TODO: Votre implémentation
            Banque b = new Banque();

            b.InputGest(mngrPath);
            b.InputComptes(acctPath);
            b.InputTransaction(trxnPath);

            // Keep the console window open
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
