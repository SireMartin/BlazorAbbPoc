using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAbbPoc.Server.Migrations
{
    public partial class rename_devicename_to_plcdeviceid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "devices",
                newName: "plc_device_id");

            migrationBuilder.RenameIndex(
                name: "IX_devices_name",
                table: "devices",
                newName: "IX_devices_plc_device_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "plc_device_id",
                table: "devices",
                newName: "name");

            migrationBuilder.RenameIndex(
                name: "IX_devices_plc_device_id",
                table: "devices",
                newName: "IX_devices_name");
        }
    }
}
