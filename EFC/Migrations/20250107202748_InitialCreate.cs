using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrinksMenus",
                columns: table => new
                {
                    DrinksMenuId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ContainsAlcohol = table.Column<bool>(type: "INTEGER", nullable: false),
                    AvailableFrom = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinksMenus", x => x.DrinksMenuId);
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    DrinkId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    AlcoholPercentage = table.Column<decimal>(type: "TEXT", nullable: false),
                    IncludesUmbrella = table.Column<bool>(type: "INTEGER", nullable: false),
                    DrinksMenuId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.DrinkId);
                    table.ForeignKey(
                        name: "FK_Drinks_DrinksMenus_DrinksMenuId",
                        column: x => x.DrinksMenuId,
                        principalTable: "DrinksMenus",
                        principalColumn: "DrinksMenuId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_DrinksMenuId",
                table: "Drinks",
                column: "DrinksMenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "DrinksMenus");
        }
    }
}
