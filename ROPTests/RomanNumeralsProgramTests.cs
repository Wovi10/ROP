using Microsoft.VisualStudio.TestTools.UnitTesting;
using ROP;

namespace ROPTests;

[TestClass]
public class RomanNumeralsProgramTests
{
    [TestMethod]
    public void RunCode_1666_ReturnsMDCLXVI()
    {
        const string input = "1666";
        const string expected = "MDCLXVI";

        var actual = string.Empty;
        input
            .ConvertToRoman()
            .OnSuccess(x => actual = x);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void RunCode_N_ReturnsN()
    {
        const string input = "n";
        const string expected = "N";

        var actual = input.ConvertToRoman();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void RunCode_wrongInput_ReturnsException()
    {
        const string input = "wrongInput";
        var expected = typeof(Exception);

        Exception? actual = null;
        input
            .ConvertToRoman()
            .OnFailure(err => actual = err);

        Assert.AreEqual(expected, actual?.GetType());
    }
}