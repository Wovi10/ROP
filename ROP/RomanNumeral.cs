using Utils;

namespace ROP
{
    public class RomanNumeral
    {
        public static Either<string, Exception> ConvertToI(string input)
        {
            if (input.ToUpper() == Constants.NO)
            {
                return input.ToUpper();
            }

            if (int.TryParse(input, out _) == false)
            {
                return new Exception("This is not a number.");
            }

            var inputAsNum = int.Parse(input);
            var output = Constants.EMPTY;
            for (int i = 0; i < inputAsNum; i++)
                output += Constants.I;

            return output;
        }

        internal static Either<string, Exception> ReplaceIWithV(string input)
        {
            return input.Replace(Constants.IToReplace, Constants.V);
        }

        internal static Either<string, Exception> ReplaceVWithX(string input)
        {
            return input.Replace(Constants.VToReplace, Constants.X);
        }

        internal static Either<string, Exception> ReplaceXWithL(string input)
        {
            return input.Replace(Constants.XToReplace, Constants.L);
        }

        internal static Either<string, Exception> ReplaceLWithC(string input)
        {
            return input.Replace(Constants.LToReplace, Constants.C);
        }

        internal static Either<string, Exception> ReplaceCWithD(string input)
        {
            return input.Replace(Constants.CToReplace, Constants.D);
        }

        internal static Either<string, Exception> ReplaceDWithM(string input)
        {
            return input.Replace(Constants.DToReplace, Constants.M);
        }
    }
}