using Microsoft.EntityFrameworkCore.Metadata.Internal;

using model = Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore;
using map = Infra.Data.EntityConfigurations;

namespace Infra.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }

        public DbSet<model.ConfigEmailAggregates.ConfigEmail> ConfigEmails {  get; set; }
        public DbSet<model.ForwardEmailAggregates.ForwardEmail> ForwardEmails { get; set; }
        public DbSet<model.TemplateAggregate.Template> Templates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new map.ConfigEmailAggregatesMap.ConfigEmailMap());
            modelBuilder.ApplyConfiguration(new map.ForwardEmailAggregatesMap.ForwardEmailMap());
            modelBuilder.ApplyConfiguration(new map.TemplateAggregatesMap.TemplateMap());
        }
    }
}
