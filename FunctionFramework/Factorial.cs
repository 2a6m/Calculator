using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperComputer;

namespace FunctionFramework
{
    public class Factorial : Function<int>
    {
        public string HelpMessage
        {
            get
            {
                return "compute the factorial of x";
            }
        }

        public string Name
        {
            get
            {
                return "Fact";
            }
        }

        public string[] ParametersName
        {
            get
            {
                string[] param = new string[1];
                param.SetValue("x", 0);
                return param;
            }
        }

        public int Evaluate(string[] args)
        {
            try
            {
                int x = int.Parse(args[0]);
                if (x >= 0)
                {
                    int ans = Fact(x);
                    return ans;
                }
                else
                {
                    throw new EvaluationException("the number must be positif");
                }
            }
            catch
            {
                throw new EvaluationException("Couldn't substract the specified int");
            }
        }

        private int Fact(int nbr)
        {
            if (nbr == 0)
            {
                return 1;
            }
            else
            {
                return nbr * Fact(nbr - 1);
            }
        }
    }
}
