using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie2
{
    class Gestionnaire
    {
        private readonly uint gestID;

        private uint nbTrans;

        private double totalTaxes;

        List<Compte> comptes;

        private Itype _type;

        public Gestionnaire(uint id, Itype t, uint nbTr)
        {
            gestID = id;
            nbTrans = nbTr;
            _type = t;
            totalTaxes = 0d;

            comptes = new List<Compte>
            {
                CompteEnv.GetCompteEnv()
            };
        }

        public uint GetGestID()
        {
            return gestID;
        }

        public void SetType(Itype t)
        {
            _type = t;
        }

        public bool CreateCompte(uint id, DateTime crea, double solde = 0d)
        {
            foreach (Compte c in comptes)
            {
                if (c.GetCompteID() == id)
                {
                    Console.WriteLine($"id {id} déja existant");
                    return false;
                }
            }

            if (solde < 0d)
                return false;

            comptes.Add(new Compte(id, crea, solde));

            return true;
        }
    }
}
