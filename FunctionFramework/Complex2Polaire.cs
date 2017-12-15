using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperComputer;

namespace FunctionFramework
{
    public class Complex2Polaire : Function<string>
    {
        public string HelpMessage
        {
            get
            {
                return "write a Cartesian complex in a Polaire complex";
            }
        }

        public string Name
        {
            get
            {
                return "Pol";
            }
        }

        public string[] ParametersName
        {
            get
            {
                string[] param = new string[2];
                param.SetValue("R", 0);
                param.SetValue("Im", 1);
                return param;
            }
        }

        public string Evaluate(string[] args)
        {
            try
            {
                double x = double.Parse(args[0]);
                double y = double.Parse(args[1]);

                double arg = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                double azimut = CalculAngle(x, y) / Math.PI;

                // take 2 decimal after coma
                arg = Math.Round(arg, 2);
                azimut = Math.Round(azimut, 2);

                if (arg == 0 & azimut == 0)
                {
                    return "complex not valid";
                }

                string ans = string.Format("arg: {0} - az: {1}π", arg, azimut);
                Console.WriteLine(ans);

                return ans;
            }

            catch
            {
                throw new EvaluationException("Couldn't add the specified double");
            }
        }

        private double CalculAngle(double x, double y)
        {
            if (x > 0 & y >= 0)
            {
                return Math.Atan2(y, x);
            }
            else if (x > 0 & y < 0)
            {
                return Math.Atan(y / x) + 2 * Math.PI;
            }
            else if (x < 0)
            {
                return Math.Atan(y / x) + Math.PI;
            }
            else if (x == 0 & y > 0)
            {
                return Math.PI / 2;
            }
            else if (x == 0 & y < 0)
            {
                return 3 * Math.PI / 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
