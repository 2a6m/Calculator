using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionFramework
{
    [TestFixture()]
    class SubTest
    {
        [Test()]
        public void TestSEvaluate()
        {
            Sub S = new Sub();

            // check that the code give the good answer

            string[] arr1 = new string[] { "2", "-2" };
            string[] arr2 = new string[] { "-1", "2" };
            string[] arr3 = new string[] { "0", "2" };
            string[] arr4 = new string[] { "2", "2" };
            string[] arr5 = new string[] { "4", "0" };

            Assert.AreEqual("4", S.Evaluate(arr1));
            Assert.AreEqual("-3", S.Evaluate(arr2));
            Assert.AreEqual("-2", S.Evaluate(arr3));
            Assert.AreEqual("0", S.Evaluate(arr4));
            Assert.AreEqual("4", S.Evaluate(arr5));

            // check that the method throw the good Exception

            string[] err1 = new string[] { "a", "b" };
            string[] err2 = new string[] { "a" };

            Assert.That(delegate { S.Evaluate(err1); }, Throws.TypeOf<SuperComputer.EvaluationException>());
            Assert.That(delegate { S.Evaluate(err2); }, Throws.TypeOf<SuperComputer.EvaluationException>());
        }
    }
}
