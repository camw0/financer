using System.Text.Json;
using static ConfigModel;
using System.Text.Json.Serialization;

public class ConfigHandler
{
    const string FILE = "config.json";

    public void Write(RootObject obj)
    {
        File.WriteAllText(FILE, JsonSerializer.Serialize(obj));
        return;
    }

    public RootObject Read()
    {
        return JsonSerializer.Deserialize<RootObject>(File.ReadAllText(FILE));
    }
}