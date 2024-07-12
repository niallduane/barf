using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TadaSourceName.Domain.Core.Extensions;

public static class DictionaryExtensions
{
    /// <summary>
    /// 
    /// </summary>
    public static Dictionary<string, object?> MapToObjectProperties<T>(this Dictionary<string, object?> dictionary) where T : class
    {
        var properties = typeof(T).GetProperties().Select(x => x.Name).ToList();
        var newDictionary = new Dictionary<string, object?>();
        foreach (var prop in properties)
        {
            if (dictionary.Any(x => x.Key.Equals(prop, StringComparison.OrdinalIgnoreCase)))
            {
                var value = dictionary.First(x => x.Key.Equals(prop, StringComparison.OrdinalIgnoreCase)).Value;
                newDictionary.Add(prop, value);
            }
        }
        return newDictionary;
    }
}