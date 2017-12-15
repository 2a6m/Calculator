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

            string[] arr1 = new string[] { "2", "2" };
            string[] arr2 = new string[] { "0", "2" };
            string[] arr3 = new string[] { "-1", "2" };
            string[] arr4 = new string[] { "4", "8" };
            string[] arr5 = new string[] { "2", "-2" };

            Assert.AreEqual(10, BC.Evaluate(arr1));
            Assert.AreEqual(0, BC.Evaluate(arr2));
            Assert.AreEqual(-1, BC.Evaluate(arr3));
            Assert.AreEqual(4, BC.Evaluate(arr4));
            Assert.AreEqual(-1, BC.Evaluate(arr5));
        }
    }
}
