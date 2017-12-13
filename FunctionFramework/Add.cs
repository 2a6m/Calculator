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
                param.SetValue("double A", 0);
                param.SetValue("double B", 1);
                return param;
            }
        }

        public string Evaluate(string[] args)
        {
            try
            {
                double a = double.Parse(args[0]);
                double b = double.Parse(args[1]);
                return (a + b).ToString();
            }

            catch
            {
                throw new EvaluationException("Couldn't add the specified double");
            }
        }
    }
}