using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionFramework
{
    [TestFixture()]
    class BaseConverterTests
    {
        [Test()]
        public void TestBCEvaluate()
        {
            BaseConverter BC = new BaseConverter();

            // check that the code give the good answer

            string[] arr1 = new string[] { "2", "2" };
            string[] arr2 = new string[] { "0", "2" };
            string[] arr3 = new string[] { "4", "8" };

            Assert.AreEqual(10, BC.Evaluate(arr1));
            Assert.AreEqual(0, BC.Evaluate(arr2));
            Assert.AreEqual(4, BC.Evaluate(arr3));

            // check that the method throw the good Exception

            string[] err1 = new string[] { "a", "b" };
            string[] err2 = new string[] { "a" };
            string[] err3 = new string[] { "-1" };
            string[] err4 = new string[] { "-1", "2" };
            string[] err5 = new string[] { "2", "-2" };

            Assert.That(delegate { BC.Evaluate(err1); }, Throws.TypeOf<SuperComputer.EvaluationException>());
            Assert.That(delegate { BC.Evaluate(err2); }, Throws.TypeOf<SuperComputer.EvaluationException>());
            Assert.That(delegate { BC.Evaluate(err3); }, Throws.TypeOf<SuperComputer.EvaluationException>());
            Assert.That(delegate { BC.Evaluate(err4); }, Throws.TypeOf<SuperComputer.EvaluationException>());
            Assert.That(delegate { BC.Evaluate(err5); }, Throws.TypeOf<SuperComputer.EvaluationException>());
        }
    }
}
