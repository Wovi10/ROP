using ROP;
using Utils;

var wantToContinue = Constants.Yes;

do
{
    Console.WriteLine("What number do you want to convert? (N/n to quit) ");
    var numToConv = Console.ReadLine() ?? string.Empty;

    if (IsCancelCharacter(numToConv))
    {
        wantToContinue = Constants.No;
        continue;
    }

    numToConv
        .ConvertToRoman()
        .OnSuccess(x => HandleOutput(numToConv, x))
        .OnFailure(PrintError);
} while (wantToContinue != Constants.No);

PrintShuttingDownMessage();

return;

bool IsCancelCharacter(string input)
    => input.ToUpper() == Constants.No;

Result<string, Exception> HandleOutput(string numToConv, string input)
{
    if (input == Constants.No)
        wantToContinue = Constants.No;
    else Console.WriteLine($"{numToConv} in Roman Numerals is {input}");

    return wantToContinue;
}

Result<string, Exception> PrintError(Exception err)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(err.Message);
    Console.ResetColor();

    return err;
}

void PrintShuttingDownMessage()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Shutting down...");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Goodbye.");
    Console.ResetColor();
}