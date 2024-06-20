using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using BarfSourceName.Domain.Core;
using BarfSourceName.Domain.Services.BarfTemplateNames;
using BarfSourceName.Domain.Services.BarfTemplateNames.Models;
using BarfSourceName.Services.BarfTemplateNames.Mappings;

namespace BarfSourceName.Services.BarfTemplateNames;

public class BarfTemplateNameService : IBarfTemplateNameService
{
    public BarfTemplateNameService()
    {
    }

    public Task<GetBarfTemplateNameResponse> GetBarfTemplateName(string barftemplateNameId)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<ListBarfTemplateNameItem>> ListBarfTemplateNames(ListBarfTemplateNameRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<CreateBarfTemplateNameResponse> CreateBarfTemplateName(CreateBarfTemplateNameRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<UpdateBarfTemplateNameResponse> UpdateBarfTemplateName(string barftemplatenameId, PatchRequest<UpdateBarfTemplateNameRequest> request)
    {
        throw new NotImplementedException();
    }

    public Task<UpsertResult<UpsertBarfTemplateNameResponse>> UpsertBarfTemplateName(string barftemplatenameId, UpsertBarfTemplateNameRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<DeleteBarfTemplateNameResponse> DeleteBarfTemplateName(string barftemplatenameId)
    {
        throw new NotImplementedException();
    }
}
