﻿// <auto-generated />
using System;
using EmailSender.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmailSender.Persistence.Migrations
{
    [DbContext(typeof(MailContext))]
    partial class MailContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EmailSender.Domain.Mail", b =>
                {
                    b.Property<string>("MailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("MailId")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(384000)
                        .HasColumnType("character varying(384000)")
                        .HasColumnName("Body");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("CreatedDate");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Sender");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("text")
                        .HasColumnName("Subject");

                    b.HasKey("MailId")
                        .HasName("mail_pkey");

                    b.ToTable("Mail", "public");
                });

            modelBuilder.Entity("EmailSender.Domain.SentMail", b =>
                {
                    b.Property<string>("SentMailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("SentMailId")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("MailId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("MailId");

                    b.Property<string>("Recipient")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Recipient");

                    b.Property<string>("Result")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("character varying")
                        .HasDefaultValue("Failed")
                        .HasColumnName("Result");

                    b.Property<string>("ResultDescription")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)")
                        .HasDefaultValue("Некорректная отправка")
                        .HasColumnName("ResultDescription");

                    b.HasKey("SentMailId")
                        .HasName("sentmail_pkey");

                    b.HasIndex("MailId");

                    b.ToTable("SentMail", "public");
                });

            modelBuilder.Entity("EmailSender.Domain.SentMail", b =>
                {
                    b.HasOne("EmailSender.Domain.Mail", "Mail")
                        .WithMany("Recipients")
                        .HasForeignKey("MailId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Mail");
                });

            modelBuilder.Entity("EmailSender.Domain.Mail", b =>
                {
                    b.Navigation("Recipients");
                });
#pragma warning restore 612, 618
        }
    }
}
