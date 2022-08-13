using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace planete_biblio.Migrations
{
    public partial class troisieme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livre",
                columns: table => new
                {
                    Numero_identite = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Langue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_edition = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prix_achat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livre", x => x.Numero_identite);
                });

            migrationBuilder.CreateTable(
                name: "Auteur",
                columns: table => new
                {
                    AuteurId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_naissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_deces = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LivreNumero_identite = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteur", x => x.AuteurId);
                    table.ForeignKey(
                        name: "FK_Auteur_Livre_LivreNumero_identite",
                        column: x => x.LivreNumero_identite,
                        principalTable: "Livre",
                        principalColumn: "Numero_identite");
                });

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    CategorieId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LivreNumero_identite = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.CategorieId);
                    table.ForeignKey(
                        name: "FK_Categorie_Livre_LivreNumero_identite",
                        column: x => x.LivreNumero_identite,
                        principalTable: "Livre",
                        principalColumn: "Numero_identite");
                });

            migrationBuilder.CreateTable(
                name: "Editeur",
                columns: table => new
                {
                    EditeurId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_naissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_dece = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LivreNumero_identite = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editeur", x => x.EditeurId);
                    table.ForeignKey(
                        name: "FK_Editeur_Livre_LivreNumero_identite",
                        column: x => x.LivreNumero_identite,
                        principalTable: "Livre",
                        principalColumn: "Numero_identite");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auteur_LivreNumero_identite",
                table: "Auteur",
                column: "LivreNumero_identite");

            migrationBuilder.CreateIndex(
                name: "IX_Categorie_LivreNumero_identite",
                table: "Categorie",
                column: "LivreNumero_identite");

            migrationBuilder.CreateIndex(
                name: "IX_Editeur_LivreNumero_identite",
                table: "Editeur",
                column: "LivreNumero_identite");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auteur");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Editeur");

            migrationBuilder.DropTable(
                name: "Livre");
        }
    }
}
