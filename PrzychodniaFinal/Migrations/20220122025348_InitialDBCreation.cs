using Microsoft.EntityFrameworkCore.Migrations;

namespace PrzychodniaFinal.Migrations
{
    public partial class InitialDBCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lekarzes",
                columns: table => new
                {
                    LekarzeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specjalizacja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumerGabinetu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lekarzes", x => x.LekarzeID);
                });

            migrationBuilder.CreateTable(
                name: "Pacjencis",
                columns: table => new
                {
                    PacjenciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    AdresZamieszkania = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacjencis", x => x.PacjenciID);
                });

            migrationBuilder.CreateTable(
                name: "Pracownicies",
                columns: table => new
                {
                    PracownicyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pesel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresZamieszkania = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataZatrudnienia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KoniecKontraktu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LekarzeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicies", x => x.PracownicyID);
                    table.ForeignKey(
                        name: "FK_Pracownicies_Lekarzes_LekarzeID",
                        column: x => x.LekarzeID,
                        principalTable: "Lekarzes",
                        principalColumn: "LekarzeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recepties",
                columns: table => new
                {
                    IdChoroby = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRecepty = table.Column<int>(type: "int", nullable: false),
                    Lek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataWystawienia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacjenciID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepties", x => x.IdChoroby);
                    table.ForeignKey(
                        name: "FK_Recepties_Pacjencis_PacjenciID",
                        column: x => x.PacjenciID,
                        principalTable: "Pacjencis",
                        principalColumn: "PacjenciID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chorobies",
                columns: table => new
                {
                    ChorobyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacjenciID = table.Column<int>(type: "int", nullable: false),
                    PracownicyID = table.Column<int>(type: "int", nullable: false),
                    IdPacjenta = table.Column<int>(type: "int", nullable: false),
                    PrzebiegChoroby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdChoroby = table.Column<int>(type: "int", nullable: true),
                    IdPracownikaNavigationLekarzeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chorobies", x => x.ChorobyID);
                    table.ForeignKey(
                        name: "FK_Chorobies_Lekarzes_IdPracownikaNavigationLekarzeID",
                        column: x => x.IdPracownikaNavigationLekarzeID,
                        principalTable: "Lekarzes",
                        principalColumn: "LekarzeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chorobies_Pacjencis_PacjenciID",
                        column: x => x.PacjenciID,
                        principalTable: "Pacjencis",
                        principalColumn: "PacjenciID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chorobies_Recepties_IdChoroby",
                        column: x => x.IdChoroby,
                        principalTable: "Recepties",
                        principalColumn: "IdChoroby",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chorobies_IdChoroby",
                table: "Chorobies",
                column: "IdChoroby");

            migrationBuilder.CreateIndex(
                name: "IX_Chorobies_IdPracownikaNavigationLekarzeID",
                table: "Chorobies",
                column: "IdPracownikaNavigationLekarzeID");

            migrationBuilder.CreateIndex(
                name: "IX_Chorobies_PacjenciID",
                table: "Chorobies",
                column: "PacjenciID");

            migrationBuilder.CreateIndex(
                name: "IX_Pracownicies_LekarzeID",
                table: "Pracownicies",
                column: "LekarzeID");

            migrationBuilder.CreateIndex(
                name: "IX_Recepties_PacjenciID",
                table: "Recepties",
                column: "PacjenciID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chorobies");

            migrationBuilder.DropTable(
                name: "Pracownicies");

            migrationBuilder.DropTable(
                name: "Recepties");

            migrationBuilder.DropTable(
                name: "Lekarzes");

            migrationBuilder.DropTable(
                name: "Pacjencis");
        }
    }
}
