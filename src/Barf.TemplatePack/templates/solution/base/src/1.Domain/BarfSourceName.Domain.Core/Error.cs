using System.Collections.Generic;
using BarfSourceName.Domain.Core.Types;

namespace BarfSourceName.Domain.Core;

public class Error
{
    public Error(string message, ErrorTypes errorCode)
    {
        Message = message;
        Code = errorCode;
    }

    public string Message { get; set; }
    public ErrorTypes Code { get; set; }
}

public class ValidationError
{
    public string[] Messages { get; }
    public string Attribute { get; }
    public ValidationError(string attribute, string[] messages)
    {
        this.Attribute = attribute;
        this.Messages = messages;
    }
}

public class ValidationErrorList : Error
{
    public ValidationErrorList(string message, ErrorTypes errorCode, ValidationError[] items) : base(message, errorCode)
    {
        Items = items;
    }
    public ValidationError[] Items { get; set; }
}
