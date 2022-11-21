public class Logger
{
    public void New(string? type, string text)
    {
        switch(type)
        {
            case "input":
                SetColor(ConsoleColor.White);
                Console.Write("(>) " + text);
                break;
            case "success":
                SetColor(ConsoleColor.Green);
                Console.Write("(i) " + text);
                break;
            case "info":
                SetColor(ConsoleColor.Cyan);
                Console.Write("(i) " + text);
                break;
            case "warn":
                SetColor(ConsoleColor.Yellow);
                Console.Write("(/) " + text);
                break;
            case "error":
                SetColor(ConsoleColor.Red);
                Console.Write("(x) " + text);
                break;
            default:
                SetColor(ConsoleColor.Red);
                Console.Write(text);
                break;
            
        }
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void SetColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }
}