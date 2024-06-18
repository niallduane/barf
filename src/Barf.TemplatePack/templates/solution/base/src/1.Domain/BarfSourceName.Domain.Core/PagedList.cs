using System;
using System.Collections.Generic;
using System.Linq;

namespace BarfSourceName.Domain.Core;

public sealed class PagedList<T> : List<T>
{
    public int Page { get; private set; }
    public int Pages { get; private set; }
    public int Limit { get; private set; }
    public int Items { get; private set; }

    public bool HasPrevious => Page > 1;
    public bool HasNext => Page < Pages;

    public PagedList()
    {

    }

    public PagedList(List<T> items, int count, int pageNumber, int pageSize)
    {
        Items = count;
        Limit = pageSize;
        Page = pageNumber;
        Pages = (int)Math.Ceiling(count / (double)pageSize);

        AddRange(items);
    }

    public PagedList(List<T> items, int totalItems, int itemCount, int pageNumber, int pageSize)
    {
        Items = itemCount;
        Limit = pageSize;
        Page = pageNumber;
        Pages = (int)Math.Ceiling(totalItems / (double)pageSize);

        AddRange(items);
    }

    public PagedList<O> Replace<O>(IEnumerable<O> mappedData)
    {
        return new PagedList<O>(mappedData.ToList(), Items, Page, Limit);
    }
    public PagedList<O> Map<O>(Func<T, O> mapFunction)
    {
        var mappedData = this.Select(data => mapFunction(data));
        return this.Replace(mappedData);
    }

    public async Task<PagedList<O>> MapAsync<O>(Func<T, Task<O>> mapFunction)
    {
        var mappedData = await Task.WhenAll(this.Select(data => mapFunction(data)));
        return this.Replace(mappedData);
    }

    public PagedList<O> Map<O>(Func<T, O> mapFunction, ExpandProperties<O> expandableProperties)
    {
        var mappedData = this.Select(data => expandableProperties.SetExpandPropertiesInObject(mapFunction(data)));
        return this.Replace(mappedData);
    }
}
