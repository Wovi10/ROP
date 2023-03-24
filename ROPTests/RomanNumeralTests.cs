using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;

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

            string actual = Constants.EMPTY;
            RomanNumeral.ConvertToI(input)
                .OnSuccess((x) => actual = x)
                .OnFailure((err) => actual = err.Message);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertToI_N_ReturnsN()
        {
            var input = "N";
            var expected = "N";

            string actual = Constants.EMPTY;
            RomanNumeral.ConvertToI(input)
                .OnSuccess((x) => actual = x);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertToI_InvalidInput_ReturnsException()
        {
            var input = "ferwcsd";
            var expected = typeof(Exception);

            Exception actual = null;
            RomanNumeral.ConvertToI(input)
                .OnFailure((err) => actual = err);

            Assert.AreEqual(expected, actual.GetType());
        }

        [TestMethod()]
        public void ConvertToI_EMPTYInput_ReturnsException()
        {
            var input = Constants.EMPTY;
            var expected = typeof(Exception);

            Exception actual = null;
            RomanNumeral.ConvertToI(input)
                .OnFailure((err) => actual = err);

            Assert.AreEqual(expected, actual.GetType());
        }
    }
}