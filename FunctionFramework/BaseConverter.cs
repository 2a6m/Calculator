using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperComputer;

namespace FunctionFramework
{
    public class BaseConverter : Function<int>
    {
        public string HelpMessage
        {
            get
            {
                return "Convert a number 'a' in base 10 to a number in base 'b'.";
            }
        }

        public string Name
        {
            get
            {
                return "BaseConverter";
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

        public int Evaluate(string[] args)
        {
            //Transform the parameters to int and then converts them
            try
            {
                int[] param = Parser(args);
                if (param[1] <= 1)
                {
                    throw new EvaluationException("'b' must be > 1");
                }
                else if (param[0] >= 0 & param[1] > 0)
                {
                    int ans = int.Parse(convert(param[0], param[1]));
                    return ans;
                }
                else
                {
                    throw new EvaluationException("'a' must be bigger than 'b'");
                }
            }
            catch (Exception e)
            {
                throw new EvaluationException("Couldn't BaseConvert: " + e.Message);
            }
        }

        private string convert(int a, int b)
        {
            //Recursively convert an integer 'a' in base 'b'
            int remainder = a % b;
            int quotient = a / b;
            if (quotient == 0)
            {
                return remainder.ToString();
            }
            else
            {
                return convert(quotient, b) + remainder.ToString();
            }
        }

        private int[] Parser(string[] args)
        {
            //Transforms the list of parameters into integers
            try
            {
                int a = int.Parse(args[0]);
                int b = int.Parse(args[1]);
                int[] ans = { a, b };
                return ans;
            }
            catch
            {
                throw new EvaluationException("Couldn't convert the arguments to integers. ");
            }
        }
    }
}