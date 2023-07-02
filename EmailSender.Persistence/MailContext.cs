using Microsoft.EntityFrameworkCore;
using EmailSender.Application.Interfaces;
using EmailSender.Domain;

namespace EmailSender.Persistence
{
    public class MailContext : DbContext, IMailContext
    {
        public MailContext(DbContextOptions<MailContext> options)
            : base(options) { }
        public virtual DbSet<Mail> Mails { get; set; } = null!;
        public virtual DbSet<SentMail> SentMails { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<Mail>(entity =>
            {
                entity.HasKey(e => e.MailId).HasName("mail_pkey");

                entity.ToTable("Mail");

                entity.Property(e => e.MailId)
                   .HasColumnName("MailId")
                   .ValueGeneratedOnAdd()
                   .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Sender)
                    .HasMaxLength(255)
                    .HasColumnName("Sender");

                entity.Property(e => e.Subject)
                    .HasMaxLength(1000)
                    .HasColumnName("Subject");

                entity.Property(e => e.Body)
                    .HasMaxLength(384000)
                    .HasColumnType("text")
                    .HasColumnName("Body");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("CreatedDate");
            });

            modelBuilder.Entity<SentMail>(entity =>
            {
                entity.HasKey(e => e.SentMailId).HasName("sentmail_pkey");

                entity.ToTable("SentMail");

                entity.Property(e => e.SentMailId)
                   .HasColumnName("SentMailId")
                   .ValueGeneratedOnAdd()
                   .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.MailId)
                    .HasColumnName("MailId");

                entity.Property(e => e.Recipient)
                    .HasColumnName("Recipient");

                entity.Property(e => e.Result)
                    .HasConversion(v => v.ToString(),
                    v => (ResultEnum)Enum.Parse(typeof(ResultEnum),v)).IsUnicode(false)
                    .HasColumnType("character varying")
                    .HasMaxLength(16)
                    .HasColumnName("Result")
                    .HasDefaultValue(ResultEnum.OK);

                entity.Property(e => e.FailedMessage)
                    .HasMaxLength(1024)
                    .HasColumnName("FailedMessage");

                entity.HasOne<Mail>(s => s.Mail)
                    .WithMany(u => u.Recipients)
                    .HasForeignKey(s => s.MailId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}