using ROP;

var wantToContinue = "Y";

do
{
    Console.WriteLine("What number do you want to convert? (N/n to quit) ");
    var numToConv = Console.ReadLine();
    wantToContinue = RomanNumeralsProgram.RunCode(numToConv);
} while (wantToContinue != "N");