using Utils;

namespace ROP
{
    public static class RomanNumeralsProgram
    {
        public static Either<string, Exception> RunCode(string input)
        {
            var result = RomanNumeral.ConvertToI(input)
                .OnSuccess((x) => RomanNumeral.ReplaceIWithV(x))
                .OnSuccess((x) => RomanNumeral.ReplaceVWithX(x))
                .OnSuccess((x) => RomanNumeral.ReplaceXWithL(x))
                .OnSuccess((x) => RomanNumeral.ReplaceLWithC(x))
                .OnSuccess((x) => RomanNumeral.ReplaceCWithD(x))
                .OnSuccess((x) => RomanNumeral.ReplaceDWithM(x));

            return result;
        }
    }
}