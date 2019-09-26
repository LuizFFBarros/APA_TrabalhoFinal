using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversidadeXYZ.Infra.Data.Migrations
{
    public partial class SeedMatricula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Matricula");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "DisciplinaTurma");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Disciplina");

            migrationBuilder.InsertData(
                table: "Matricula",
                columns: new[] { "CodigoMatricula", "CodigoAluno", "CodigoDaTurma", "CodigoDisciplina", "CodigoSituacao", "DataMatricula" },
                values: new object[] { 2, 2, 2, 2, 1, new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Matricula",
                columns: new[] { "CodigoMatricula", "CodigoAluno", "CodigoDaTurma", "CodigoDisciplina", "CodigoSituacao", "DataMatricula" },
                values: new object[] { 3, 3, 2, 1, 1, new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Matricula",
                columns: new[] { "CodigoMatricula", "CodigoAluno", "CodigoDaTurma", "CodigoDisciplina", "CodigoSituacao", "DataMatricula" },
                values: new object[] { 7, 3, 3, 3, 1, new DateTime(2019, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Matricula",
                keyColumn: "CodigoMatricula",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Matricula",
                keyColumn: "CodigoMatricula",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Matricula",
                keyColumn: "CodigoMatricula",
                keyValue: 7);

            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "Matricula",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "DisciplinaTurma",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "Disciplina",
                nullable: false,
                defaultValue: 0);
        }
    }
}
