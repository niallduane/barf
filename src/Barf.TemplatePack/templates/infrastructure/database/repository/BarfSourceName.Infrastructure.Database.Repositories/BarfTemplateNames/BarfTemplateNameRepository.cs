using System;
using Microsoft.EntityFrameworkCore;
using BarfSourceName.Domain.Core;
using BarfSourceName.Domain.Core.Extensions;
using BarfSourceName.Infrastructure.Database.Extensions;
using BarfSourceName.Infrastructure.Database.Entities;

namespace BarfSourceName.Infrastructure.Database.Repositories.BarfTemplateNames;

public class BarfTemplateNameRepository : IBarfTemplateNameRepository
{
    private readonly DatabaseContext _databaseContext;
    private IQueryable<BarfTemplateName> GetQuery() => _databaseContext.BarfTemplateNames;

    public BarfTemplateNameRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public Task<BarfTemplateName?> GetBarfTemplateName(Guid id)
    {
        return GetQuery()
            .FirstOrDefaultAsync(barftemplatename => barftemplatename.BarfTemplateNameId == id);
    }

    public async Task<PagedList<BarfTemplateName>> ListBarfTemplateNames(BaseListRequest request)
    {
        var sortableProperties = new SortProperties<BarfTemplateName>()
        {
            new("Id", entity => entity.BarfTemplateNameId),
        };

        var query = GetQuery();

        query = string.IsNullOrEmpty(request.Sort) ?
            query.OrderBy(x => x.BarfTemplateNameId) :
            query.OrderBy(sortableProperties, request.Sort);

        return await query.ToPagedListAsync(request);
    }

    public async Task<BarfTemplateName> Create(BarfTemplateName entity)
    {
        _databaseContext.BarfTemplateNames.Add(entity);

        await _databaseContext.SaveChangesAsync();

        return entity;
    }

    public async Task<BarfTemplateName> Update(Guid id, Dictionary<string, object?> newValues)
    {
        var entity = await GetQuery()
            .FirstAsync(barftemplatename => barftemplatename.BarfTemplateNameId == id);

        _databaseContext.Entry(entity).CurrentValues.SetValues(newValues);

        //entity.UpdatedAt = DateTime.UtcNow;
        await _databaseContext.SaveChangesAsync();

        return entity;
    }

    public async Task Delete(Guid id)
    {
        var entity = await GetQuery()
            .FirstAsync(barftemplatename => barftemplatename.BarfTemplateNameId == id);

        _databaseContext.BarfTemplateNames.Remove(entity);
        //entity.DeletedAt = DateTime.UtcNow;

        await _databaseContext.SaveChangesAsync();
    }
}
