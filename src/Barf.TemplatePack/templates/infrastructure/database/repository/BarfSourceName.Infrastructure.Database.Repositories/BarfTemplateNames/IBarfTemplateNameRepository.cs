using System;
using BarfSourceName.Domain.Core;
using BarfSourceName.Infrastructure.Database.Entities;

namespace BarfSourceName.Infrastructure.Database.Repositories.BarfTemplateNames;

public interface IBarfTemplateNameRepository
{
    Task<BarfTemplateName?> GetBarfTemplateName(Guid id);
    Task<PagedList<BarfTemplateName>> ListBarfTemplateNames(BaseListRequest request);
    Task<BarfTemplateName> Create(BarfTemplateName entity);
    Task<BarfTemplateName> Update(Guid id, Dictionary<string, object?> newValues);
    Task Delete(Guid id);
}
