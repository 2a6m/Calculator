using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionFramework
{
    [TestFixture()]
    class PythagoreTest
    {
        [Test()]
        public void TestPTvaluate()
        {
            Pythagore PT = new Pythagore();

            // check that the code give the good answer

            string[] arr1 = new string[] { "2", "-2" };
            string[] arr2 = new string[] { "-1", "2" };
            string[] arr3 = new string[] { "0", "2" };
            string[] arr4 = new string[] { "2", "2" };
            string[] arr5 = new string[] { "4", "0" };

            //Assert.AreEqual(1, PT.Evaluate(arr1));
            Assert.AreEqual(Math.Sqrt(5), PT.Evaluate(arr2));
            Assert.AreEqual(2, PT.Evaluate(arr3));
            Assert.AreEqual(2 * Math.Sqrt(2), PT.Evaluate(arr4));
            Assert.AreEqual(4, PT.Evaluate(arr5));

            // check that the method throw the good Exception

            string[] err1 = new string[] { "a", "b" };
            string[] err2 = new string[] { "a" };

            Assert.That(delegate { PT.Evaluate(err1); }, Throws.TypeOf<SuperComputer.EvaluationException>());
            Assert.That(delegate { PT.Evaluate(err2); }, Throws.TypeOf<SuperComputer.EvaluationException>());
        }
    }
}
