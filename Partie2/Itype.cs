using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie2
{
    interface Itype
    {
        double TaxeGestion();
    }

    class Particulier : Itype
    {
        public double TaxeGestion()
        {

            return 0d;
        }
    }

    class Entreprise : Itype
    {
        public double TaxeGestion()
        {

            return 0d;
        }
    }
}
