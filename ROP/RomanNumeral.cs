using Utils;

namespace ROP;

public static class RomanNumeral
{
    public static Result<string, Exception> ConvertToRoman(this string input)
        => input
            .Validate()
            .OnSuccess(Sanitise)
            .OnSuccess(ToStringArray)
            .OnSuccess(ToIntArray)
            .OnSuccess(ConvertAll);

    public static Result<string, Exception> Validate(this string input)
    {
        if (int.TryParse(input, out var inputAsNumber) == false)
            return new NaNException();

        if (inputAsNumber == 0)
            return new NoZeroException();

        return input;
    }

    public static Result<string, Exception> Sanitise(this string input)
        => input.StripLeadingZeroes();

    private static string StripLeadingZeroes(this string input)
    {
        var length = input.Length;
        var output = string.Empty;

        for (var i = 0; i < length; i++)
        {
            if (input[i] == Constants.ZeroChar)
                continue;

            output += input[i];
        }

        return output;
    }

    public static Result<string[], Exception> ToStringArray(this string input)
    {
        var length = input.Length;
        var output = new string[length];

        for (var i = 0; i < input.Length; i++)
            output[i] = input[i].ToString();

        return output;
    }

    public static Result<int[], Exception> ToIntArray(this string[] input)
    {
        var length = input.Length;
        var output = new int[length];

        for (var i = 0; i < length; i++)
            output[i] = int.Parse(input[i]);

        return output;
    }

    private static Result<string, Exception> ConvertAll(this int[] input)
    {
        var output = string.Empty;
        var length = input.Length;

        for (var i = 0; i < length; i++)
        {
            var current = input[i];
            var powerToUse = length - i - 1;
            var modifiedCurrent = current * (int)Math.Pow(10, powerToUse);
            var converted = modifiedCurrent.ConvertNumberToRoman();
            output += converted;
        }

        return output;
    }

    private static string ConvertNumberToRoman(this int input)
    {
        return input
            .ConvertToI()
            .OnSuccess(ReplaceIWithV) // 5
            .OnSuccess(ReplaceVWithX) // 10
            .OnSuccess(ReplaceXWithL) // 50
            .OnSuccess(ReplaceLWithC) // 100
            .OnSuccess(ReplaceCWithD) // 500
            .OnSuccess(ReplaceDWithM) // 1000
            .OnSuccess(ReplaceCWithCM) // 900
            .OnSuccess(ReplaceCWithCD) // 400
            .OnSuccess(ReplaceXWithXC) // 90
            .OnSuccess(ReplaceXWithXL) // 40
            .OnSuccess(ReplaceIWithIX) // 9
            .OnSuccess(ReplaceIWithIV); // 4

    }

    public static Result<string, Exception> ConvertToI(this int input)
    {
        var output = string.Empty;

        for (var i = 0; i < input; i++)
            output += Constants.I;

        return output;
    }

    public static Result<string, Exception> ReplaceIWithIV(this string input) // 4
        => input.Replace(Constants.I_BecomesIV, Constants.IV);

    public static Result<string, Exception> ReplaceIWithV(this string input) // 5
        => input.Replace(Constants.I_BecomesV, Constants.V);

    public static Result<string, Exception> ReplaceIWithIX(this string input) // 9
        => input.Replace(Constants.VI_BecomesIX, Constants.IX);

    public static Result<string, Exception> ReplaceVWithX(this string input) // 10
        => input.Replace(Constants.V_BecomesX, Constants.X);

    public static Result<string, Exception> ReplaceXWithXL(this string input) // 40
        => input.Replace(Constants.X_BecomesXL, Constants.XL);

    public static Result<string, Exception> ReplaceXWithL(this string input) // 50
        => input.Replace(Constants.X_BecomesL, Constants.L);

    public static Result<string, Exception> ReplaceXWithXC(this string input) // 90
        => input.Replace(Constants.LX_BecomesXC, Constants.XC);

    public static Result<string, Exception> ReplaceLWithC(this string input) // 100
        => input.Replace(Constants.L_BecomesC, Constants.C);

    public static Result<string, Exception> ReplaceCWithCD(this string input) // 400
        => input.Replace(Constants.C_BecomesCD, Constants.CD);

    public static Result<string, Exception> ReplaceCWithD(this string input) // 500
        => input.Replace(Constants.C_BecomesD, Constants.D);

    public static Result<string, Exception> ReplaceCWithCM(this string input) // 900
        => input.Replace(Constants.DC_BecomesCM, Constants.CM);

    public static Result<string, Exception> ReplaceDWithM(this string input) // 1000
        => input.Replace(Constants.D_BecomesM, Constants.M);
}