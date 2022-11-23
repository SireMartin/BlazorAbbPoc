using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAbbPoc.Server.Migrations
{
    public partial class rename_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "pReactL3",
                table: "measurements",
                newName: "p_react_l3");

            migrationBuilder.RenameColumn(
                name: "pReactL2",
                table: "measurements",
                newName: "p_react_l2");

            migrationBuilder.RenameColumn(
                name: "pReactL1",
                table: "measurements",
                newName: "p_react_l1");

            migrationBuilder.RenameColumn(
                name: "nA",
                table: "measurements",
                newName: "n_a");

            migrationBuilder.RenameColumn(
                name: "PAppL3",
                table: "measurements",
                newName: "p_app_l3");

            migrationBuilder.RenameColumn(
                name: "PAppL2",
                table: "measurements",
                newName: "p_app_l2");

            migrationBuilder.RenameColumn(
                name: "PAppL1",
                table: "measurements",
                newName: "p_app_l1");

            migrationBuilder.RenameColumn(
                name: "PActL3",
                table: "measurements",
                newName: "p_act_l3");

            migrationBuilder.RenameColumn(
                name: "PActL2",
                table: "measurements",
                newName: "p_act_l2");

            migrationBuilder.RenameColumn(
                name: "PActL1",
                table: "measurements",
                newName: "p_act_l1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "p_react_l3",
                table: "measurements",
                newName: "pReactL3");

            migrationBuilder.RenameColumn(
                name: "p_react_l2",
                table: "measurements",
                newName: "pReactL2");

            migrationBuilder.RenameColumn(
                name: "p_react_l1",
                table: "measurements",
                newName: "pReactL1");

            migrationBuilder.RenameColumn(
                name: "p_app_l3",
                table: "measurements",
                newName: "PAppL3");

            migrationBuilder.RenameColumn(
                name: "p_app_l2",
                table: "measurements",
                newName: "PAppL2");

            migrationBuilder.RenameColumn(
                name: "p_app_l1",
                table: "measurements",
                newName: "PAppL1");

            migrationBuilder.RenameColumn(
                name: "p_act_l3",
                table: "measurements",
                newName: "PActL3");

            migrationBuilder.RenameColumn(
                name: "p_act_l2",
                table: "measurements",
                newName: "PActL2");

            migrationBuilder.RenameColumn(
                name: "p_act_l1",
                table: "measurements",
                newName: "PActL1");

            migrationBuilder.RenameColumn(
                name: "n_a",
                table: "measurements",
                newName: "nA");
        }
    }
}
