using model = Domain.AggregatesModel.ForwardEmailAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.AggregatesModel.ForwardEmailAggregates;

namespace Infra.Data.EntityConfigurations.ForwardEmailAggregatesMap;

public class ForwardEmailMap : IEntityTypeConfiguration<model.ForwardEmail>
{
    public void Configure(EntityTypeBuilder<ForwardEmail> builder)
    {
        builder.ToTable("Task");
        builder.HasKey(t => t.Id);

        builder.Property(it => it.Id).HasColumnName("Id").IsRequired();
        builder.Property(it => it.Message).HasColumnName("Message").HasColumnType("varchar(MAX)").IsRequired();
        builder.Property(it => it.Subject).HasColumnName("Subject").HasColumnType("varchar(50)").IsRequired();
        builder.Property(it => it.DestinationEmail).HasColumnName("DestinationEmail").HasColumnType("varchar(200)").IsRequired();
        builder.Property(it => it.SourceEmail).HasColumnName("SourceEmail").HasColumnType("varchar(200)").IsRequired();
        builder.Property(it => it.CreationDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(it => it.LastModifiedDate).HasColumnName("LastModifiedDate").IsRequired();
        builder.Property(it => it.EmailConfigId).HasColumnName("EmailConfigId").IsRequired();
        builder.Property(it => it.TemplateId).HasColumnName("TemplateId").IsRequired();
    }
}
