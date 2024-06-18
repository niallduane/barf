using Xunit;
using BarfSourceName.Infrastructure.BarfTemplateName;

namespace BarfSourceName.Infrastructure.BarfTemplateName.Tests;

public class BarfTemplateNameContextTests
{
    private readonly IBarfTemplateNameContext context;
    public BarfTemplateNameContextTests()
    {
        context = new BarfTemplateNameContext();
    }

    [Fact]
    public void BarfTemplateNameContext_Success()
    {
    }
}
