using System.Text;
using static ConfigModel;

public class HourHandler
{
    const string PATH = "logs/hour-log.txt";
    const string BORDER = "\n------------------------------\n";

    public void Process()
    {
        Console.Clear();

        Logger log = new();
        ConfigHandler config = new();

        log.Info("This data is sent directly to 'log.txt' and can be edited at any time.");

        log.Input("How many hours did you work today? (e.g. 8): ");
        double hours = Convert.ToDouble(Console.ReadLine());

        log.Input("At what time did you start working? (e.g. 8:45): ");
        double startedAt = Convert.ToDouble(Console.ReadLine());

        log.Warn("Constructing data...");

        FileStream logFile = File.Open(PATH, FileMode.Append);
        byte[] data = new UTF8Encoding(true).GetBytes(
            $"{BORDER}Hours worked: {hours}\nEntry Date: {DateTime.Now}\nWorking hours: {startedAt} - {startedAt + hours}" +
            $"\nHourly rate: £{config.Read()?.rate}\nToday\'s total: £{config.Read()?.rate * hours}{BORDER}"
        );

        log.Warn("Writing data...");

        try
        {
            config.Write(new RootObject { lastLogged = DateTime.Now });
        }
        catch (FileLoadException e)
        {
            log.Error("Unable to write to the logfile: " + e.Message);
        }

        logFile.Close();
        log.Success("Hours have been logged to the appropriate logfile!\n\nPress 'enter' to return home.");
        while (Console.ReadKey().Key != ConsoleKey.Enter) continue;
    }
}
