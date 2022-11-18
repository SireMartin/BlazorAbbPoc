using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAbbPoc.Server.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "parent_cabinet_id",
                table: "cabinets",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cabinets_parent_cabinet_id",
                table: "cabinets",
                column: "parent_cabinet_id");

            migrationBuilder.AddForeignKey(
                name: "FK_cabinets_cabinets_parent_cabinet_id",
                table: "cabinets",
                column: "parent_cabinet_id",
                principalTable: "cabinets",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cabinets_cabinets_parent_cabinet_id",
                table: "cabinets");

            migrationBuilder.DropIndex(
                name: "IX_cabinets_parent_cabinet_id",
                table: "cabinets");

            migrationBuilder.DropColumn(
                name: "parent_cabinet_id",
                table: "cabinets");
        }
    }
}
