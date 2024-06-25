using System.Text.Json;

namespace BarfSourceName.Domain.Core;

public static class Json
{
    public static JsonSerializerOptions SetOptions(JsonSerializerOptions options)
    {
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
        return options;
    }

    public static JsonSerializerOptions GetJsonSerializerOptions()
    {
        return SetOptions(new JsonSerializerOptions());
    }

    public static T? Deserialize<T>(string jsonText)
    {
        if (string.IsNullOrEmpty(jsonText))
        {
            return default(T);
        }
        return JsonSerializer.Deserialize<T>(jsonText, GetJsonSerializerOptions());
    }

    public static object? Deserialize(string jsonText, Type type)
    {
        if (string.IsNullOrEmpty(jsonText))
        {
            return null;
        }
        return JsonSerializer.Deserialize(jsonText, type, GetJsonSerializerOptions());
    }


    public static string Serialize<T>(T obj)
    {
        return JsonSerializer.Serialize(obj, GetJsonSerializerOptions());
    }
}