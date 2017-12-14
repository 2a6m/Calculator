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
        public void TestEvaluate()
        {
            Factorial Fact = new Factorial();

            string[] arr1 = new string[] { "2" };
            string[] arr2 = new string[] { "-1" };
            string[] arr3 = new string[] { "0" };
            string[] arr4 = new string[] { "4" };

            Assert.AreEqual(2, Fact.Evaluate(arr1));
            Assert.AreEqual(0, Fact.Evaluate(arr2));
            Assert.AreEqual(0, Fact.Evaluate(arr3));
            Assert.AreEqual(24, Fact.Evaluate(arr4));
        }
    }
}
