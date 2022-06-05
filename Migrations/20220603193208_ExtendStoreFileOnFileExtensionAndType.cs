using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntrooApi.Migrations
{
    public partial class ExtendStoreFileOnFileExtensionAndType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "StoreFiles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "StoreFiles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extension",
                table: "StoreFiles");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "StoreFiles");
        }
    }
}
