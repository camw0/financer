public class Logger
{
    public void Input(string text)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(text);
    }

    public void Success(string text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void Info(string text)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void Warn(string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void Error(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;

        Environment.Exit(1);
    }
}