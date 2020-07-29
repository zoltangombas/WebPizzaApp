using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPizzaApp.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allapotok",
                columns: table => new
                {
                    AllapotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Megnevezes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allapotok", x => x.AllapotId);
                });

            migrationBuilder.CreateTable(
                name: "Futarok",
                columns: table => new
                {
                    FutarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nev = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Futarok", x => x.FutarId);
                });

            migrationBuilder.CreateTable(
                name: "Megrendelok",
                columns: table => new
                {
                    MegrendeloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nev = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Megrendelok", x => x.MegrendeloId);
                });

            migrationBuilder.CreateTable(
                name: "Pizzak",
                columns: table => new
                {
                    PizzaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nev = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzak", x => x.PizzaId);
                });

            migrationBuilder.CreateTable(
                name: "Cimek",
                columns: table => new
                {
                    CimId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Irsz = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Varos = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Utca = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Hazszam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Csengo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MegrendeloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cimek", x => x.CimId);
                    table.ForeignKey(
                        name: "FK_Cimek_Megrendelok_MegrendeloId",
                        column: x => x.MegrendeloId,
                        principalTable: "Megrendelok",
                        principalColumn: "MegrendeloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rendelesek",
                columns: table => new
                {
                    RendelesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllapotId = table.Column<int>(nullable: false),
                    FutarId = table.Column<int>(nullable: false),
                    CimId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rendelesek", x => x.RendelesId);
                    table.ForeignKey(
                        name: "FK_Rendelesek_Allapotok_AllapotId",
                        column: x => x.AllapotId,
                        principalTable: "Allapotok",
                        principalColumn: "AllapotId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rendelesek_Cimek_CimId",
                        column: x => x.CimId,
                        principalTable: "Cimek",
                        principalColumn: "CimId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rendelesek_Futarok_FutarId",
                        column: x => x.FutarId,
                        principalTable: "Futarok",
                        principalColumn: "FutarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaRendelesek",
                columns: table => new
                {
                    PizzaId = table.Column<int>(nullable: false),
                    RendelesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaRendelesek", x => new { x.RendelesId, x.PizzaId });
                    table.ForeignKey(
                        name: "FK_PizzaRendelesek_Pizzak_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzak",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaRendelesek_Rendelesek_RendelesId",
                        column: x => x.RendelesId,
                        principalTable: "Rendelesek",
                        principalColumn: "RendelesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cimek_MegrendeloId",
                table: "Cimek",
                column: "MegrendeloId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaRendelesek_PizzaId",
                table: "PizzaRendelesek",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rendelesek_AllapotId",
                table: "Rendelesek",
                column: "AllapotId");

            migrationBuilder.CreateIndex(
                name: "IX_Rendelesek_CimId",
                table: "Rendelesek",
                column: "CimId");

            migrationBuilder.CreateIndex(
                name: "IX_Rendelesek_FutarId",
                table: "Rendelesek",
                column: "FutarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaRendelesek");

            migrationBuilder.DropTable(
                name: "Pizzak");

            migrationBuilder.DropTable(
                name: "Rendelesek");

            migrationBuilder.DropTable(
                name: "Allapotok");

            migrationBuilder.DropTable(
                name: "Cimek");

            migrationBuilder.DropTable(
                name: "Futarok");

            migrationBuilder.DropTable(
                name: "Megrendelok");
        }
    }
}
