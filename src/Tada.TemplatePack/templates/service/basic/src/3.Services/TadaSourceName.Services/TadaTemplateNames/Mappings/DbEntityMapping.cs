using TadaSourceName.Domain.Core.Extensions;
using TadaSourceName.Domain.Services.TadaTemplateNames.Models;
using TadaSourceName.Infrastructure.Database.Entities;
using TadaSourceName.Domain.Core;
#if (TadaIdNameSpace != null) 
using TadaIdNameSpace;
#endif 


namespace TadaSourceName.Services.TadaTemplateNames.Mappings;

internal static class DbEntityMapping
{
    public static TadaTemplateName ToEntity(this CreateTadaTemplateNameRequest obj)
    {
        return new TadaTemplateName
        {

        };
    }

    public static TadaTemplateName ToEntity(this UpsertTadaTemplateNameRequest obj)
    {
        return new TadaTemplateName
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

    public static CreateTadaTemplateNameResponse ToCreateTadaTemplateNameResponse(this TadaTemplateName obj)
    {
        return new CreateTadaTemplateNameResponse(obj.TadaTemplateNameId)
        {

        };
    }

    public static UpsertTadaTemplateNameResponse ToUpsertTadaTemplateNameResponse(this TadaTemplateName obj)
    {
        return new UpsertTadaTemplateNameResponse(obj.TadaTemplateNameId)
        {

        };
    }

    public static UpdateTadaTemplateNameResponse ToUpdateTadaTemplateNameResponse(this TadaTemplateName obj)
    {
        return new UpdateTadaTemplateNameResponse(obj.TadaTemplateNameId)
        {

        };
    }

    public static GetTadaTemplateNameResponse ToGetTadaTemplateNameResponse(this TadaTemplateName obj)
    {
        return new GetTadaTemplateNameResponse(obj.TadaTemplateNameId)
        {

        };
    }

    public static ListTadaTemplateNameItem ToListTadaTemplateNameItem(this TadaTemplateName obj)
    {
        return new ListTadaTemplateNameItem(obj.TadaTemplateNameId)
        {

        };
    }
}
