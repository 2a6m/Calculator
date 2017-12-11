using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionFramework
{
    public interface Function<T>
    {
        string Name { get; }

        string HelpMessage { get; }

        string[] ParametersName { get; }

        T Evaluate(string[] args);
    }

    public class EvaluationException : Exception
    {
        public EvaluationException(string msg) : base(msg)
        {

        }
    }
}