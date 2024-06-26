using TadaSourceName.Domain.Services.TadaTemplateNames;
using TadaSourceName.Services.TadaTemplateNames;

namespace TadaSourceName.Services.Tests.TadaTemplateNames;

public class TadaTemplateNameServiceFixture
{
    protected readonly ITadaTemplateNameService context;

    public TadaTemplateNameServiceFixture()
    {
        context = new TadaTemplateNameService();
    }
}
