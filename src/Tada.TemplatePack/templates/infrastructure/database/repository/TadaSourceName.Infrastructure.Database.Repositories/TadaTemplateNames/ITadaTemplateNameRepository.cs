using System;
using TadaSourceName.Domain.Core;
using TadaSourceName.Infrastructure.Database.Entities;

namespace TadaSourceName.Infrastructure.Database.Repositories.TadaTemplateNames;

public interface ITadaTemplateNameRepository
{
    Task<TadaTemplateName?> GetTadaTemplateName(Guid id);
    Task<PagedList<TadaTemplateName>> ListTadaTemplateNames(BaseListRequest request);
    Task<TadaTemplateName> CreateTadaTemplateName(TadaTemplateName entity);
    Task<TadaTemplateName> UpdateTadaTemplateName(Guid id, Dictionary<string, object?> newValues);
    Task DeleteTadaTemplateName(Guid id);
}
