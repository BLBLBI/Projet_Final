using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie1__mais_mieux_
{
    public class Transaction
    {
        private readonly long transID;

        private readonly double montant;

        public Compte expediteur;

        public Compte destinataire;

        public Status statut;

        public enum Status
        {
            OK,
            KO
        }

        public Transaction(long id, double m, Compte exp, Compte dest)
        {
            transID = id;
            montant = m;
            expediteur = exp;
            destinataire = dest;

            statut = exp == null || dest == null ? Status.KO : Status.OK;
        }

        public long GetTransID()
        {
            return transID;
        }

        public double GetMontant()
        {
            return montant;
        }

        public void ExecTransaction()
        {
            if (statut == Transaction.Status.OK)
            {
                if (expediteur.Retrait(GetMontant()))
                {
                    destinataire.Depot(GetMontant());
                    expediteur.AjoutTransaction(this);
                    destinataire.AjoutTransaction(this);
                }
                else
                {
                    statut = Transaction.Status.KO;
                }
            }
        }
    }
}
