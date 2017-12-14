using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperComputer;

namespace FunctionFramework
{
    class Pythagore : Function<double>
    {
        public string HelpMessage
        {
            get
            {
                return "Compute the lenght of the hypothenuse when it receive the lenght of the 2 others sides of the triangle.";
            }
        }

        public string Name
        {
            get
            {
                return "Pyth";
            }
        }

        public string[] ParametersName
        {
            get
            {
                string[] param = new string[2];
                param.SetValue("a", 0);
                param.SetValue("b", 1);

                return param;
            }
        }

        public double Evaluate(string[] args)
        {
            try
            {
                double a = double.Parse(args[0]);
                double b = double.Parse(args[1]);
                if ( a >= 0 & b >= 0)
                {
                    return Math.Sqrt(Math.Pow(a,2) + Math.Pow(b,2));
                }
                else
                {
                    return -1;
                }
            }
            catch
            {
                throw new EvaluationException("Couldn't substract the specified int");
            }
        }
    }
}
