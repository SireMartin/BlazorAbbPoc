using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAbbPoc.Server.Migrations
{
    public partial class measurements_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Frq",
                table: "measurements",
                newName: "frq");

            migrationBuilder.RenameColumn(
                name: "l3nv",
                table: "measurements",
                newName: "l3_n_v");

            migrationBuilder.RenameColumn(
                name: "l3l1v",
                table: "measurements",
                newName: "l3_l1_v");

            migrationBuilder.RenameColumn(
                name: "l3a",
                table: "measurements",
                newName: "l3_a");

            migrationBuilder.RenameColumn(
                name: "l2nv",
                table: "measurements",
                newName: "l2_n_v");

            migrationBuilder.RenameColumn(
                name: "l2l3v",
                table: "measurements",
                newName: "l2_l3_v");

            migrationBuilder.RenameColumn(
                name: "l2a",
                table: "measurements",
                newName: "l2_a");

            migrationBuilder.RenameColumn(
                name: "l1nv",
                table: "measurements",
                newName: "l1_n_v");

            migrationBuilder.RenameColumn(
                name: "l1l2v",
                table: "measurements",
                newName: "l1_l2_v");

            migrationBuilder.RenameColumn(
                name: "l1a",
                table: "measurements",
                newName: "l1_a");

            migrationBuilder.RenameColumn(
                name: "ProtA_L_I1",
                table: "measurements",
                newName: "prot_a_l_i1");

            migrationBuilder.RenameColumn(
                name: "PReactTotal",
                table: "measurements",
                newName: "p_react_totoal");

            migrationBuilder.RenameColumn(
                name: "PAppTotal",
                table: "measurements",
                newName: "p_app_totoal");

            migrationBuilder.RenameColumn(
                name: "PActTotal",
                table: "measurements",
                newName: "p_act_totoal");

            migrationBuilder.CreateIndex(
                name: "IX_measurements_cre_timestamp",
                table: "measurements",
                column: "cre_timestamp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_measurements_cre_timestamp",
                table: "measurements");

            migrationBuilder.RenameColumn(
                name: "frq",
                table: "measurements",
                newName: "Frq");

            migrationBuilder.RenameColumn(
                name: "prot_a_l_i1",
                table: "measurements",
                newName: "ProtA_L_I1");

            migrationBuilder.RenameColumn(
                name: "p_react_totoal",
                table: "measurements",
                newName: "PReactTotal");

            migrationBuilder.RenameColumn(
                name: "p_app_totoal",
                table: "measurements",
                newName: "PAppTotal");

            migrationBuilder.RenameColumn(
                name: "p_act_totoal",
                table: "measurements",
                newName: "PActTotal");

            migrationBuilder.RenameColumn(
                name: "l3_n_v",
                table: "measurements",
                newName: "l3nv");

            migrationBuilder.RenameColumn(
                name: "l3_l1_v",
                table: "measurements",
                newName: "l3l1v");

            migrationBuilder.RenameColumn(
                name: "l3_a",
                table: "measurements",
                newName: "l3a");

            migrationBuilder.RenameColumn(
                name: "l2_n_v",
                table: "measurements",
                newName: "l2nv");

            migrationBuilder.RenameColumn(
                name: "l2_l3_v",
                table: "measurements",
                newName: "l2l3v");

            migrationBuilder.RenameColumn(
                name: "l2_a",
                table: "measurements",
                newName: "l2a");

            migrationBuilder.RenameColumn(
                name: "l1_n_v",
                table: "measurements",
                newName: "l1nv");

            migrationBuilder.RenameColumn(
                name: "l1_l2_v",
                table: "measurements",
                newName: "l1l2v");

            migrationBuilder.RenameColumn(
                name: "l1_a",
                table: "measurements",
                newName: "l1a");
        }
    }
}
