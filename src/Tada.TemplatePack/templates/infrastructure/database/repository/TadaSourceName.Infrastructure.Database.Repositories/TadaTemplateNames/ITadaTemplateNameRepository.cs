using System;
using TadaSourceName.Domain.Core;
using TadaSourceName.Infrastructure.Database.Entities;
#if (TadaIdNameSpace != null) 
using TadaIdNameSpace;
#endif 
namespace TadaSourceName.Infrastructure.Database.Repositories.TadaTemplateNames;

public interface ITadaTemplateNameRepository
{
    Task<TadaTemplateName?> GetTadaTemplateName(TadaEntityIdType id);
    Task<PagedList<TadaTemplateName>> ListTadaTemplateNames(BaseListRequest request);
    Task<TadaTemplateName> CreateTadaTemplateName(TadaTemplateName entity);
    Task<TadaTemplateName> UpdateTadaTemplateName(TadaEntityIdType id, Dictionary<string, object?> newValues);
    Task DeleteTadaTemplateName(TadaEntityIdType id);
}
