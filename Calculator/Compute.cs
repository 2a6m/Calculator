using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Compute
    {
        public float A;
        public float B;
        public string Fct;

        public Compute(float a, float b, string fct)
        {
            this.A = a;
            this.B = b;
            this.Fct = fct;
        }

        public override string ToString()
        {
            string txt = string.Format("> {0} {1} {2}", this.A.ToString(), this.Fct, this.B.ToString());
            txt += Environment.NewLine;
            txt += string.Format("{0}", this.Calcul());
            txt += Environment.NewLine;
            txt += Environment.NewLine;
            return txt;
        }

        public float Calcul()
        {
            float result = 0;

            if (this.Fct == "/")
                result = this.A / this.B;
            if (this.Fct == "*")
                result = this.A * this.B;
            if (this.Fct == "-")
                result = this.A - this.B;
            if (this.Fct == "+")
                result = this.A + this.B;

            return result;
        }

    }
}
