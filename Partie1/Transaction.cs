using System;

namespace Partie1
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
    }
}
