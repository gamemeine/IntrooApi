using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntrooApi.Migrations
{
    public partial class FixRelationsPartTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Events",
                newName: "RepairId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RepairId",
                table: "Events",
                newName: "CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Events",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
