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

        log.Input("How many hours have you worked this month? (e.g. 12): ");
        double worked = Convert.ToDouble(Console.ReadLine());

        log.Input("What are your projected hours for this month? (e.g. 24): ");
        double projected = Convert.ToDouble(Console.ReadLine());

        log.Input($"Is the rate of pay still £{config.Read()!.rate}/hour? (y/n): ");

        if (Convert.ToChar(Console.ReadLine()!.ToLower()) != 'y')
        {
            log.Input("What is the new rate of pay? (e.g. 15.04): ");
            config.Write(new RootObject { rate = Convert.ToDouble(Console.ReadLine()) });
        }

        log.Info(
            $"---Summary---\nHours: {worked}\nProjected: {projected}" +
            $"\nInsurance: {INSURANCE}%\nTax rate: {TAX}%" +
            $"\nPay rate: £{config.Read()!.rate}\n-------------"
        , false);

        log.Input("Is the above information correct? (y/n): ");

        if (Convert.ToChar(Console.ReadLine()!.ToLower()) != 'y')
        {
            log.Error("Income processing failed due to user cancellation.");
        }

        double total = config.Read()!.rate * projected;
        double spending = Math.Floor(total / 4);
        double saving = Math.Floor(total / 1.75);

        log.Success(
            $"\nProjected earnings: £{total}\nProjected savings: £{saving}\nProjected spending: £{spending}" +
            $"Estimated free income (after general spending + savings): £{(int)(total - (spending + saving))}" +
            "\n\nPress 'enter' to return home."
        );

        while (Console.ReadKey().Key != ConsoleKey.Enter) continue;
    }
}
