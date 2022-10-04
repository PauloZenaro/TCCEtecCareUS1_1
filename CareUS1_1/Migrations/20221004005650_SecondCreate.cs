using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareUS1_1.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    GuidAvaliacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fkGuidCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuidCliente1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nota = table.Column<double>(type: "float", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.GuidAvaliacao);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Clientes_GuidCliente1",
                        column: x => x.GuidCliente1,
                        principalTable: "Clientes",
                        principalColumn: "GuidCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_GuidCliente1",
                table: "Avaliacoes",
                column: "GuidCliente1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacoes");
        }
    }
}
