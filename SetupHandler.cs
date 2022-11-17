using static ConfigModel;

public class SetupHandler
{
    public void Configure()
    {
        Logger log = new();
        ConfigHandler config = new();

        Console.Clear();

        log.Input("(>) Enter your typical wage (in £) per hour (e.g. 10.41): ");
        double rate = Convert.ToDouble(Console.ReadLine());

        log.Input("(>) Give an estimate for the average amount of hours you work per week: ");
        int hours = Convert.ToInt32(Console.ReadLine());

        double total = rate * hours * 4;
        log.Info($"(i) Given the rate of £{rate} and working {hours * 4}hrs per month, you are estimated to earn £{total} monthly.");

        log.Input("(>) Give an estimate (in £) as to how much you spend: ");
        int spend = Convert.ToInt32(Console.ReadLine());

        log.Input("(>) Give an estimate (in £) as to how much you save: ");
        int save = Convert.ToInt32(Console.ReadLine());

        if (spend >= ((total / 4) * 3) && save <= (total / 4))
        {

            log.Warn($"(/) You tend to spend 75% or more of your income per month.\n(/) You could be saving £{Convert.ToInt32((total / 4 * 3))} by moving to a more reliable savings plan.");
        }
        else if (spend <= ((total / 4) * 3) && save >= (total / 4))
        {
            log.Info($"(i) The amount that you are saving per month is outweighed by your spending drastically.");
        }

        try
        {
            config.Write(new RootObject{
                rate = rate,
                hours = hours,
                total = total,
                spend = spend,
                save = save,
            });

            log.Success("(i) Config file has been written successfully.\n\nPress 'enter' to return home.");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                continue;
            }
        }
        catch (Exception e)
        {
            log.Error("(x) Unable to write to configuration file: " + e.Message);
        }
    }
}
