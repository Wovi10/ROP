using Microsoft.VisualStudio.TestTools.UnitTesting;
using ROP;
using Utils;

namespace ROPTests;

[TestClass]
public class RomanNumeralTests
{
    #region Validate

    [TestMethod]
    public void Validate_0_ReturnsNoZeroException()
    {
        const string input = "0";
        var expected = typeof(NoZeroException);

        input
            .Validate()
            .TryGetError(out var actual);

        Assert.AreEqual(expected, actual?.GetType());
    }

    [TestMethod]
    public void Validate_InvalidInput_ReturnsNaNException()
    {
        const string input = "wrongInput";
        var expected = typeof(NaNException);

        input
            .Validate()
            .TryGetError(out var actual);

        Assert.AreEqual(expected, actual.GetType());
    }

    [TestMethod]
    public void Validate_ValidInput_ReturnsInput()
    {
        const string input = "123";
        const string expected = "123";

        input
            .Validate()
            .TryGetResult(out var actual);

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region Sanitise

    [TestMethod]
    public void Sanitise_000123_Returns123()
    {
        const string input = "000123";
        const string expected = "123";

        input
            .Sanitise()
            .TryGetResult(out var actual);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Sanitise_123_Returns123()
    {
        const string input = "123";
        const string expected = "123";

        input
            .Sanitise()
            .TryGetResult(out var actual);

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region ToStringArray

    [TestMethod]
    public void ToStringArray_123_ReturnsArray()
    {
        const string input = "123";
        var expected = new[] {"1", "2", "3"};

        input
            .ToStringArray()
            .TryGetResult(out var actual);

        CollectionAssert.AreEqual(expected, actual);
    }

    #endregion

    #region ToIntArray

    [TestMethod]
    public void ToIntArray_123_ReturnsArray()
    {
        var input = new[] {"1", "2", "3"};
        var expected = new[] {1, 2, 3};

        input
            .ToIntArray()
            .TryGetResult(out var actual);

        CollectionAssert.AreEqual(expected, actual);
    }

    #endregion

    #region ConvertToI

    [TestMethod]
    public void ConvertToI_1_ReturnsI()
    {
        const int input = 1;
        const string expected = Constants.I;

        input
            .ConvertToI()
            .TryGetResult(out var actual);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ConvertToI_2_ReturnsII()
    {
        const int input = 2;
        const string expected = Constants.I + Constants.I;

        input
            .ConvertToI()
            .TryGetResult(out var actual);

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region ReplaceIWithIV

    [TestMethod]
    public void ReplaceIWithIV_II_ReturnsIV()
    {
        const string input = Constants.I_BecomesIV;
        const string expected = Constants.IV;

        input
            .ReplaceIWithIV()
            .TryGetResult(out var actual);

        Assert.AreEqual(expected, actual);
    }

    #endregion
    
    #region ReplaceIWithV

    [TestMethod]
    public void ReplaceIWithV_II_ReturnsV()
    {
        const string input = Constants.I_BecomesV;
        const string expected = Constants.V;

        input
            .ReplaceIWithV()
            .TryGetResult(out var actual);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ReplaceIWithV_II_ReturnsVV()
    {
        const string input = Constants.I_BecomesV + Constants.I_BecomesV;
        const string expected = Constants.V + Constants.V;

        input
            .ReplaceIWithV()
            .TryGetResult(out var actual);

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region ReplaceIWithIX

    [TestMethod]
    public void ReplaceIWithIX_II_ReturnsIX()
    {
        const string input = Constants.VI_BecomesIX;
        const string expected = Constants.IX;

        input
            .ReplaceIWithIX()
            .TryGetResult(out var actual);

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region ReplaceVWithX

    [TestMethod]
    public void ReplaceVWithX_V_ReturnsX()
    {
        const string input = Constants.V + Constants.V;
        const string expected = Constants.X;

        input
            .ReplaceVWithX()
            .TryGetResult(out var actual);

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region ReplaceXWithXL

    [TestMethod]
    public void ReplaceXWithXL_X_ReturnsXL()
    {
        const string input = Constants.X_BecomesXL;
        const string expected = Constants.XL;

        input
            .ReplaceXWithXL()
            .TryGetResult(out var actual);

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region ReplaceXWithL

    [TestMethod]
    public void ReplaceXWithL_X_ReturnsL()
    {
        const string input = Constants.X_BecomesL;
        const string expected = Constants.L;

        input
            .ReplaceXWithL()
            .TryGetResult(out var actual);

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region ReplaceXWithXC

    [TestMethod]
    public void ReplaceXWithXC_L_ReturnsXC()
    {
        const string input = Constants.LX_BecomesXC;
        const string expected = Constants.XC;

        input
            .ReplaceXWithXC()
            .TryGetResult(out var actual);

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region ReplaceLWithC

    [TestMethod]
    public void ReplaceLWithC_L_ReturnsC()
    {
        const string input = Constants.L_BecomesC;
        const string expected = Constants.C;

        input
            .ReplaceLWithC()
            .TryGetResult(out var actual);

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region ReplaceCWithCD

    [TestMethod]
    public void ReplaceCWithCD_C_ReturnsCD()
    {
        const string input = Constants.C_BecomesCD;
        const string expected = Constants.CD;

        input
            .ReplaceCWithCD()
            .TryGetResult(out var actual);

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region ReplaceCWithD

    [TestMethod]
    public void ReplaceCWithD_C_ReturnsD()
    {
        const string input = Constants.C_BecomesD;
        const string expected = Constants.D;

        input
            .ReplaceCWithD()
            .TryGetResult(out var actual);

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region ReplaceCWithCM

    [TestMethod]
    public void ReplaceCWithCM_C_ReturnsCM()
    {
        const string input = Constants.DC_BecomesCM;
        const string expected = Constants.CM;

        input
            .ReplaceCWithCM()
            .TryGetResult(out var actual);

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region ReplaceDWithM

    [TestMethod]
    public void ReplaceDWithM_D_ReturnsM()
    {
        const string input = Constants.D_BecomesM;
        const string expected = Constants.M;

        input
            .ReplaceDWithM()
            .TryGetResult(out var actual);

        Assert.AreEqual(expected, actual);
    }

    #endregion
}