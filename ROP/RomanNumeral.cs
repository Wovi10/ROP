using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROP
{
    internal class RomanNumeral
    {
        internal static Either<string, Exception> ConvertToI(string input)
        {
            if (input.ToUpper() == "N")
            {
                return input.ToUpper();
            }

            if (int.TryParse(input, out _) == false) 
            {
                return new Exception("This is not a number.");
            }

            var inputAsNum = int.Parse(input);
            var output = "";
            for (int i = 0; i < inputAsNum; i++)
                output += "I";

            return output;
        }

        internal static Either<string, Exception> ReplaceIWithV(string input)
        {
            return input.Replace("IIIII", "V");
        }

        internal static Either<string, Exception> ReplaceVWithX(string input)
        {
            return input.Replace("VV", "X");
        }

        internal static Either<string, Exception> ReplaceXWithL(string input)
        {
            return input.Replace("XXXXX", "L");
        }
        
        internal static Either<string, Exception> ReplaceLWithC(string input)
        {
            return input.Replace("LL", "C");
        }
        
        internal static Either<string, Exception> ReplaceCWithD(string input)
        {
            return input.Replace("CCCCC", "D");
        }
        
        internal static Either<string, Exception> ReplaceDWithM(string input)
        {
            return input.Replace("DD", "M");
        }
    }
}
