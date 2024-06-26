using System;
using TadaSourceName.Domain.Core;
using TadaSourceName.Infrastructure.Database.Entities;

namespace TadaSourceName.Infrastructure.Database.Repositories.TadaTemplateNames;

public interface ITadaTemplateNameRepository
{
    Task<TadaTemplateName?> GetTadaTemplateName(Guid id);
    Task<PagedList<TadaTemplateName>> ListTadaTemplateNames(BaseListRequest request);
    Task<TadaTemplateName> Create(TadaTemplateName entity);
    Task<TadaTemplateName> Update(Guid id, Dictionary<string, object?> newValues);
    Task Delete(Guid id);
}
