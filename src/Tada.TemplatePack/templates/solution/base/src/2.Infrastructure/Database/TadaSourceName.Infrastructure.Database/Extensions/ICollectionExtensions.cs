using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TadaSourceName.Domain.Core;

namespace TadaSourceName.Infrastructure.Database.Extensions;

public static class ICollectionExtensions
{
    public static PagedList<T> ToPagedList<T>(this ICollection<T> source, BaseListRequest query)
    {
        var count = source.Count;
        var items = source.Skip((query.Page - 1) * query.Limit).Take(query.Limit).ToList();

        return new PagedList<T>(items, count, query.Page, query.Limit);
    }
}