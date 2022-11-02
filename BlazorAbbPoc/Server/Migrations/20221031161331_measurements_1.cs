using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlazorAbbPoc.Server.Migrations
{
    public partial class measurements_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "measurements",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    device_id = table.Column<int>(type: "integer", nullable: false),
                    cre_timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    l1a = table.Column<int>(type: "integer", nullable: false),
                    l2a = table.Column<int>(type: "integer", nullable: false),
                    l3a = table.Column<int>(type: "integer", nullable: false),
                    l1nv = table.Column<int>(type: "integer", nullable: false),
                    l2nv = table.Column<int>(type: "integer", nullable: false),
                    l3nv = table.Column<int>(type: "integer", nullable: false),
                    l1l2v = table.Column<int>(type: "integer", nullable: false),
                    l2l3v = table.Column<int>(type: "integer", nullable: false),
                    l3l1v = table.Column<int>(type: "integer", nullable: false),
                    PActTotal = table.Column<int>(type: "integer", nullable: false),
                    PReactTotal = table.Column<int>(type: "integer", nullable: false),
                    PAppTotal = table.Column<int>(type: "integer", nullable: false),
                    Frq = table.Column<int>(type: "integer", nullable: false),
                    ProtA_L_I1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_measurements", x => x.id);
                    table.ForeignKey(
                        name: "FK_measurements_devices_device_id",
                        column: x => x.device_id,
                        principalTable: "devices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_measurements_device_id",
                table: "measurements",
                column: "device_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "measurements");
        }
    }
}
