using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using EmailSender.Application.Interfaces;
using EmailSender.Domain;
using Microsoft.Extensions.Options;

namespace EmailSender.Persistence
{
    public class MailContext : DbContext, IMailContext
    {
        public MailContext(DbContextOptions<MailContext> options)
            : base(options) { }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Mail> Mails { get; set; } = null!;
        public virtual DbSet<SentMail> SentMails { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Email).HasName("user_pkey");

                entity.ToTable("User");

                entity.Property(e => e.Email)
                   .HasColumnName("Email");
            });
            //          public string Id { get; set; }
            //public string Subject { get; set; }
            //public string Body { get; set; }
            //public DateTime Created { get; set; }
            modelBuilder.Entity<Mail>(entity =>
            {
                entity.HasKey(e => e.MailId).HasName("user_pkey");

                entity.ToTable("Mail");

                entity.Property(e => e.MailId)
                   .HasColumnName("MailId")
                   .UseIdentityAlwaysColumn();

                entity.Property(e => e.Body)
                    .HasMaxLength(384000)
                    .HasColumnName("Body");

                entity.Property(e => e.Subject)
                    .HasMaxLength(1000)
                    .HasColumnType("text")
                    .HasColumnName("Subject");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("CreatedDate");
            });

            modelBuilder.Entity<SentMail>(entity =>
            {
                entity
                    .HasKey(e => new { e.MailId, e.SenderId, e.RecipientId })
                    .HasName("user_pkey");

                entity.ToTable("SentMail");

                entity.Property(e => e.MailId)
                    .HasColumnName("MailId");

                entity.Property(e => e.RecipientId)
                    .HasColumnName("RecipientId");

                entity.Property(e => e.SenderId)
                    .HasColumnName("SenderId");

                entity.Property(e => e.Result)
                    .HasColumnName("Result");

                entity.Property(e => e.ResultDescription)
                    .HasMaxLength(1024)
                    .HasColumnName("ResultDescription");
            });
        }
    }
}