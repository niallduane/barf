namespace TadaSourceName.Domain.Core;

public class ApiErrorResponse
{
    public ApiErrorResponse(int code, Error error)
    {
        Code = code;
        Error = error;
    }
    public int Code { get; set; }
    public Error Error { get; set; }
}
