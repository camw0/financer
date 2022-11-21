using System.Text.Json;
using static ConfigModel;

public class ConfigHandler
{
    const string FILE = "config.json";

    public void Write(RootObject obj)
    {
        Logger log = new();

        try
        {
            File.WriteAllText(FILE, JsonSerializer.Serialize(obj));
        }
        catch (FileLoadException e)
        {
            log.New("error", "Unable to write to config file: " + e.Message);
        }

        return;
    }

    public RootObject Read()
    {
        string data;
        Logger log = new();

        try
        {
            data = File.ReadAllText(FILE);
        }
        catch(FileNotFoundException e)
        {
            data = ""; // No configuration available
            log.New("error", "Unable to read config file: " + e.Message);
        }
        
        return JsonSerializer.Deserialize<RootObject>(data)!;
    }
}
