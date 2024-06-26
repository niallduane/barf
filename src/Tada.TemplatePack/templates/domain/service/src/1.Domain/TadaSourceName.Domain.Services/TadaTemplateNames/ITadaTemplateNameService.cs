using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TadaSourceName.Domain.Core;
using TadaSourceName.Domain.Services.TadaTemplateNames.Models;

namespace TadaSourceName.Domain.Services.TadaTemplateNames;

public interface ITadaTemplateNameService
{
    Task<GetTadaTemplateNameResponse> GetTadaTemplateName(string tadatemplatenameId);
    Task<PagedList<ListTadaTemplateNameItem>> ListTadaTemplateNames(ListTadaTemplateNameRequest request);
    Task<CreateTadaTemplateNameResponse> CreateTadaTemplateName(CreateTadaTemplateNameRequest request);
    Task<UpdateTadaTemplateNameResponse> UpdateTadaTemplateName(string tadatemplatenameId, PatchRequest<UpdateTadaTemplateNameRequest> request);
    Task<UpsertResult<UpsertTadaTemplateNameResponse>> UpsertTadaTemplateName(string tadatemplatenameId, UpsertTadaTemplateNameRequest request);
    Task<DeleteTadaTemplateNameResponse> DeleteTadaTemplateName(string tadatemplatenameId);
}
