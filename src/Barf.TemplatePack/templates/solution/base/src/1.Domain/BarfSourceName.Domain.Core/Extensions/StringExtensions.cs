using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarfSourceName.Domain.Core.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Compares strings ignoring case
    /// </summary>
    public static bool IsEqual(this string? originalString, string value)
    {
        return (originalString?.Equals(value, StringComparison.OrdinalIgnoreCase)).GetValueOrDefault();
    }
    public static bool Has(this string[]? stringArray, string? value)
    {
        return (stringArray?.Contains(value?.Trim(), StringComparer.OrdinalIgnoreCase)).GetValueOrDefault();
    }

    public static bool Has(this string? originalString, string value)
    {
        return (originalString?.Contains(value.Trim(), StringComparison.OrdinalIgnoreCase)).GetValueOrDefault();
    }
}