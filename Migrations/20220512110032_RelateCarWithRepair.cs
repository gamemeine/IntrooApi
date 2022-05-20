using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntrooApi.Migrations
{
    public partial class RelateCarWithRepair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Repairs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_CarId",
                table: "Repairs",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Cars_CarId",
                table: "Repairs",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Cars_CarId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_CarId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Repairs");
        }
    }
}
