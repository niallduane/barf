using System.Collections.Generic;
using System.Linq;

using TadaSourceName.Domain.Core.Types;

namespace TadaSourceName.Domain.Core.Extensions;

public static class IQueryableExtensions
{
    public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, BaseListRequest query)
    {
        var count = source.Count();
        var items = source.Skip((query.Page - 1) * query.Limit).Take(query.Limit).ToList();

        return new PagedList<T>(items, count, query.Page, query.Limit);
    }

    /// <summary>
    /// Order by an allowed list of properties
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="query"></param>
    /// <param name="allowedProperties"></param>
    /// <param name="sort"></param>
    /// <returns></returns>
    public static IQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> query, SortProperties<TSource> allowedProperties, string sort)
    {
        if (string.IsNullOrEmpty(sort))
        {
            return query;
        }

        // get the requested sort properties from the sort string
        var requestedSortProperties = sort.Split(",").Where(x => !string.IsNullOrEmpty(x))
           .Select(prop =>
           {
               if (prop.Contains(':'))
               {
                   var values = prop.Split(":");
                   var order = string.IsNullOrEmpty(values.Last()) ? "desc" : values.Last().Trim();

                   return new
                   {
                       Key = values.First().Trim(),
                       OrderBy = order.IsEqual("asc") ? SortOrder.Asc : SortOrder.Desc
                   };
               }

               return new
               {
                   Key = prop.Trim(),
                   OrderBy = SortOrder.Asc
               };
           });

        // filter requested sort properties by allowed properties
        var orderProps = requestedSortProperties
            .Where(prop => allowedProperties.Any(x => prop.Key.IsEqual(x.Key)))
            .Select(prop =>
            {
                return new
                {
                    Order = prop.OrderBy,
                    allowedProperties.First(x => x.Key.IsEqual(prop.Key)).Predicate
                };
            })
            .Where(x => x.Predicate != null).ToList();

        // add the order by predicates to the query
        orderProps.ForEach(prop =>
        {
            if (orderProps.IndexOf(prop) == 0)
            {
                query = (prop.Order == SortOrder.Asc) ? query.OrderBy(prop.Predicate!) : query.OrderByDescending(prop.Predicate!);
            }
            else
            {
                query = (prop.Order == SortOrder.Asc) ? ((IOrderedQueryable<TSource>)query).ThenBy(prop.Predicate!) :
                    ((IOrderedQueryable<TSource>)query).ThenByDescending(prop.Predicate!);
            }
        });

        return query;
    }
}