using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MailMan.Dal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Result = table.Column<int>(type: "integer", nullable: false),
                    FailedMessage = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipients",
                columns: table => new
                {
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipients", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "MailMessageRecipient",
                columns: table => new
                {
                    MailMessagesId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipientsEmail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailMessageRecipient", x => new { x.MailMessagesId, x.RecipientsEmail });
                    table.ForeignKey(
                        name: "FK_MailMessageRecipient_MailMessages_MailMessagesId",
                        column: x => x.MailMessagesId,
                        principalTable: "MailMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MailMessageRecipient_Recipients_RecipientsEmail",
                        column: x => x.RecipientsEmail,
                        principalTable: "Recipients",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MailMessageRecipient_RecipientsEmail",
                table: "MailMessageRecipient",
                column: "RecipientsEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailMessageRecipient");

            migrationBuilder.DropTable(
                name: "MailMessages");

            migrationBuilder.DropTable(
                name: "Recipients");
        }
    }
}
