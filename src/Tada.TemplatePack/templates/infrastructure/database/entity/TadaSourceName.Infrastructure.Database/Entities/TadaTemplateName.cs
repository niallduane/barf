using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TadaSourceName.Infrastructure.Database.Entities;

[Table("TadaTemplateNames")]
public class TadaTemplateName
{
    [Key]
    [Column("TadaTemplateNameId")]
    public Guid TadaTemplateNameId { get; set; } = Guid.Empty;
}