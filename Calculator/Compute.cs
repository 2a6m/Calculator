using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Compute
    {
        private string Calcul;

        public Compute(string calcul)
        {
            this.Calcul = calcul;
        }

        public override string ToString()
        {
            return this.Calcul;
        }
    }
}
