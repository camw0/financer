public class Logger
{
    public void Input(string text)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("(>) " + text);
    }

    public void Success(string text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("(i) " + text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void Info(string text, bool color = true)
    {
        if (!color) Console.ForegroundColor = ConsoleColor.White;
        else Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("(i) " + text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void Warn(string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("(/) " + text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void Error(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("(x) " + text);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
