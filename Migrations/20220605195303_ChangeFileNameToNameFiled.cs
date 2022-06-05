using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntrooApi.Migrations
{
    public partial class ChangeFileNameToNameFiled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "StoreFiles",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "StoreFiles",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "StoreFiles",
                newName: "FileName");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "StoreFiles",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
