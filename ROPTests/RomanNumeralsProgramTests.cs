using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;

namespace ROP.Tests
{
    [TestClass()]
    public class RomanNumeralsProgramTests
    {
        [TestMethod()]
        public void RunCode_1666_ReturnsMDCLXVI()
        {
            var input = "1666";
            var expected = "MDCLXVI";

            string actual = Constants.EMPTY;
            RomanNumeralsProgram.RunCode(input)
                .OnSuccess((x) => actual = x);

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod()]
        public void RunCode_N_ReturnsN()
        {
            var input = "n";
            var expected = "N";

            var actual = RomanNumeralsProgram.RunCode(input);

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod()]
        public void RunCode_wrongInput_ReturnsN()
        {
            var input = "wrongInput";
            var expected = typeof(Exception);

            Exception actual = null;
            RomanNumeral.ConvertToI(input)
                .OnFailure((err) => actual = err);

            Assert.AreEqual(expected, actual.GetType());
        }
    }
}