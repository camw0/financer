public class IncomeHandler
{
    public const double TAX = 0.00;
    public double RATE = 10.41;
    public const double INSURANCE = 0.00;

    public void Process()
    {
        Console.Clear();

        Console.WriteLine("(1/3) Enter hours worked this month:");
        int hoursWorked = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("(2/3) Enter projected hours for this month:");
        int hoursProjected = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"(3/3) Is the rate of pay still £{RATE}/hour? y/n");
        char rateConfirmation = Convert.ToChar(Console.ReadLine()!.ToLower());

        if (rateConfirmation != 'y')
        {
            Console.Write("(3/3) Please enter the new rate:");
            double newRate = Convert.ToDouble(Console.ReadLine());
            RATE = newRate;
        }

        Console.WriteLine($"---Summary---\nHours: {hoursWorked}\nProjected: {hoursProjected}");
        Console.WriteLine($"-------------\nInsurance: {INSURANCE}%\nTax rate: {TAX}%");
        Console.WriteLine($"-------------\nPay rate: £{RATE}\n-------------");

        Console.WriteLine("Is the above information correct? y/n");
        char summaryConfirmation = Convert.ToChar(Console.ReadLine()!.ToLower());

        if (summaryConfirmation != 'y')
        {
            Console.WriteLine("Income processing failed due to user cancellation.");
        }

        double total = RATE * hoursProjected;
        double spending = Math.Floor(total / 4);
        double saving = Math.Floor(total / 1.75);

        Console.WriteLine("Projected earnings: £" + total);
        Console.WriteLine("Projected savings: £" + saving);
        Console.WriteLine("Projected spending: £" + spending);

        Console.WriteLine("Estimated free income (after general spending + savings): £" + (int)(total - (spending + saving)));
    }
}
