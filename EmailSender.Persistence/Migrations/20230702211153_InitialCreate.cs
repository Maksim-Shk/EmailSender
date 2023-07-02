using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailSender.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Mail",
                schema: "public",
                columns: table => new
                {
                    MailId = table.Column<string>(type: "text", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Sender = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Subject = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Body = table.Column<string>(type: "text", maxLength: 384000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("mail_pkey", x => x.MailId);
                });

            migrationBuilder.CreateTable(
                name: "SentMail",
                schema: "public",
                columns: table => new
                {
                    SentMailId = table.Column<string>(type: "text", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    MailId = table.Column<string>(type: "text", nullable: false),
                    Recipient = table.Column<string>(type: "text", nullable: false),
                    Result = table.Column<string>(type: "character varying", unicode: false, maxLength: 16, nullable: false, defaultValue: "OK"),
                    FailedMessage = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sentmail_pkey", x => x.SentMailId);
                    table.ForeignKey(
                        name: "FK_SentMail_Mail_MailId",
                        column: x => x.MailId,
                        principalSchema: "public",
                        principalTable: "Mail",
                        principalColumn: "MailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SentMail_MailId",
                schema: "public",
                table: "SentMail",
                column: "MailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SentMail",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Mail",
                schema: "public");
        }
    }
}
