using System.ComponentModel.DataAnnotations;

namespace BarfSourceName.Domain.Core;

public sealed class PagedApiResponse<T>
{
    public PagedApiResponse(int code, PagedList<T> pagedData, string uri)
    {
        Code = code;
        Data = pagedData;
        Pagination = new Pagination
        {
            Items = pagedData.Items,
            Page = pagedData.Page,
            Limit = pagedData.Limit,
            Pages = pagedData.Pages,
            Next = pagedData.Page < pagedData.Pages ? $"{uri}?{nameof(BaseListRequest.Page).ToLower()}={pagedData.Page + 1}" : null,
            Previous = pagedData.Page > 1 ? $"{uri}?{nameof(BaseListRequest.Page).ToLower()}={pagedData.Page - 1}" : null
        };
    }

    // REQUIRED for json serializer
    public PagedApiResponse()
    {
    }

    public int Code { get; set; }
    public Pagination Pagination { get; set; } = new();
    public PagedList<T> Data { get; set; } = new();
}
