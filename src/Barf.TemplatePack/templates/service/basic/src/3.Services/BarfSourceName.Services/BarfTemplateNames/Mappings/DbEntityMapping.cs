

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BarfSourceName.Domain.Services.BarfTemplateNames.Models;

namespace BarfSourceName.Services.BarfTemplateNames.Mappings;

internal static class DbEntityMapping
{
    public static object ToEntity(this CreateBarfTemplateNameRequest obj)
    {
        throw new NotImplementedException();
    }

    public static object ToEntity(this UpsertBarfTemplateNameRequest obj)
    {
        throw new NotImplementedException();
    }

    public static CreateBarfTemplateNameResponse ToCreateBarfTemplateNameResponse(this object obj)
    {
        return new CreateBarfTemplateNameResponse("")
        {

        };
    }

    public static UpdateBarfTemplateNameResponse ToUpdateBarfTemplateNameResponse(this object obj)
    {
        return new UpdateBarfTemplateNameResponse("")
        {

        };
    }

    public static GetBarfTemplateNameResponse ToGetBarfTemplateNameResponse(this object obj)
    {
        return new GetBarfTemplateNameResponse("")
        {

        };
    }
    public static ListBarfTemplateNameItem ToListBarfTemplateNameItem(this object obj)
    {
        return new ListBarfTemplateNameItem("")
        {

        };
    }
}
