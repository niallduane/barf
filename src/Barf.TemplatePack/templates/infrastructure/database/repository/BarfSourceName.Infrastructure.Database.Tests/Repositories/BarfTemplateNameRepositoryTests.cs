using System;
using Microsoft.EntityFrameworkCore;
using BarfSourceName.Domain.Core;
using BarfSourceName.Infrastructure.Database.Entities;
using BarfSourceName.Infrastructure.Database.Repositories.BarfTemplateNames;

namespace BarfSourceName.Infrastructure.Database.Tests;

public class BarfTemplateNameRepositoryTests
{
    private readonly InMemoryDatabaseContext DbContext = new();
    private readonly BarfTemplateNameRepository? repository;

    public BarfTemplateNameRepositoryTests()
    {
        repository = new BarfTemplateNameRepository(DbContext);
    }

    [Fact]
    public async Task GetBarfTemplateName_Success()
    {
        var expected = await DbContext.BarfTemplateNames.FirstAsync();

        var result = await repository!.GetBarfTemplateName(expected.BarfTemplateNameId);

        Assert.NotNull(result);
        Assert.Equal(expected.BarfTemplateNameId, result.BarfTemplateNameId);
    }

    [Fact]
    public async Task ListBarfTemplateNames_Success()
    {
        var expected = await DbContext.BarfTemplateNames.ToListAsync();
        var request = new BaseListRequest
        {

        };
        var result = await repository!.ListBarfTemplateNames(request);

        Assert.NotNull(result);
        //todo: add more test asserts
    }

    [Fact]
    public async Task Create_Success()
    {
        var request = new BarfTemplateName
        {

        };
        var result = await repository!.Create(request);

        Assert.NotNull(result);
        //todo: add more test asserts
    }

    [Fact]
    public async Task Update_Success()
    {
        var item = await DbContext.BarfTemplateNames.FirstAsync();
        var result = await repository!.Update(item.BarfTemplateNameId, new Dictionary<string, object>()
        {
            //Todo: Add properties to update
        });

        Assert.NotNull(result);
        Assert.Equal(item.BarfTemplateNameId, result.BarfTemplateNameId);

        //Todo: Add Asserts to check update
    }

    [Fact]
    public async Task Delete_Success()
    {
        var expected = await DbContext.BarfTemplateNames.FirstAsync();

        await repository!.Delete(expected.BarfTemplateNameId);

        var result = await DbContext.BarfTemplateNames.FirstOrDefaultAsync(item => item.BarfTemplateNameId == expected.BarfTemplateNameId);

        Assert.Null(result);
    }
}
