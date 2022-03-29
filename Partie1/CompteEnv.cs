using System;

namespace Partie1
{
    public class CompteEnv : Compte
    {
        private static CompteEnv _environnement;

        public static CompteEnv GetCompteEnv()
        {
            if (_environnement == null)
                _environnement = new CompteEnv(0);
            return _environnement;
        }

        private CompteEnv(uint compteID) : base(compteID)
        {
            base.solde = double.MaxValue;
        }

        public override bool LimiteRetrait(double montant)
        {
            return false;
        }
    }
}