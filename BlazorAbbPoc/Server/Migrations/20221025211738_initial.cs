using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlazorAbbPoc.Server.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cabinetgroups",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cabinetgroups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cabinets",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cabinets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "devicetypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devicetypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "devices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    device_id = table.Column<string>(type: "text", nullable: false),
                    devicetype_id = table.Column<int>(type: "integer", nullable: false),
                    max_value = table.Column<int>(type: "integer", nullable: false),
                    cabinetgroup_id = table.Column<int>(type: "integer", nullable: false),
                    cabinet_id = table.Column<int>(type: "integer", nullable: false),
                    cabinet_position = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devices", x => x.id);
                    table.ForeignKey(
                        name: "FK_devices_cabinetgroups_cabinetgroup_id",
                        column: x => x.cabinetgroup_id,
                        principalTable: "cabinetgroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_devices_cabinets_cabinet_id",
                        column: x => x.cabinet_id,
                        principalTable: "cabinets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_devices_devicetypes_devicetype_id",
                        column: x => x.devicetype_id,
                        principalTable: "devicetypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_devices_cabinet_id",
                table: "devices",
                column: "cabinet_id");

            migrationBuilder.CreateIndex(
                name: "IX_devices_cabinetgroup_id",
                table: "devices",
                column: "cabinetgroup_id");

            migrationBuilder.CreateIndex(
                name: "IX_devices_devicetype_id",
                table: "devices",
                column: "devicetype_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "devices");

            migrationBuilder.DropTable(
                name: "cabinetgroups");

            migrationBuilder.DropTable(
                name: "cabinets");

            migrationBuilder.DropTable(
                name: "devicetypes");
        }
    }
}
