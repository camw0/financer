using static ConfigModel;

public class SetupHandler
{
    public void Configure()
    {
        Logger log = new();
        ConfigHandler config = new();

        Console.Clear();

        log.Input("What is your hourly rate? (e.g. 10.41): ");
        double rate = Convert.ToDouble(Console.ReadLine());

        log.Input("How many hours do you normally work per week? (e.g. 15.5): ");
        int hours = Convert.ToInt32(Console.ReadLine());

        double total = rate * hours * 4;
        log.Info($"Given the rate of £{rate} and working {hours * 4}hrs per month, you are estimated to earn £{total} monthly.");

        log.Input("How much do you usually spend per month?: ");
        int spend = Convert.ToInt32(Console.ReadLine());

        log.Input("How much do you usually save per month?: ");
        int save = Convert.ToInt32(Console.ReadLine());

        if (spend >= ((total / 4) * 3) && save <= (total / 4))
        {

            log.Warn($"You tend to spend 75% or more of your income per month.\nYou could be saving up to £{Convert.ToInt32((total / 4 * 3))} by moving to a more reliable savings plan.");
        }
        else if (spend <= ((total / 4) * 3) && save >= (total / 4))
        {
            log.Info($"Your saving pattern and quantity is strong, keep it up!");
        }

        config.Write(new RootObject
        {
            rate = rate,
            hours = hours,
            total = total,
            spend = spend,
            save = save,
        });

        log.Success("Config file has been written successfully.\n\nPress 'enter' to return home.");
        while (Console.ReadKey().Key != ConsoleKey.Enter) continue;
    }
}
