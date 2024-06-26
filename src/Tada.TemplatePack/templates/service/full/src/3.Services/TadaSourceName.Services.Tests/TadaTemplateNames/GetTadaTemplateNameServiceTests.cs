using TadaSourceName.Domain.Core;
using TadaSourceName.Domain.Services.TadaTemplateNames.Models;
using TadaSourceName.Infrastructure.Database.Entities;

using Moq;

namespace TadaSourceName.Services.Tests.TadaTemplateNames;

public class GetTadaTemplateNameServiceTests : TadaTemplateNameServiceFixture
{
    public GetTadaTemplateNameServiceTests() : base()
    {

    }

    [Fact]
    public async Task GetTadaTemplateName()
    {
        var expected = tadatemplatenameFactory.Generate();

        mockTadaTemplateNameRepository.Setup(x => x.GetTadaTemplateName(It.IsAny<Guid>()))
            .ReturnsAsync((Guid tadatemplatenameId) => expected);

        var result = await context.GetTadaTemplateName(expected.TadaTemplateNameId.ToString());

        Assert.NotNull(result);
        Assert.Equal(expected.TadaTemplateNameId.ToString(), result.Id);
    }

    [Fact]
    public async Task ListTadaTemplateName_Success()
    {
        var expected = tadatemplatenameFactory.Generate(50);

        mockTadaTemplateNameRepository.Setup(x => x.ListTadaTemplateNames(It.IsAny<BaseListRequest>()))
            .ReturnsAsync((BaseListRequest request) => new PagedList<TadaTemplateName>(expected, 50, 0, 50));

        var searchFilter = new ListTadaTemplateNameRequest();

        var result = await context.ListTadaTemplateNames(searchFilter);

        Assert.NotNull(result);

        expected.ForEach(expectedItem =>
        {
            var item = result.First(resultItem => resultItem.Id == expectedItem.TadaTemplateNameId.ToString());
            Assert.NotNull(item);
        });
        Assert.Equal(50, result.Count);
        Assert.Equal(0, result.Page);
        Assert.Equal(1, result.Pages);
    }

}
