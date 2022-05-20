using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntrooApi.Migrations
{
    public partial class ChangeEventRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Events_RepairId",
                table: "Events",
                column: "RepairId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Repairs_RepairId",
                table: "Events",
                column: "RepairId",
                principalTable: "Repairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Repairs_RepairId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_RepairId",
                table: "Events");
        }
    }
}
