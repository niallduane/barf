using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TadaSourceName.Infrastructure.Database.Entities;

[Table("TadaTemplateNames")]
public class TadaTemplateName
{
    [Key]
    [Column("TadaTemplateNameId")]
    public Guid TadaTemplateNameId { get; set; } = Guid.Empty;
}

public class TadaTemplateNameConfiguration: IEntityTypeConfiguration<TadaTemplateName>
{
    public void Configure(EntityTypeBuilder<TadaTemplateName> builder)
    {

    }
}