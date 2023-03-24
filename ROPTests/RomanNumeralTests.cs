using Microsoft.VisualStudio.TestTools.UnitTesting;
using ROP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROP.Tests
{
    [TestClass()]
    public class RomanNumeralTests
    {
        [TestMethod()]
        public void ConvertToI_5_Succeeds()
        {
            var input = "5";
            var expected = "IIIII";

            var actual = RomanNumeral.ConvertToI(input);
            Assert.AreEqual(expected, actual);
        }
    }
}