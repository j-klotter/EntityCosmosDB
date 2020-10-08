using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramworkCosmos.Models
{
    public class CaseDbContext : DbContext
    {
        public DbSet<Case> Cases { get; set; }

        public CaseDbContext(DbContextOptions<CaseDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseCosmos("https://mycosmodbv1.documents.azure.com",
                    "rn1m4FUDBwEFLQMYnY76MWKQcCf9AmX4p2J6KLOA9coSimKEdAUyh6hQV5dUEEK6b5mNg5kYvgQGuC7pJd3VKg==",
                    databaseName: "OrdersDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Case>()
                .ToContainer("Case");

            modelBuilder.Entity<Case>()
                .HasNoDiscriminator();

            modelBuilder.Entity<Case>()
                .HasPartitionKey(o => o.PartitionKey);

            modelBuilder.Entity<Case>().Property(o => o.Id).ToJsonProperty("caseId");
            modelBuilder.Entity<Case>().Property(o => o.Version).ToJsonProperty("version");
            modelBuilder.Entity<Case>().Property(o => o.RevisionNumber).ToJsonProperty("revisionNumber");
            modelBuilder.Entity<Case>().Property(o => o.PartitionKey).ToJsonProperty("PartitionKey");
        }

    }
}
