using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PassWord = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PizzeriaIngredient",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IngredientId = table.Column<Guid>(nullable: true),
                    PizzeriaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzeriaIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzeriaIngredient_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pizzeria",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PizzeriaIngredientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzeria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizzeria_PizzeriaIngredient_PizzeriaIngredientId",
                        column: x => x.PizzeriaIngredientId,
                        principalTable: "PizzeriaIngredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    PizzeriaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Pizzeria_PizzeriaId",
                        column: x => x.PizzeriaId,
                        principalTable: "Pizzeria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_PizzeriaId",
                table: "Image",
                column: "PizzeriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzeria_PizzeriaIngredientId",
                table: "Pizzeria",
                column: "PizzeriaIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzeriaIngredient_IngredientId",
                table: "PizzeriaIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzeriaIngredient_PizzeriaId",
                table: "PizzeriaIngredient",
                column: "PizzeriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzeriaIngredient_Pizzeria_PizzeriaId",
                table: "PizzeriaIngredient",
                column: "PizzeriaId",
                principalTable: "Pizzeria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzeriaIngredient_Pizzeria_PizzeriaId",
                table: "PizzeriaIngredient");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Pizzeria");

            migrationBuilder.DropTable(
                name: "PizzeriaIngredient");

            migrationBuilder.DropTable(
                name: "Ingredient");
        }
    }
}
