using BarfSourceName.Domain.Services.BarfTemplateNames;
using BarfSourceName.Services.BarfTemplateNames;

namespace BarfSourceName.Services.Tests.BarfTemplateNames;

public class BarfTemplateNameServiceFixture
{
    protected readonly IBarfTemplateNameService context;

    public BarfTemplateNameServiceFixture()
    {
        context = new BarfTemplateNameService();
    }
}
