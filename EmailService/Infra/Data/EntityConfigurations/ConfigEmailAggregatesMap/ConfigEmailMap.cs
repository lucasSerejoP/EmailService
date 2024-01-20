using model = Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.AggregatesModel.ConfigEmailAggregates;

namespace Infra.Data.EntityConfigurations.ConfigEmailAggregatesMap;

public class ConfigEmailMap : IEntityTypeConfiguration<model.ConfigEmailAggregates.ConfigEmail>
{
    public void Configure(EntityTypeBuilder<ConfigEmail> builder)
    {
        builder.ToTable("Task");
        builder.HasKey(t => t.Id);

        builder.Property(it => it.Id).HasColumnName("Id").IsRequired();
        builder.Property(it => it.SourceEmail).HasColumnName("SourceEmail").HasColumnType("varchar(200)").IsRequired();
        builder.Property(it => it.Subject).HasColumnName("Subject").HasColumnType("varchar(50)").IsRequired();
        builder.Property(it => it.DefaultMessage).HasColumnName("DefaultMessage").HasColumnType("varchar(MAX)").IsRequired();
        builder.Property(it => it.DefaultFooter).HasColumnName("DefaultFooter").HasColumnType("varchar(200)").IsRequired();
        builder.Property(it => it.DefaultButtons).HasColumnName("DefaultButtons").HasColumnType("varchar(200)").IsRequired();
        builder.Property(it => it.TemplateId).HasColumnName("TemplateId").IsRequired();
        builder.Property(it => it.CreationDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(it => it.LastModifiedDate).HasColumnName("LastModifiedDate").IsRequired();
    }
}
