using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionFramework
{
    [TestFixture()]
    class ChangeBaseTests
    {
        [Test()]
        public void TestCBEvaluate()
        {
            ChangeBase cb = new ChangeBase();

            string[] arr1 = new string[] { "2", "10", "2" };        //  2 en base 10 vers la base 2
            string[] arr2 = new string[] { "10", "2", "10" };       // 10 en base  2 vers la base 10
            string[] arr3 = new string[] { "-1", "2" };             // TODO
            string[] arr4 = new string[] { "4", "8" };              // TODO
            string[] arr5 = new string[] { "2", "-2" };             // TODO

            Assert.AreEqual("10", cb.Evaluate(arr1));
            Assert.AreEqual("2", cb.Evaluate(arr2));
            Assert.AreEqual(-1, cb.Evaluate(arr3));
            Assert.AreEqual(4, cb.Evaluate(arr4));
            Assert.AreEqual(-1, cb.Evaluate(arr5));
        }
    }
}