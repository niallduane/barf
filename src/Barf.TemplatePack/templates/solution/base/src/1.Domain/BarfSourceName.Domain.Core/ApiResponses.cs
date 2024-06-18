namespace BarfSourceName.Domain.Core;

public class ApiResponse<T>
{
    public ApiResponse(int code, T data)
    {
        Code = code;
        Data = data;
    }

    public int Code { get; set; }
    public T Data { get; set; }
}
