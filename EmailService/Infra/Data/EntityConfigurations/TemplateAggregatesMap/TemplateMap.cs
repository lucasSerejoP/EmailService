using Domain.AggregatesModel.TemplateAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.EntityConfigurations.TemplateAggregatesMap;

public class TemplateMap : IEntityTypeConfiguration<Template>
{
    public void Configure(EntityTypeBuilder<Template> builder)
    {
        builder.ToTable("Task");
        builder.HasKey(t => t.Id);

        builder.Property(it => it.Id).HasColumnName("Id").IsRequired();
        builder.Property(it => it.Html).HasColumnName("Html").HasColumnType("varchar(MAX)").IsRequired();
        builder.Property(it => it.HeaderField).HasColumnName("HeaderField").HasColumnType("Description").IsRequired();
        builder.Property(it => it.ContentField).HasColumnName("ContentField").HasColumnType("varchar(200)").IsRequired();
        builder.Property(it => it.FooterField).HasColumnName("FooterField").HasColumnType("varchar(200)").IsRequired();
        builder.Property(it => it.ButtonsField).HasColumnName("ButtonsField").HasColumnType("varchar(50)").IsRequired();
    }
}
