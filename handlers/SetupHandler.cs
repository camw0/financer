using static ConfigModel;

public class SetupHandler
{
    public void Configure()
    {
        Logger log = new();
        ConfigHandler config = new();

        Console.Clear();

        log.New("input", "What is your hourly rate? (e.g. 10.41): ");
        double rate = Convert.ToDouble(Console.ReadLine());

        log.New("input", "How many hours do you normally work per week? (e.g. 15.5): ");
        int hours = Convert.ToInt32(Console.ReadLine());

        double total = rate * hours * 4;
        log.New("info", $"Given the rate of £{rate} and working {hours * 4}hrs per month, you are estimated to earn £{total} monthly.");

        log.New("input", "How much do you usually spend per month?: ");
        int spend = Convert.ToInt32(Console.ReadLine());

        log.New("input", "How much do you usually save per month?: ");
        int save = Convert.ToInt32(Console.ReadLine());

        if (spend >= ((total / 4) * 3) && save <= (total / 4))
        {

            log.New("warn", $"You tend to spend 75% or more of your income per month.\nYou could be saving up to £{Convert.ToInt32((total / 4 * 3))} by moving to a more reliable savings plan.");
        }
        else if (spend <= ((total / 4) * 3) && save >= (total / 4))
        {
            log.New("info", $"Your saving pattern and quantity is strong, keep it up!");
        }

        config.Write(new RootObject
        {
            rate = rate,
            hours = hours,
            total = total,
            spend = spend,
            save = save,
        });

        log.New("success", "Config file has been written successfully.\n\nPress 'enter' to return home.");
        while (Console.ReadKey().Key != ConsoleKey.Enter) continue;
    }
}
