namespace Tada.Cli.Models;

public class EntityTemplateConfiguration
{
    public string IdType { get;set;} = "Guid";
    public string IdTypeNameSpace {get;set;} = "";
}

public class TemplatePackConfiguration
{
    public EntityTemplateConfiguration Entity { get; set; } = new();
}