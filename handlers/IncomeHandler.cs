using static ConfigModel;

public class IncomeHandler
{
    public const double TAX = 0.00;
    public const double INSURANCE = 0.00;

    public void Process()
    {
        Logger log = new();
        ConfigHandler config = new();

        Console.Clear();

        log.New("input", "How many hours have you worked this month? (e.g. 12): ");
        double worked = Convert.ToDouble(Console.ReadLine());

        log.New("input", "What are your projected hours for this month? (e.g. 24): ");
        double projected = Convert.ToDouble(Console.ReadLine());

        log.New("input", $"Is the rate of pay still £{config.Read().rate}/hour? (y/n): ");

        if (Convert.ToChar(Console.ReadLine()!.ToLower()) != 'y')
        {
            log.New("input", "What is the new rate of pay? (e.g. 15.04): ");
            config.Write(new RootObject { rate = Convert.ToDouble(Console.ReadLine()) });
        }

        log.New("info",
            $"Summary:\n------------------\nHours: {worked}\nProjected: {projected}" +
            $"\nInsurance: {INSURANCE}%\nTax rate: {TAX}%" +
            $"\nPay rate: £{config.Read().rate}\n------------------\n"
        );

        log.New("input", "Is the above information correct? (y/n): ");

        if (Convert.ToChar(Console.ReadLine()!.ToLower()) != 'y')
        {
            log.New("error", "Income processing failed due to user cancellation.");
        }

        log.New("warn", "Calculating, please wait...");

        double total = config.Read().rate * projected;
        double spending = Math.Floor(total / 4);
        double saving = Math.Floor(total / 1.75);

        log.New("success",
            $"Summary:\n------------------\nProjected earnings: £{total}\nProjected savings: £{saving}\nProjected spending: £{spending}" +
            $"\nEstimated free income (after general spending + savings): £{(int)(total - (spending + saving))}\n------------------" +
            "\n\nPress 'enter' to return home."
        );

        while (Console.ReadKey().Key != ConsoleKey.Enter) continue;
    }
}
