using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ROP
{
    internal static class RomanNumeralsProgram
    {
        internal static string RunCode(string input)
        {
            //var result = RomanNumeral.ConvertToI(input)
            //             .OnFailure((err) => Console.WriteLine(err.Message));

            string output = "";
            var result =
                RomanNumeral.ConvertToI(input)
                .OnSuccess((x) => output = x)
                .OnFailure((err) => Console.WriteLine(err.Message));
            if(output == "N")
            {
                return output;
            }

            result
                .OnSuccess((x) => Console.WriteLine($"Converting {input} to Roman Numerals"))
                .OnSuccess((x) => RomanNumeral.ReplaceIWithV(x))
                .OnSuccess((x) => RomanNumeral.ReplaceVWithX(x))
                .OnSuccess((x) => RomanNumeral.ReplaceXWithL(x))
                .OnSuccess((x) => RomanNumeral.ReplaceLWithC(x))
                .OnSuccess((x) => RomanNumeral.ReplaceCWithD(x))
                .OnSuccess((x) => RomanNumeral.ReplaceDWithM(x))
                .OnSuccess((x) => Console.WriteLine($"{input} in Roman Numerals is: {x}"));

            return "Y";
        }
    }
}
