namespace BarfSourceName.Services.Tests.BarfTemplateNames;

public class DeleteBarfTemplateNameServiceTests : BarfTemplateNameServiceFixture
{

    public DeleteBarfTemplateNameServiceTests() : base()
    {

    }

    [Theory(Skip = "todo: check that delete was successful")]
    [InlineData("00000000-0000-0000-0000-000000000000")]
    public async Task DeleteBarfTemplateName_Success(string id)
    {
        var result = await context.DeleteBarfTemplateName(id);

        //todo: check that delete was successful
    }
}
