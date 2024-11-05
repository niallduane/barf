using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TadaSourceName.Domain.Core;
using TadaSourceName.Domain.Services.TadaTemplateNames.Models;
#if (TadaIdNameSpace != null) 
using TadaIdNameSpace;
#endif 
namespace TadaSourceName.Domain.Services.TadaTemplateNames;

public interface ITadaTemplateNameService
{
    Task<GetTadaTemplateNameResponse> GetTadaTemplateName(TadaIdType tadatemplatenameId);
    Task<PagedList<ListTadaTemplateNameItem>> ListTadaTemplateNames(ListTadaTemplateNameRequest request);
    Task<CreateTadaTemplateNameResponse> CreateTadaTemplateName(CreateTadaTemplateNameRequest request);
    Task<UpdateTadaTemplateNameResponse> UpdateTadaTemplateName(TadaIdType tadatemplatenameId, PatchRequest<UpdateTadaTemplateNameRequest> request);
    Task<UpsertResult<UpsertTadaTemplateNameResponse>> UpsertTadaTemplateName(TadaIdType tadatemplatenameId, UpsertTadaTemplateNameRequest request);
    Task<DeleteTadaTemplateNameResponse> DeleteTadaTemplateName(TadaIdType tadatemplatenameId);
}
