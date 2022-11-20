﻿void Start(bool hasFailed = false)
{
    Logger log = new();

    Console.Clear();
    if (!hasFailed) log.Success("Welcome to Financer -\nan all-in-one CLI finance management application.\n");
    else log.Error("Invalid option. Please select from the following below:\n");

    ShowOptions();
}

void ShowOptions()
{
    string[] desc = new string[] { "", "Get projected values for savings.", "Log hours that have been worked.", "Configure this program for use.", "Exits the program." };

    for (int i = 1; i < desc.Length; i++)
    {
        Console.WriteLine($"[{i}]: {desc[i]}");
    }

    switch (Console.ReadKey().Key)
    {
        case ConsoleKey.D1:
            new IncomeHandler().Process();
            Start();
            break;
        case ConsoleKey.D2:
            new HourHandler().Process();
            Start();
            break;
        case ConsoleKey.D3:
            new SetupHandler().Configure();
            Start();
            break;
        case ConsoleKey.D4:
            Environment.Exit(1);
            break;
        default:
            Start(true);
            break;
    }
}

Start();
