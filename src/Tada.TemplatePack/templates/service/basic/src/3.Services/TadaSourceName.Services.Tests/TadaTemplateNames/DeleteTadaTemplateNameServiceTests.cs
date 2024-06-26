namespace TadaSourceName.Services.Tests.TadaTemplateNames;

public class DeleteTadaTemplateNameServiceTests : TadaTemplateNameServiceFixture
{

    public DeleteTadaTemplateNameServiceTests() : base()
    {

    }

    [Theory(Skip = "todo: check that delete was successful")]
    [InlineData("00000000-0000-0000-0000-000000000000")]
    public async Task DeleteTadaTemplateName_Success(string id)
    {
        var result = await context.DeleteTadaTemplateName(id);

        //todo: check that delete was successful
    }
}
