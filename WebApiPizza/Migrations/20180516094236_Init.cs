using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApiPizza.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    IdCategory = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.IdCategory);
                });

            migrationBuilder.CreateTable(
                name: "pizza",
                columns: table => new
                {
                    IdPizza = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Available = table.Column<bool>(nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    IdCategory = table.Column<short>(nullable: false),
                    ImagePath = table.Column<string>(unicode: false, maxLength: 300, nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    Title = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizza", x => x.IdPizza);
                    table.ForeignKey(
                        name: "FK_pizza_category",
                        column: x => x.IdCategory,
                        principalTable: "category",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pizza_IdCategory",
                table: "pizza",
                column: "IdCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pizza");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
