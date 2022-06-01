using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntrooApi.Migrations
{
    public partial class ConfigureManyToManyRelationsOnEventsAndStoreFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreFiles_Events_EventId",
                table: "StoreFiles");

            migrationBuilder.DropIndex(
                name: "IX_StoreFiles_EventId",
                table: "StoreFiles");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "StoreFiles");

            migrationBuilder.CreateTable(
                name: "EventStoreFile",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "INTEGER", nullable: false),
                    PhotosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStoreFile", x => new { x.EventsId, x.PhotosId });
                    table.ForeignKey(
                        name: "FK_EventStoreFile_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventStoreFile_StoreFiles_PhotosId",
                        column: x => x.PhotosId,
                        principalTable: "StoreFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventStoreFile_PhotosId",
                table: "EventStoreFile",
                column: "PhotosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventStoreFile");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "StoreFiles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreFiles_EventId",
                table: "StoreFiles",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreFiles_Events_EventId",
                table: "StoreFiles",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
