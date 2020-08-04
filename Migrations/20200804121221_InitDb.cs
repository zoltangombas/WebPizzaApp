using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPizzaApp.Migrations
{
    public partial class InitDb : Migration
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
                    Nev = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                    Nev = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                    Nev = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                    Irsz = table.Column<string>(type: "nvarchar(10)", maxLength: 4, nullable: false),
                    Varos = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Utca = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Hazszam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Csengo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MegrendeloId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cimek", x => x.CimId);
                    table.ForeignKey(
                        name: "FK_Cimek_Megrendelok_MegrendeloId",
                        column: x => x.MegrendeloId,
                        principalTable: "Megrendelok",
                        principalColumn: "MegrendeloId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rendelesek",
                columns: table => new
                {
                    RendelesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllapotId = table.Column<int>(nullable: false),
                    CimId = table.Column<int>(nullable: true),
                    FutarId = table.Column<int>(nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rendelesek_Futarok_FutarId",
                        column: x => x.FutarId,
                        principalTable: "Futarok",
                        principalColumn: "FutarId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PizzaRendelesek",
                columns: table => new
                {
                    PizzaRendelesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RendelesId = table.Column<int>(nullable: false),
                    PizzaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaRendelesek", x => x.PizzaRendelesId);
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

            migrationBuilder.InsertData(
                table: "Allapotok",
                columns: new[] { "AllapotId", "Megnevezes" },
                values: new object[,]
                {
                    { 1, "Készítés alatt" },
                    { 2, "Kiszállítás alatt" },
                    { 3, "Kiszállítva" }
                });

            migrationBuilder.InsertData(
                table: "Futarok",
                columns: new[] { "FutarId", "Nev" },
                values: new object[,]
                {
                    { 1, "Villám Vili" },
                    { 2, "Lajhár Laci" },
                    { 3, "Gyors Gyuri" }
                });

            migrationBuilder.InsertData(
                table: "Megrendelok",
                columns: new[] { "MegrendeloId", "Nev" },
                values: new object[,]
                {
                    { 5, "Vékony Vilma" },
                    { 3, "Hasas Hedvig" },
                    { 4, "Vega Viktor" },
                    { 1, "Éhes Elemér" },
                    { 2, "Éhes Eszter" }
                });

            migrationBuilder.InsertData(
                table: "Pizzak",
                columns: new[] { "PizzaId", "Nev" },
                values: new object[,]
                {
                    { 8, "Gombás" },
                    { 1, "Magyaros" },
                    { 2, "Húsos" },
                    { 3, "Szalámis" },
                    { 4, "Sajtos" },
                    { 5, "Mexikói" },
                    { 6, "Spenótos" },
                    { 7, "Sonkás" },
                    { 9, "Vega" }
                });

            migrationBuilder.InsertData(
                table: "Cimek",
                columns: new[] { "CimId", "Csengo", "Hazszam", "Irsz", "MegrendeloId", "Utca", "Varos" },
                values: new object[,]
                {
                    { 1, "20", "110", "1111", 1, "Fehérvári út.", "Budapest" },
                    { 2, "20", "110", "1111", 2, "Fehérvári út.", "Budapest" },
                    { 3, "3", "23", "2222", 3, "Dózsa György út.", "Budapest" },
                    { 4, "5", "45", "3333", 3, "István út.", "Budapest" },
                    { 5, "11", "70", "4444", 4, "Attila út.", "Budapest" },
                    { 6, "10", "12", "5555", 5, "Erzsébet út.", "Budapest" },
                    { 7, "7", "24", "6666", 5, "Mária út.", "Budapest" },
                    { 8, "2", "2", "7777", 5, "László út.", "Budapest" }
                });

            migrationBuilder.InsertData(
                table: "Rendelesek",
                columns: new[] { "RendelesId", "AllapotId", "CimId", "FutarId" },
                values: new object[,]
                {
                    { 14, 2, 1, 3 },
                    { 16, 1, 7, null },
                    { 6, 3, 6, 3 },
                    { 18, 1, 5, null },
                    { 10, 2, 5, 2 },
                    { 3, 3, 5, 2 },
                    { 13, 2, 4, 1 },
                    { 11, 2, 4, 2 },
                    { 15, 2, 3, 2 },
                    { 8, 2, 3, 1 },
                    { 1, 3, 3, 1 },
                    { 12, 2, 2, 1 },
                    { 9, 3, 2, 1 },
                    { 5, 3, 2, 3 },
                    { 4, 3, 2, 3 },
                    { 2, 3, 2, 1 },
                    { 17, 1, 7, null },
                    { 7, 2, 8, 2 }
                });

            migrationBuilder.InsertData(
                table: "PizzaRendelesek",
                columns: new[] { "PizzaRendelesId", "PizzaId", "RendelesId" },
                values: new object[,]
                {
                    { 26, 9, 14 },
                    { 31, 2, 17 },
                    { 30, 4, 17 },
                    { 29, 1, 16 },
                    { 10, 2, 6 },
                    { 34, 7, 18 },
                    { 33, 3, 18 },
                    { 17, 2, 10 },
                    { 4, 2, 3 },
                    { 3, 9, 3 },
                    { 25, 2, 13 },
                    { 24, 2, 13 },
                    { 23, 4, 13 },
                    { 22, 3, 13 },
                    { 18, 2, 11 },
                    { 28, 8, 15 },
                    { 13, 4, 8 },
                    { 12, 1, 8 },
                    { 27, 3, 14 },
                    { 2, 4, 2 },
                    { 5, 5, 4 },
                    { 6, 3, 5 },
                    { 7, 3, 5 },
                    { 8, 9, 5 },
                    { 32, 6, 17 },
                    { 9, 5, 5 },
                    { 15, 8, 9 },
                    { 16, 6, 9 },
                    { 19, 1, 12 },
                    { 20, 5, 12 },
                    { 21, 7, 12 },
                    { 1, 1, 1 },
                    { 14, 7, 9 },
                    { 11, 1, 7 }
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
                name: "IX_PizzaRendelesek_RendelesId",
                table: "PizzaRendelesek",
                column: "RendelesId");

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
