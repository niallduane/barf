using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TadaSourceName.Domain.Core;
#if (TadaIdNameSpace != null) 
using TadaIdNameSpace;
#endif 

namespace TadaSourceName.Infrastructure.Database.Entities;

[Table("TadaTemplateNames")]
public class TadaTemplateName
{
    [Key]
    [Column("TadaTemplateNameId")]
    public TadaEntityIdType TadaTemplateNameId { get; set; }
}

public class TadaTemplateNameConfiguration: IEntityTypeConfiguration<TadaTemplateName>
{
    public void Configure(EntityTypeBuilder<TadaTemplateName> builder)
    {

    }
}