using Xunit;
using TadaSourceName.Infrastructure.TadaTemplateName;

namespace TadaSourceName.Infrastructure.TadaTemplateName.Tests;

public class TadaTemplateNameContextTests
{
    private readonly ITadaTemplateNameContext context;
    public TadaTemplateNameContextTests()
    {
        context = new TadaTemplateNameContext();
    }

    [Fact]
    public void TadaTemplateNameContext_Success()
    {
    }
}
