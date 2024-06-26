using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TadaSourceName.Domain.Core;

public class SortProperty<T>
{
    public SortProperty(string key, Expression<Func<T, object>> predicate)
    {
        this.Predicate = predicate;
        this.Key = key;
    }
    public string Key { get; set; } = string.Empty;
    public Expression<Func<T, object>>? Predicate { get; set; }
}

public class SortProperties<T> : List<SortProperty<T>>
{

}
