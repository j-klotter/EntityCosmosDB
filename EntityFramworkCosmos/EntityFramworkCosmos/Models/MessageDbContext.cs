using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramworkCosmos.Models
{
    public class MessageDbContext : DbContext
    {
        public DbSet<MessageDto> Message { get; set; }

        public MessageDbContext(DbContextOptions<MessageDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseCosmos("https://mycosmodbv1.documents.azure.com",
                    "rn1m4FUDBwEFLQMYnY76MWKQcCf9AmX4p2J6KLOA9coSimKEdAUyh6hQV5dUEEK6b5mNg5kYvgQGuC7pJd3VKg==",
                    databaseName:"OrdersDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageDto>()
                .ToContainer("Message");

            modelBuilder.Entity<MessageDto>()
                .HasNoDiscriminator();

            modelBuilder.Entity<MessageDto>()
                .HasPartitionKey(o => o.PartitionKey);


            modelBuilder.Entity<MessageDto>().OwnsOne(
                o => o.Header,
                sa =>
                {
                    sa.ToJsonProperty("header");
                    sa.Property(p => p.Receiver).ToJsonProperty("receiverMail");
                    sa.Property(p => p.RevisionNr).ToJsonProperty("revisionNumber");
                    sa.Property(p => p.Sender).ToJsonProperty("senderMail");
                    sa.Property(p => p.Subject).ToJsonProperty("subject");
                    sa.Property(p => p.Type).ToJsonProperty("type");
                    sa.Property(p => p.TimestampSend).ToJsonProperty("timestampSend");
                    sa.Property(p => p.TimestampReceive).ToJsonProperty("timestampReceive");
                    sa.Property(p => p.VersionNo).ToJsonProperty("versionNo");
                    sa.Property(p => p.CaseId).ToJsonProperty("caseid");
                    sa.Property(p => p.CaseName).ToJsonProperty("caseName");
                });


            modelBuilder.Entity<MessageDto>().OwnsOne(
                o => o.Body,
                sa =>
                {
                    sa.ToJsonProperty("body");
                    sa.Property(p => p.Message).ToJsonProperty("message");
                    sa.Property(p => p.Version).ToJsonProperty("version");
                    sa.Property(p => p.ContentId).ToJsonProperty("fileId");
                }
                );



        }

    }
}
