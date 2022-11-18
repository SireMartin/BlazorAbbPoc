using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAbbPoc.Server.Migrations
{
    public partial class capture_more_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PActL1",
                table: "measurements",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PActL2",
                table: "measurements",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PActL3",
                table: "measurements",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PAppL1",
                table: "measurements",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PAppL2",
                table: "measurements",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PAppL3",
                table: "measurements",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nA",
                table: "measurements",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "pReactL1",
                table: "measurements",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "pReactL2",
                table: "measurements",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "pReactL3",
                table: "measurements",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PActL1",
                table: "measurements");

            migrationBuilder.DropColumn(
                name: "PActL2",
                table: "measurements");

            migrationBuilder.DropColumn(
                name: "PActL3",
                table: "measurements");

            migrationBuilder.DropColumn(
                name: "PAppL1",
                table: "measurements");

            migrationBuilder.DropColumn(
                name: "PAppL2",
                table: "measurements");

            migrationBuilder.DropColumn(
                name: "PAppL3",
                table: "measurements");

            migrationBuilder.DropColumn(
                name: "nA",
                table: "measurements");

            migrationBuilder.DropColumn(
                name: "pReactL1",
                table: "measurements");

            migrationBuilder.DropColumn(
                name: "pReactL2",
                table: "measurements");

            migrationBuilder.DropColumn(
                name: "pReactL3",
                table: "measurements");
        }
    }
}
