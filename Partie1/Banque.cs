using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Partie1
{
    public class Banque
    {
        List<Compte> comptes;
        List<Transaction> transactions;

        public Banque()
        {
            comptes = new List<Compte>();
            transactions = new List<Transaction>();

            comptes.Add(CompteEnv.GetCompteEnv());
        }

        public bool CreateCompte(uint id, double solde = 0d)
        {
            foreach (Compte c in comptes)
            {
                if (c.GetCompteID() == id)
                {
                    Console.WriteLine($"id {id} déja existant");
                    return false;
                }
            }
            comptes.Add(new Compte(id, solde));
            return true;
        }

        public void CreateTransaction(long id, double montant, Compte exp, Compte dest)
        {
            Transaction t = new Transaction(id, montant, exp, dest);

            foreach (Transaction tr in transactions)
            {
                if (tr.GetTransID() == id)
                {
                    t.statut = Transaction.Status.KO;
                }
            }
            transactions.Add(t);
        }

        public void ExecTransaction()
        {
            foreach (Transaction t in transactions)
            {
                if (t.statut == Transaction.Status.OK)
                {
                    if (t.expediteur.Retrait(t.GetMontant()))
                    {
                        t.destinataire.Depot(t.GetMontant());
                    }
                    else
                    {
                        t.statut = Transaction.Status.KO;
                    }
                }
            }
        }

        public void InputComptes(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string l;

                while ((l = reader.ReadLine()) != null)
                {
                    string[] t = l.Split(';');

                    if (uint.TryParse(t[0], out uint id))
                    {
                        if (double.TryParse(t[1], out double s))
                        {
                            CreateCompte(id, s);
                        }
                        else
                        {
                            CreateCompte(id);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"id '{t[0]}' erroné");
                    }
                }
            }
        }

        public void InputTransaction(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string l;

                while ((l = reader.ReadLine()) != null)
                {
                    Compte exp = null;
                    Compte dest = null;

                    string[] t = l.Split(';');

                    if (long.TryParse(t[0], out long id)
                     && double.TryParse(t[1], out double montant)
                     && uint.TryParse(t[2], out uint e)
                     && uint.TryParse(t[3], out uint d))
                    {
                        foreach (Compte c in comptes)
                        {
                            if (c.GetCompteID() == e)
                            {
                                exp = c;
                            }
                            else if (c.GetCompteID() == d)
                            {
                                dest = c;
                            }
                        }
                        CreateTransaction(id, montant, exp, dest);
                    }
                }
            }
            ExecTransaction();
        }

        public void OutputStatus(string path)
        {
            using (TextWriter writer = new StreamWriter(path))
            {
                foreach (Transaction t in transactions)
                {
                    writer.WriteLine($"{t.GetTransID()};{t.statut}");
                }
            }
        }

        public override string ToString()
        {
            string s = "";
            foreach (Compte c in comptes)
            {
                s += c.ToString() + "\n";
            }
            return s;
        }
    }
}
