using BarfSourceName.Domain.Core;
using BarfSourceName.Domain.Services.BarfTemplateNames.Models;
using BarfSourceName.Infrastructure.Database.Entities;

using Moq;

namespace BarfSourceName.Services.Tests.BarfTemplateNames;

public class GetBarfTemplateNameServiceTests : BarfTemplateNameServiceFixture
{
    public GetBarfTemplateNameServiceTests() : base()
    {

    }

    [Fact]
    public async Task GetBarfTemplateName()
    {
        var expected = barftemplatenameFactory.Generate();

        mockBarfTemplateNameRepository.Setup(x => x.GetBarfTemplateName(It.IsAny<Guid>()))
            .ReturnsAsync((Guid barftemplatenameId) => expected);

        var result = await context.GetBarfTemplateName(expected.BarfTemplateNameId.ToString());

        Assert.NotNull(result);
        Assert.Equal(expected.BarfTemplateNameId.ToString(), result.Id);
    }

    [Fact]
    public async Task ListBarfTemplateName_Success()
    {
        var expected = barftemplatenameFactory.Generate(50);

        mockBarfTemplateNameRepository.Setup(x => x.ListBarfTemplateNames(It.IsAny<BaseListRequest>()))
            .ReturnsAsync((BaseListRequest request) => new PagedList<BarfTemplateName>(expected, 50, 0, 50));

        var searchFilter = new ListBarfTemplateNameRequest();

        var result = await context.ListBarfTemplateNames(searchFilter);

        Assert.NotNull(result);

        expected.ForEach(expectedItem =>
        {
            var item = result.First(resultItem => resultItem.Id == expectedItem.BarfTemplateNameId.ToString());
            Assert.NotNull(item);
        });
        Assert.Equal(50, result.Count);
        Assert.Equal(0, result.Page);
        Assert.Equal(1, result.Pages);
    }

}
