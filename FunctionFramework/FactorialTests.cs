using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionFramework
{
    [TestFixture()]
    class FactorialTests
    {
        [Test()]
        public void TestFEvaluate()
        {
            Factorial Fact = new Factorial();

            // check that the code give the good answer

            string[] arr1 = new string[] { "2" };
            string[] arr2 = new string[] { "0" };
            string[] arr3 = new string[] { "4" };
            

            Assert.AreEqual(2, Fact.Evaluate(arr1));
            Assert.AreEqual(1, Fact.Evaluate(arr2));
            Assert.AreEqual(24, Fact.Evaluate(arr3));

            // check that the method throw the good Exception

            string[] err1 = new string[] { "a", "b" };
            string[] err2 = new string[] { "a" };
            string[] err3 = new string[] { "-1" };

            Assert.That(delegate { Fact.Evaluate(err1); }, Throws.TypeOf<SuperComputer.EvaluationException>());
            Assert.That(delegate { Fact.Evaluate(err2); }, Throws.TypeOf<SuperComputer.EvaluationException>());
            Assert.That(delegate { Fact.Evaluate(err3); }, Throws.TypeOf<SuperComputer.EvaluationException>());
        }
    }
}
