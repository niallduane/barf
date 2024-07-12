

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TadaSourceName.Domain.Core;
using TadaSourceName.Domain.Core.Extensions;
using TadaSourceName.Domain.Services.TadaTemplateNames.Models;

namespace TadaSourceName.Services.TadaTemplateNames.Mappings;

internal static class DbEntityMapping
{
    public static object ToEntity(this CreateTadaTemplateNameRequest obj)
    {
        throw new NotImplementedException();
    }

    public static object ToEntity(this UpsertTadaTemplateNameRequest obj)
    {
        throw new NotImplementedException();
    }

    public static CreateTadaTemplateNameResponse ToCreateTadaTemplateNameResponse(this object obj)
    {
        return new CreateTadaTemplateNameResponse("")
        {

        };
    }

    public static Dictionary<string, object?> ToEntityProperties(this UpsertTadaTemplateNameRequest obj)
    {
        var props = Json
            .ToDictionary(obj)
            .MapToObjectProperties<TadaTemplateName>();
            
        // add/remove custom mappings here
        return props;
    }
    public static Dictionary<string, object?> ToEntityProperties(this PatchRequest<UpdateTadaTemplateNameRequest> obj)
    {
        var props = obj.MapToObjectProperties<TadaTemplateName>();
        // add/remove custom mappings here
        return props;
    }

    public static UpdateTadaTemplateNameResponse ToUpdateTadaTemplateNameResponse(this object obj)
    {
        return new UpdateTadaTemplateNameResponse("")
        {

        };
    }

    public static GetTadaTemplateNameResponse ToGetTadaTemplateNameResponse(this object obj)
    {
        return new GetTadaTemplateNameResponse("")
        {

        };
    }
    public static ListTadaTemplateNameItem ToListTadaTemplateNameItem(this object obj)
    {
        return new ListTadaTemplateNameItem("")
        {

        };
    }
}
