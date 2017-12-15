using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperComputer;

namespace FunctionFramework
{
    public class Add : Function<string>
    {
        public Add()
        {

        }

        public string HelpMessage
        {
            get
            {
                return "help";
            }
        }

        public string Name
        {
            get
            {
                return "Add";
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

        public string Evaluate(string[] args)
        {
            Console.WriteLine(args);
            foreach(string arg in args)
            {
                Console.WriteLine(arg + " est de type" + arg.GetType());
            }
            try
            {
                double a = double.Parse(args[0]);
                double b = double.Parse(args[1]);
                double sum = a + b;
                return sum.ToString();
            }

            catch
            {
                throw new EvaluationException("Couldn't add the specified double");
            }
        }
    }
}