using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPizzaApp.Migrations
{
    public partial class RendelesNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rendelesek_Cimek_CimId",
                table: "Rendelesek");

            migrationBuilder.DropForeignKey(
                name: "FK_Rendelesek_Futarok_FutarId",
                table: "Rendelesek");

            migrationBuilder.AlterColumn<int>(
                name: "FutarId",
                table: "Rendelesek",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CimId",
                table: "Rendelesek",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Rendelesek_Cimek_CimId",
                table: "Rendelesek",
                column: "CimId",
                principalTable: "Cimek",
                principalColumn: "CimId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rendelesek_Futarok_FutarId",
                table: "Rendelesek",
                column: "FutarId",
                principalTable: "Futarok",
                principalColumn: "FutarId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rendelesek_Cimek_CimId",
                table: "Rendelesek");

            migrationBuilder.DropForeignKey(
                name: "FK_Rendelesek_Futarok_FutarId",
                table: "Rendelesek");

            migrationBuilder.AlterColumn<int>(
                name: "FutarId",
                table: "Rendelesek",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CimId",
                table: "Rendelesek",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rendelesek_Cimek_CimId",
                table: "Rendelesek",
                column: "CimId",
                principalTable: "Cimek",
                principalColumn: "CimId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rendelesek_Futarok_FutarId",
                table: "Rendelesek",
                column: "FutarId",
                principalTable: "Futarok",
                principalColumn: "FutarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
