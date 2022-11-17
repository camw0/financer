using System.Text.Json;
using static ConfigModel;

public class ConfigHandler
{
    const string FILE = "config.json";

    public void Write(RootObject obj)
    {
        try
        {
            File.WriteAllText(FILE, JsonSerializer.Serialize(obj));
        }
        catch (FileLoadException e)
        {
            new Logger().Error("(x)Unable to write to config file: " + e.Message);
        }

        return;
    }

    public RootObject? Read()
    {
        try
        {
            return JsonSerializer.Deserialize<RootObject>(File.ReadAllText(FILE))!;
        }
        catch(FileNotFoundException e)
        {
            new Logger().Error("(x) Unable to read config file: " + e.Message);
        }

        return null;
    }
}