using System;
using Microsoft.EntityFrameworkCore;
using TadaSourceName.Domain.Core;
using TadaSourceName.Domain.Core.Extensions;
using TadaSourceName.Infrastructure.Database.Extensions;
using TadaSourceName.Infrastructure.Database.Entities;
#if (TadaIdNameSpace != null) 
using TadaIdNameSpace;
#endif 
namespace TadaSourceName.Infrastructure.Database.Repositories.TadaTemplateNames;

public class TadaTemplateNameRepository(DatabaseContext databaseContext) : ITadaTemplateNameRepository
{
    private readonly DatabaseContext _databaseContext = databaseContext;
    private IQueryable<TadaTemplateName> GetQuery() => _databaseContext.TadaTemplateNames;

    public Task<TadaTemplateName?> GetTadaTemplateName(TadaEntityIdType id)
    {
        return GetQuery()
            .FirstOrDefaultAsync(tadatemplatename => tadatemplatename.TadaTemplateNameId == id);
    }

    public async Task<PagedList<TadaTemplateName>> ListTadaTemplateNames(BaseListRequest request)
    {
        var sortableProperties = new SortProperties<TadaTemplateName>()
        {
            new("Id", entity => entity.TadaTemplateNameId),
        };

        var query = GetQuery();

        query = string.IsNullOrEmpty(request.Sort) ?
            query.OrderBy(x => x.TadaTemplateNameId) :
            query.OrderBy(sortableProperties, request.Sort);

        return await query.ToPagedListAsync(request);
    }

    public async Task<TadaTemplateName> CreateTadaTemplateName(TadaTemplateName entity)
    {
        _databaseContext.TadaTemplateNames.Add(entity);

        await _databaseContext.SaveChangesAsync();

        return entity;
    }

    public async Task<TadaTemplateName> UpdateTadaTemplateName(TadaEntityIdType id, Dictionary<string, object?> newValues)
    {
        var entity = await GetQuery()
            .FirstAsync(tadatemplatename => tadatemplatename.TadaTemplateNameId == id);

        _databaseContext.Entry(entity).CurrentValues.SetValues(newValues);

        //entity.UpdatedAt = DateTime.UtcNow;
        await _databaseContext.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteTadaTemplateName(TadaEntityIdType id)
    {
        var entity = await GetQuery()
            .FirstAsync(tadatemplatename => tadatemplatename.TadaTemplateNameId == id);

        _databaseContext.TadaTemplateNames.Remove(entity);
        //entity.DeletedAt = DateTime.UtcNow;

        await _databaseContext.SaveChangesAsync();
    }
}
