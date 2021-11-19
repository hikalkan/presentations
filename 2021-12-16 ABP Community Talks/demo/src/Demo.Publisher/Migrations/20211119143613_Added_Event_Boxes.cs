using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Publisher.Migrations
{
    public partial class Added_Event_Boxes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpEventInbox",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EventName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EventData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Processed = table.Column<bool>(type: "bit", nullable: false),
                    ProcessedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEventInbox", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpEventOutbox",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EventData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEventOutbox", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEventInbox_MessageId",
                table: "AbpEventInbox",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpEventInbox_Processed_CreationTime",
                table: "AbpEventInbox",
                columns: new[] { "Processed", "CreationTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEventOutbox_CreationTime",
                table: "AbpEventOutbox",
                column: "CreationTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpEventInbox");

            migrationBuilder.DropTable(
                name: "AbpEventOutbox");
        }
    }
}
