using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPizzaApp.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Allapotok (Megnevezes) VALUES ('Készítés alatt')");
            migrationBuilder.Sql("INSERT INTO Allapotok (Megnevezes) VALUES ('Kiszállítás alatt')");
            migrationBuilder.Sql("INSERT INTO Allapotok (Megnevezes) VALUES ('Kiszállítva')");

            migrationBuilder.Sql("INSERT INTO Pizzak VALUES ('Magyaros')");
            migrationBuilder.Sql("INSERT INTO Pizzak VALUES ('Sajtos')");
            migrationBuilder.Sql("INSERT INTO Pizzak VALUES ('Sonkás')");
            migrationBuilder.Sql("INSERT INTO Pizzak VALUES ('Spenótos')");

            migrationBuilder.Sql("INSERT INTO Futarok VALUES ('Villám Vili')");
            migrationBuilder.Sql("INSERT INTO Futarok VALUES ('Lajhár Laci')");

            migrationBuilder.Sql("INSERT INTO Megrendelok VALUES ('Éhes Elemér')");
            migrationBuilder.Sql("INSERT INTO Megrendelok VALUES ('Éhes Eszter')");
            migrationBuilder.Sql("INSERT INTO Megrendelok VALUES ('Hasas Hedvig')");
            migrationBuilder.Sql("INSERT INTO Megrendelok VALUES ('Vega Viktor')");

            migrationBuilder.Sql("INSERT INTO Cimek VALUES ('1111' , 'Budapest' , 'Fehérvári út.' , '110' , '20', 1)");
            migrationBuilder.Sql("INSERT INTO Cimek VALUES ('1111' , 'Budapest' , 'Fehérvári út.' , '110' , '20', 2)");
            migrationBuilder.Sql("INSERT INTO Cimek VALUES ('2222' , 'Budapest' , 'Dózsa György út.' , '24' , '3', 3)");
            migrationBuilder.Sql("INSERT INTO Cimek VALUES ('3333' , 'Budapest' , 'István út.' , '110' , '3' , 3)");

            migrationBuilder.Sql("INSERT INTO Rendelesek  VALUES (1,1,1)");
            migrationBuilder.Sql("INSERT INTO Rendelesek  VALUES (1,1,1)");

            migrationBuilder.Sql("INSERT INTO PizzaRendelesek  VALUES (1,1)");
            migrationBuilder.Sql("INSERT INTO PizzaRendelesek  VALUES (2,2)");
            migrationBuilder.Sql("INSERT INTO PizzaRendelesek  VALUES (4,2)");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Allapotok");
            migrationBuilder.Sql("DELETE FROM Pizzak");
            migrationBuilder.Sql("DELETE FROM Futarok");
            migrationBuilder.Sql("DELETE FROM Megrendelok");
            migrationBuilder.Sql("DELETE FROM Cimek");
            migrationBuilder.Sql("DELETE FROM PizzaRendelesek");
            migrationBuilder.Sql("DELETE FROM Rendelesek");
        }
    }
}
