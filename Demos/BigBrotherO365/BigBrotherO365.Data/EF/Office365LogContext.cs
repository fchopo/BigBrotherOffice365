using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BigBrotherO365.Data.EF
{
    public partial class Office365LogContext : DbContext
    {
        public virtual DbSet<ActivityLogs> ActivityLogs { get; set; }

        public Office365LogContext(DbContextOptions<Office365LogContext> options): base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityLogs>(entity =>
            {
                entity.HasKey(e => e.Idlog);

                entity.ToTable("Activity_Logs");

                entity.Property(e => e.Idlog).HasColumnName("IDLog");

                entity.Property(e => e.ClientIp)
                    .HasColumnName("ClientIP")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CorrelationId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.EventSource)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ItemType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ListId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ListItemUniqueId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ObjectId)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Operation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Site)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SiteUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SourceFileExtension)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SourceFileName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SourceRelativeUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserAgent)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WebId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Workload)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
