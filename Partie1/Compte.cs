using System;
using System.Collections.Generic;

namespace Partie1
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

        public void Depot(double montant)
        {
            if (montant <= 0)
                throw new Exception("Montant erroné");

            solde += montant;
        }

        public bool Retrait(double montant)
        {
            if (montant <= 0 || montant > solde)
                return false;
            //throw new Exception("Montant erroné");

            if (LimiteRetrait(montant))
                return false;
                //throw new Exception("Limite de retrait atteinte");

            solde -= montant;
            return true;
        }

        public virtual bool LimiteRetrait(double montant)
        {
            int i = 1;
            double limite = 0d;

            if (montant > retraitMax)
                return true;

            //TODO: retrait uniquement
            while (i < 10 && i <= historique.Count)
            {
                if (historique[historique.Count - i].statut == Transaction.Status.OK)
                {
                    limite += historique[historique.Count - i].GetMontant();
                    i++;
                }
            }

            limite += montant;

            return limite > retraitMax;
        }

        public void AjoutTraansaction(Transaction t)
        {
            historique.Add(t);
        }

        public override string ToString()
        {
            return $"{compteID} - {solde}";
        }
    }
}