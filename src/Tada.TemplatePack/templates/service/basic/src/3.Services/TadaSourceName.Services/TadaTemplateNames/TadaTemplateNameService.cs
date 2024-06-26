using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TadaSourceName.Domain.Core;
using TadaSourceName.Domain.Services.TadaTemplateNames;
using TadaSourceName.Domain.Services.TadaTemplateNames.Models;
using TadaSourceName.Services.TadaTemplateNames.Mappings;

namespace TadaSourceName.Services.TadaTemplateNames;

public class TadaTemplateNameService : ITadaTemplateNameService
{
    public TadaTemplateNameService()
    {
    }

    public Task<GetTadaTemplateNameResponse> GetTadaTemplateName(string tadatemplateNameId)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<ListTadaTemplateNameItem>> ListTadaTemplateNames(ListTadaTemplateNameRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<CreateTadaTemplateNameResponse> CreateTadaTemplateName(CreateTadaTemplateNameRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<UpdateTadaTemplateNameResponse> UpdateTadaTemplateName(string tadatemplatenameId, PatchRequest<UpdateTadaTemplateNameRequest> request)
    {
        throw new NotImplementedException();
    }

    public Task<UpsertResult<UpsertTadaTemplateNameResponse>> UpsertTadaTemplateName(string tadatemplatenameId, UpsertTadaTemplateNameRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<DeleteTadaTemplateNameResponse> DeleteTadaTemplateName(string tadatemplatenameId)
    {
        throw new NotImplementedException();
    }
}
