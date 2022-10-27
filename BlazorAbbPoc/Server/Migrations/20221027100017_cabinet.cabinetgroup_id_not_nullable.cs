using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAbbPoc.Server.Migrations
{
    public partial class cabinetcabinetgroup_id_not_nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cabinets_cabinetgroups_cabinetgroup_id",
                table: "cabinets");

            migrationBuilder.AlterColumn<int>(
                name: "cabinetgroup_id",
                table: "cabinets",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cabinets_cabinetgroups_cabinetgroup_id",
                table: "cabinets",
                column: "cabinetgroup_id",
                principalTable: "cabinetgroups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cabinets_cabinetgroups_cabinetgroup_id",
                table: "cabinets");

            migrationBuilder.AlterColumn<int>(
                name: "cabinetgroup_id",
                table: "cabinets",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_cabinets_cabinetgroups_cabinetgroup_id",
                table: "cabinets",
                column: "cabinetgroup_id",
                principalTable: "cabinetgroups",
                principalColumn: "id");
        }
    }
}
