Logger log = new();

void Start(bool hasFailed = false)
{
    Console.Clear();

    if (!hasFailed)
    {
        log.Warn("This program is an internal piece of software and should not be publicly used.\n");
    }
    else
    {
        log.Error("Invalid option. Please select from the following below:\n");
    }

    
    ShowOptions();
}

void ShowOptions()
{
    string[] keys = new string[] { "space", "enter", "backspace", "c"};
    string[] desc = new string[] { "Get projected values for savings.", "Log hours that have been worked.", "Configure this program for use.", "Exits the program." };

    for (int i = 0; i < keys.Length; i++)
    {
        log.Info($"[{keys[i]}] > {desc[i]}");
    }

    switch (Console.ReadKey().Key)
    {
        case ConsoleKey.Spacebar:
            new IncomeHandler().Process();
            Start();
            break;
        case ConsoleKey.Enter:
            new HourHandler().Process();
            Start();
            break;
        case ConsoleKey.Backspace:
            new SetupHandler().Configure();
            Start();
            break;
        case ConsoleKey.C:
            Environment.Exit(1);
            break;
        default:
            Start(true);
            break;
    }
}

Start();
