using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAbbPoc.Server.Migrations
{
    public partial class cabinet_to_cabinetgroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_devices_cabinetgroups_cabinetgroup_id",
                table: "devices");

            migrationBuilder.DropIndex(
                name: "IX_devices_cabinetgroup_id",
                table: "devices");

            migrationBuilder.DropColumn(
                name: "cabinetgroup_id",
                table: "devices");

            migrationBuilder.RenameColumn(
                name: "device_id",
                table: "devices",
                newName: "name");

            migrationBuilder.RenameIndex(
                name: "IX_devices_device_id",
                table: "devices",
                newName: "IX_devices_name");

            migrationBuilder.AddColumn<int>(
                name: "cabinetgroup_id",
                table: "cabinets",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_devicetypes_name",
                table: "devicetypes",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cabinets_cabinetgroup_id",
                table: "cabinets",
                column: "cabinetgroup_id");

            migrationBuilder.CreateIndex(
                name: "IX_cabinets_name",
                table: "cabinets",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cabinetgroups_name",
                table: "cabinetgroups",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cabinets_cabinetgroups_cabinetgroup_id",
                table: "cabinets",
                column: "cabinetgroup_id",
                principalTable: "cabinetgroups",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cabinets_cabinetgroups_cabinetgroup_id",
                table: "cabinets");

            migrationBuilder.DropIndex(
                name: "IX_devicetypes_name",
                table: "devicetypes");

            migrationBuilder.DropIndex(
                name: "IX_cabinets_cabinetgroup_id",
                table: "cabinets");

            migrationBuilder.DropIndex(
                name: "IX_cabinets_name",
                table: "cabinets");

            migrationBuilder.DropIndex(
                name: "IX_cabinetgroups_name",
                table: "cabinetgroups");

            migrationBuilder.DropColumn(
                name: "cabinetgroup_id",
                table: "cabinets");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "devices",
                newName: "device_id");

            migrationBuilder.RenameIndex(
                name: "IX_devices_name",
                table: "devices",
                newName: "IX_devices_device_id");

            migrationBuilder.AddColumn<int>(
                name: "cabinetgroup_id",
                table: "devices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_devices_cabinetgroup_id",
                table: "devices",
                column: "cabinetgroup_id");

            migrationBuilder.AddForeignKey(
                name: "FK_devices_cabinetgroups_cabinetgroup_id",
                table: "devices",
                column: "cabinetgroup_id",
                principalTable: "cabinetgroups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
