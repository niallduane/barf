using BarfSourceName.Domain.Services.BarfTemplateNames.Models;
using BarfSourceName.Infrastructure.Database.Entities;

namespace BarfSourceName.Services.BarfTemplateNames.Mappings;

internal static class DbEntityMapping
{
    public static BarfTemplateName ToEntity(this CreateBarfTemplateNameRequest obj)
    {
        return new BarfTemplateName
        {

        };
    }

    public static BarfTemplateName ToEntity(this UpsertBarfTemplateNameRequest obj)
    {
        return new BarfTemplateName
        {

        };
    }

    public static CreateBarfTemplateNameResponse ToCreateBarfTemplateNameResponse(this BarfTemplateName obj)
    {
        return new CreateBarfTemplateNameResponse(obj.BarfTemplateNameId.ToString())
        {

        };
    }

    public static UpsertBarfTemplateNameResponse ToUpsertBarfTemplateNameResponse(this BarfTemplateName obj)
    {
        return new UpsertBarfTemplateNameResponse(obj.BarfTemplateNameId.ToString())
        {

        };
    }

    public static UpdateBarfTemplateNameResponse ToUpdateBarfTemplateNameResponse(this BarfTemplateName obj)
    {
        return new UpdateBarfTemplateNameResponse(obj.BarfTemplateNameId.ToString())
        {

        };
    }

    public static GetBarfTemplateNameResponse ToGetBarfTemplateNameResponse(this BarfTemplateName obj)
    {
        return new GetBarfTemplateNameResponse(obj.BarfTemplateNameId.ToString())
        {

        };
    }

    public static ListBarfTemplateNameItem ToListBarfTemplateNameItem(this BarfTemplateName obj)
    {
        return new ListBarfTemplateNameItem(obj.BarfTemplateNameId.ToString())
        {

        };
    }
}
