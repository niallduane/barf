using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using BarfSourceName.Domain.Core;
using BarfSourceName.Domain.Services.BarfTemplateNames.Models;

namespace BarfSourceName.Domain.Services.BarfTemplateNames;

public interface IBarfTemplateNameService
{
    Task<GetBarfTemplateNameResponse> GetBarfTemplateName(string barftemplatenameId);
    Task<PagedList<ListBarfTemplateNameItem>> ListBarfTemplateNames(ListBarfTemplateNameRequest request);
    Task<CreateBarfTemplateNameResponse> CreateBarfTemplateName(CreateBarfTemplateNameRequest request);
    //Task<UpdateBarfTemplateNameResponse> UpdateBarfTemplateName(string barftemplatenameId, PatchBodyRequest<UpdateBarfTemplateNameRequest> request);
    Task<UpsertResult<UpsertBarfTemplateNameResponse>> UpsertBarfTemplateName(string barftemplatenameId, UpsertBarfTemplateNameRequest request);
    Task<DeleteBarfTemplateNameResponse> DeleteBarfTemplateName(string barftemplatenameId);
}
