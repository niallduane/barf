using System;
using Microsoft.EntityFrameworkCore;
using TadaSourceName.Domain.Core;
using TadaSourceName.Infrastructure.Database.Entities;
using TadaSourceName.Infrastructure.Database.Repositories.TadaTemplateNames;

namespace TadaSourceName.Infrastructure.Database.Tests;

public class TadaTemplateNameRepositoryTests
{
    private readonly InMemoryDatabaseContext DbContext = new();
    private readonly TadaTemplateNameRepository? repository;

    public TadaTemplateNameRepositoryTests()
    {
        repository = new TadaTemplateNameRepository(DbContext);
    }

    [Fact]
    public async Task GetTadaTemplateName_Success()
    {
        var expected = await DbContext.TadaTemplateNames.FirstAsync();

        var result = await repository!.GetTadaTemplateName(expected.TadaTemplateNameId);

        Assert.NotNull(result);
        Assert.Equal(expected.TadaTemplateNameId, result.TadaTemplateNameId);
    }

    [Fact]
    public async Task ListTadaTemplateNames_Success()
    {
        var expected = await DbContext.TadaTemplateNames.ToListAsync();
        var request = new BaseListRequest
        {

        };
        var result = await repository!.ListTadaTemplateNames(request);

        Assert.NotNull(result);
        //todo: add more test asserts
    }

    [Fact]
    public async Task Create_Success()
    {
        var request = new TadaTemplateName
        {

        };
        var result = await repository!.Create(request);

        Assert.NotNull(result);
        //todo: add more test asserts
    }

    [Fact]
    public async Task Update_Success()
    {
        var item = await DbContext.TadaTemplateNames.FirstAsync();
        var result = await repository!.Update(item.TadaTemplateNameId, new Dictionary<string, object>()
        {
            //Todo: Add properties to update
        });

        Assert.NotNull(result);
        Assert.Equal(item.TadaTemplateNameId, result.TadaTemplateNameId);

        //Todo: Add Asserts to check update
    }

    [Fact]
    public async Task Delete_Success()
    {
        var expected = await DbContext.TadaTemplateNames.FirstAsync();

        await repository!.Delete(expected.TadaTemplateNameId);

        var result = await DbContext.TadaTemplateNames.FirstOrDefaultAsync(item => item.TadaTemplateNameId == expected.TadaTemplateNameId);

        Assert.Null(result);
    }
}
