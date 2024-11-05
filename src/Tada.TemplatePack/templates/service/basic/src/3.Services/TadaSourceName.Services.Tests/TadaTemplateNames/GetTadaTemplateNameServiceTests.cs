using TadaSourceName.Domain.Core;
using TadaSourceName.Domain.Services.TadaTemplateNames.Models;
using TadaSourceName.Infrastructure.Database.Entities;
#if (TadaIdNameSpace != null) 
using TadaIdNameSpace;
#endif 
using Moq;

namespace TadaSourceName.Services.Tests.TadaTemplateNames;

public class GetTadaTemplateNameServiceTests : TadaTemplateNameServiceFixture
{

    [Fact]
    public async Task GetTadaTemplateName()
    {
        #if(use_repository)
        var expected = tadatemplatenameFactory.Generate();

        mockTadaTemplateNameRepository.Setup(x => x.GetTadaTemplateName(It.IsAny<TadaIdType>()))
            .ReturnsAsync((TadaIdType tadatemplatenameId) => expected);

        var result = await context.GetTadaTemplateName(expected.TadaTemplateNameId);

        Assert.NotNull(result);
        Assert.Equal(expected.TadaTemplateNameId.ToString(), result.Id);
        #else
        throw new NotImplementedException();
        #endif
    }

    [Fact]
    public async Task ListTadaTemplateName_Success()
    {
        #if(use_repository)
        var expected = tadatemplatenameFactory.Generate(50);

        mockTadaTemplateNameRepository.Setup(x => x.ListTadaTemplateNames(It.IsAny<BaseListRequest>()))
            .ReturnsAsync((BaseListRequest request) => new PagedList<TadaTemplateName>(expected, 50, 0, 50));

        var searchFilter = new ListTadaTemplateNameRequest();

        var result = await context.ListTadaTemplateNames(searchFilter);

        Assert.NotNull(result);

        expected.ForEach(expectedItem =>
        {
            var item = result.First(resultItem => resultItem.Id == expectedItem.TadaTemplateNameId);
            Assert.NotNull(item);
        });
        Assert.Equal(50, result.Count);
        Assert.Equal(0, result.Page);
        Assert.Equal(1, result.Pages);
        #else
        throw new NotImplementedException();
        #endif
    }

}
