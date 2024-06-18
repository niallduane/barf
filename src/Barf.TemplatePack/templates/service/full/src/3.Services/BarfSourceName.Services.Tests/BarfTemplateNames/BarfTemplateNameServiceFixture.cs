using BarfSourceName.Domain.Core;
using BarfSourceName.Domain.Services.BarfTemplateNames;
using BarfSourceName.Infrastructure.Database.Entities;
using BarfSourceName.Infrastructure.Database.Repositories.BarfTemplateNames;
using BarfSourceName.Infrastructure.Database.Tests.Factories;
using BarfSourceName.Services.BarfTemplateNames;

using Moq;

namespace BarfSourceName.Services.Tests.BarfTemplateNames;

public class BarfTemplateNameServiceFixture
{
    protected readonly BarfTemplateNameFactory barftemplatenameFactory = new BarfTemplateNameFactory();
    protected readonly Mock<IBarfTemplateNameRepository> mockBarfTemplateNameRepository = new();
    protected readonly IBarfTemplateNameService context;

    public BarfTemplateNameServiceFixture()
    {
        mockBarfTemplateNameRepository.Setup(x => x.Create(It.IsAny<BarfTemplateName>()))
            .ReturnsAsync((BarfTemplateName barftemplatename) =>
            {
                barftemplatename.BarfTemplateNameId = Guid.NewGuid();
                return barftemplatename;
            });

        mockBarfTemplateNameRepository.Setup(x => x.GetBarfTemplateName(It.IsAny<Guid>()))
            .ReturnsAsync((Guid barftemplatenameId) =>
            {
                var barftemplatename = barftemplatenameFactory.Generate();
                barftemplatename.BarfTemplateNameId = barftemplatenameId;
                return barftemplatename;
            });

        mockBarfTemplateNameRepository.Setup(x => x.ListBarfTemplateNames(It.IsAny<BaseListRequest>()))
            .ReturnsAsync((BaseListRequest request) =>
            {
                var items = barftemplatenameFactory.Generate(50);
                return new PagedList<BarfTemplateName>(items, 50, 0, 50);
            });

        context = new BarfTemplateNameService(mockBarfTemplateNameRepository.Object);
    }
}
