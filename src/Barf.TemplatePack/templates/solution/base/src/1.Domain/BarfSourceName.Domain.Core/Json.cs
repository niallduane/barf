using System.Text.Json;

namespace BarfSourceName.Domain.Core;

public static class Json
{
    public static JsonSerializerOptions GetJsonSerializerOptions()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        options.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
        return options;
    }

    public static T? Deserialize<T>(string jsonText)
    {
        if (string.IsNullOrEmpty(jsonText))
        {
            return default(T);
        }
        return JsonSerializer.Deserialize<T>(jsonText, GetJsonSerializerOptions());
    }

    public static string Serialize<T>(T obj)
    {
        return JsonSerializer.Serialize(obj, GetJsonSerializerOptions());
    }
}