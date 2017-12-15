using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionFramework
{
    [TestFixture()]
    class Complex2PolaireTests
    {
        [Test()]
        public void TestC2PEvaluate()
        {
            Complex2Polaire C2P = new Complex2Polaire();

            string[] arr1 = new string[] { "2", "2" };
            string[] arr2 = new string[] { "0", "2" };
            string[] arr3 = new string[] { "0", "0" };
            string[] arr4 = new string[] { "-4", "-2" };
            string[] arr5 = new string[] { "2", "-2" };

            string ans1 = string.Format("arg: {0} - az: {1}π", 2.83, 0.25);
            string ans2 = string.Format("arg: {0} - az: {1}π", 2, 0.5);
            string ans3 = "complex not valid";
            string ans4 = string.Format("arg: {0} - az: {1}π", 4.47, 1.15);
            string ans5 = string.Format("arg: {0} - az: {1}π", 2.83, 1.75);

            Assert.AreEqual(ans1, C2P.Evaluate(arr1));
            Assert.AreEqual(ans2, C2P.Evaluate(arr2));
            Assert.AreEqual(ans3, C2P.Evaluate(arr3));
            Assert.AreEqual(ans4, C2P.Evaluate(arr4));
            Assert.AreEqual(ans5, C2P.Evaluate(arr5));
        }
    }
}
