using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperComputer;

namespace FunctionFramework
{
    public class ChangeBase : Function<string>
    {
        public string HelpMessage
        {
            get
            {
                return ("Convert a number 'a' in base 'b' to a number in base 'c'. ");
            }
        }

        public string Name
        {
            get
            {
                return "BaseChange";
            }
        }

        public string[] ParametersName
        {
            get
            {
                string[] param = new string[3];
                param.SetValue("a", 0);
                param.SetValue("b", 1);
                param.SetValue("c", 2);
                return param;
            }
        }

        public string Evaluate(string[] args)
        {
            try
            {
                int baseten = read(args);
                int c = int.Parse(args[2]);
                string ans = translate(baseten, c);
                return ans;
            }
            catch(Exception e)
            {
                throw new EvaluationException("Could not change " + args[0] + " of base" 
                    + args[1] + " to base " + args[2] +": " + e.Message);
            }
        }



        //  Read 

        private int read(String[] args)
        {
            try
            {
                int len = args[1].Count();
                int b = int.Parse(args[1]);
                string a = args[0];
                a = fill(a, b);
                List<int> listdig = digitalize(a, len);
                Console.WriteLine(listdig);
                return tobaseten(listdig, b);
            }
            catch (Exception e)
            {
                throw new EvaluationException("First step conversion could not convert " + args[0] + " of base " + args[1] + " to base 10: " + e.Message);
            }
        }

        private string fill(string a, int b)
        {
            /* Fixes the string in case the user forgot to introduce 0's before its most signigficant digit. */

            int len = ((b - 1).ToString()).Count();
            while ((a.Count() % len) != 0)
            {
                Console.WriteLine(a);
                a = '0' + a;
            }
            return a;
        }

        private List<int> digitalize(string a, int len)
        {
            /* Transforms the string into a list of digits */
            try
            {
                List<int> listdig = new List<int>();
                for (int j = 0; j <= a.Count() - len; j += len)
                {
                    string subs = a.Substring(j, len);
                    int digit = int.Parse(subs);
                    listdig.Add(digit);

                }
                return listdig;
            }
            catch(Exception e)
            {
                throw new EvaluationException("Couldn't digitalize " + a + ": " + e.Message);
            }
        }

        private int tobaseten(List<int> listdig, int b)
        {
            /* Core algorithm to translate any number to base 10. */
            int len = listdig.Count();
            if (len != 0)
            {
                int last = listdig[len - 1];
                listdig.RemoveAt(len - 1);
                return last + (b * tobaseten(listdig, b));
            }
            else
            {
                return (int)0;
            }
        }


        // Translate

        private string translate(int b, int c)
        {
            try
            {
                if (c <= 1)
                {
                    throw new EvaluationException("'c' must be ant integer > 1");
                }
                else if (b >= 0 & b > 0)
                {
                    return convert(b, c);
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
            /*Core algorithm to convert a base 10 integer 'a' to base 'b' */
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
    }
}