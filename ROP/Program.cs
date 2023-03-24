using ROP;
using Utils;

var wantToContinue = Constants.YES;

do
{
    Console.WriteLine("What number do you want to convert? (N/n to quit) ");
    var numToConv = Console.ReadLine();

    var output = Constants.EMPTY;
    RomanNumeralsProgram.RunCode(numToConv)
        .OnSuccess((x) => HandleOutput(numToConv, x))
        .OnFailure((err) => Console.WriteLine(err.Message));

} while (wantToContinue != Constants.NO);

Either<string, Exception> HandleOutput(string numToConv, string input)
{
    if (input == Constants.NO)
    {
        wantToContinue = Constants.NO;
    }
    else
    {
        Console.WriteLine($"{numToConv} in Roman Numerals is {input}");
    }

    return wantToContinue;
}