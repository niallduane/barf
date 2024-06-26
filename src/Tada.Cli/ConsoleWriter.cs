namespace Tada.Cli;

public static class ConsoleWriter
{
    public static void Start(params string[] outputs)
    {
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Yellow;
        WriteStringsToConsole(outputs);
        Console.WriteLine("--------------------------------------------------------------------------------------------");
        Console.ResetColor();
        Console.WriteLine("");
    }

    public static void Standard(params string[] outputs)
    {
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.White;
        WriteStringsToConsole(outputs);
        Console.ResetColor();
        Console.WriteLine("");
    }

    public static void Generate(params string[] outputs)
    {
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Blue;
        WriteStringsToConsole(outputs);
        Console.ResetColor();
        Console.WriteLine("");
    }

    public static void Success(params string[] outputs)
    {
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("--------------------------------------------------------------------------------------------");
        WriteStringsToConsole(outputs);
        Console.ResetColor();
        Console.WriteLine("");
    }

    public static void Warning(params string[] outputs)
    {
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Yellow;
        WriteStringsToConsole(outputs);
        Console.ResetColor();
        Console.WriteLine("");
    }

    public static void Error(params string[] outputs)
    {
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("--------------------------------------------------------------------------------------------");
        WriteStringsToConsole(outputs);
        Console.ResetColor();
        Console.WriteLine("");
    }

    private static void WriteStringsToConsole(params string[] outputs)
    {
        foreach (var output in outputs)
        {
            Console.WriteLine(output);
        }
    }
}