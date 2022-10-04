using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareUS1_1.Migrations
{
    public partial class ThirdCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Clientes_GuidCliente1",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_experiencias_Clientes_GuidCliente1",
                table: "experiencias");

            migrationBuilder.AlterColumn<string>(
                name: "nomePaciente",
                table: "Pacientes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataDeNascimentoPaciente",
                table: "Pacientes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "descricaoExperiencia",
                table: "experiencias",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<Guid>(
                name: "GuidCliente1",
                table: "experiencias",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataNascimentoCliente",
                table: "Clientes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "GuidCliente1",
                table: "Avaliacoes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Avaliacoes",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Clientes_GuidCliente1",
                table: "Avaliacoes",
                column: "GuidCliente1",
                principalTable: "Clientes",
                principalColumn: "GuidCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_experiencias_Clientes_GuidCliente1",
                table: "experiencias",
                column: "GuidCliente1",
                principalTable: "Clientes",
                principalColumn: "GuidCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Clientes_GuidCliente1",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_experiencias_Clientes_GuidCliente1",
                table: "experiencias");

            migrationBuilder.AlterColumn<string>(
                name: "nomePaciente",
                table: "Pacientes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataDeNascimentoPaciente",
                table: "Pacientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descricaoExperiencia",
                table: "experiencias",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GuidCliente1",
                table: "experiencias",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataNascimentoCliente",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GuidCliente1",
                table: "Avaliacoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Avaliacoes",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Clientes_GuidCliente1",
                table: "Avaliacoes",
                column: "GuidCliente1",
                principalTable: "Clientes",
                principalColumn: "GuidCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_experiencias_Clientes_GuidCliente1",
                table: "experiencias",
                column: "GuidCliente1",
                principalTable: "Clientes",
                principalColumn: "GuidCliente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
