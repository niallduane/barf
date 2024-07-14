using TadaSourceName.Domain.Core;
using TadaSourceName.Domain.Services.TadaTemplateNames;
using TadaSourceName.Infrastructure.Database.Entities;
using TadaSourceName.Infrastructure.Database.Repositories.TadaTemplateNames;
using TadaSourceName.Infrastructure.Database.Tests.Factories;
using TadaSourceName.Services.TadaTemplateNames;

using Moq;

namespace TadaSourceName.Services.Tests.TadaTemplateNames;

public class TadaTemplateNameServiceFixture
{
    protected readonly TadaTemplateNameFactory tadatemplatenameFactory = new TadaTemplateNameFactory();
    protected readonly Mock<ITadaTemplateNameRepository> mockTadaTemplateNameRepository = new();
    protected readonly ITadaTemplateNameService context;

    public TadaTemplateNameServiceFixture()
    {
        mockTadaTemplateNameRepository.Setup(x => x.Create(It.IsAny<TadaTemplateName>()))
            .ReturnsAsync((TadaTemplateName tadatemplatename) =>
            {
                tadatemplatename.TadaTemplateNameId = Guid.NewGuid();
                return tadatemplatename;
            });

        mockTadaTemplateNameRepository.Setup(x => x.Update(It.IsAny<Guid>(), It.IsAny<Dictionary<string, object?>>()))
            .ReturnsAsync((Guid id, Dictionary<string, object?> newValues) =>
            {
                return new TadaTemplateName
                {
                    TadaTemplateNameId = id
                };
            });

        mockTadaTemplateNameRepository.Setup(x => x.GetTadaTemplateName(It.IsAny<Guid>()))
            .ReturnsAsync((Guid tadatemplatenameId) =>
            {
                var tadatemplatename = tadatemplatenameFactory.Generate();
                tadatemplatename.TadaTemplateNameId = tadatemplatenameId;
                return tadatemplatename;
            });

        mockTadaTemplateNameRepository.Setup(x => x.ListTadaTemplateNames(It.IsAny<BaseListRequest>()))
            .ReturnsAsync((BaseListRequest request) =>
            {
                var items = tadatemplatenameFactory.Generate(50);
                return new PagedList<TadaTemplateName>(items, 50, 0, 50);
            });

        context = new TadaTemplateNameService(mockTadaTemplateNameRepository.Object);
    }
}
