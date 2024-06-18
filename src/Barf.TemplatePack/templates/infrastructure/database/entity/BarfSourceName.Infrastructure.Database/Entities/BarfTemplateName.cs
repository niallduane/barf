using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarfSourceName.Infrastructure.Database.Entities;

[Table("BarfTemplateName")]
public class BarfTemplateName
{
    [Key]
    [Column("BarfTemplateNameId")]
    public Guid BarfTemplateNameId { get; set; } = Guid.Empty;
}