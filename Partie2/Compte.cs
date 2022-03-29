using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie2
{
    public class Compte
    {
        private readonly uint compteID;

        internal double solde;
        internal static double retraitMax = 1000d;

        internal List<Transaction> historique;

        public Compte(uint id, double soldeInit = 0d)
        {
            compteID = id;
            solde = soldeInit;
            historique = new List<Transaction>();
        }

        public uint GetCompteID()
        {
            return compteID;
        }

        public bool Depot(double montant)
        {
            if (montant <= 0)
                return false;

            solde += montant;
            return true;
        }

        public bool Retrait(double montant)
        {
            if (montant <= 0 || montant > solde)
                return false;

            if (LimiteRetrait(montant))
                return false;

            solde -= montant;
            return true;
        }

        internal virtual bool LimiteRetrait(double montant)
        {
            int i = 1;
            double limite = 0d;

            if (montant > retraitMax)
                return true;

            while (i < 10 && i <= historique.Count)
            {
                limite += historique[historique.Count - i].GetMontant();
                i++;
            }

            limite += montant;

            return limite > retraitMax;
        }

        public void AjoutTransaction(Transaction t)
        {
            historique.Add(t);
        }

        public override string ToString()
        {
            return $"{compteID} - {solde}";
        }
    }
}
