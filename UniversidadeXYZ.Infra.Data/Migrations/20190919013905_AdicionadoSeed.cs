using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversidadeXYZ.Infra.Data.Migrations
{
    public partial class AdicionadoSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_DisciplinaTurma_DisciplinaTurmaCodigoDisciplina_DisciplinaTurmaCodigoDaTurma",
                table: "Matricula");

            migrationBuilder.DropIndex(
                name: "IX_Matricula_DisciplinaTurmaCodigoDisciplina_DisciplinaTurmaCodigoDaTurma",
                table: "Matricula");

            migrationBuilder.DropColumn(
                name: "DisciplinaTurmaCodigoDaTurma",
                table: "Matricula");

            migrationBuilder.DropColumn(
                name: "DisciplinaTurmaCodigoDisciplina",
                table: "Matricula");

            migrationBuilder.AddColumn<int>(
                name: "CodigoDaTurma",
                table: "Matricula",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CodigoDisciplina",
                table: "Matricula",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Disciplina",
                columns: new[] { "CodigoDisciplina", "CargaHoraria", "Nome" },
                values: new object[,]
                {
                    { 1, 32, "Arquitetura e Desenho de APIs" },
                    { 2, 24, "Análise, Projeto e Avaliação de Arquiteturas" },
                    { 3, 16, "Arquitetura JEE" },
                    { 4, 40, "Arquitetura de Backend e Microsserviços" }
                });

            migrationBuilder.InsertData(
                table: "DisciplinaTurma",
                columns: new[] { "CodigoDisciplina", "CodigoDaTurma", "QuantidadeVagas" },
                values: new object[,]
                {
                    { 1, 1, 10m },
                    { 1, 2, 15m },
                    { 2, 2, 20m },
                    { 3, 3, 20m }
                });

            migrationBuilder.InsertData(
                table: "Matricula",
                columns: new[] { "CodigoMatricula", "CodigoAluno", "CodigoDaTurma", "CodigoDisciplina", "DataMatricula" },
                values: new object[] { 1, 1, 1, 1, new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_CodigoDisciplina_CodigoDaTurma",
                table: "Matricula",
                columns: new[] { "CodigoDisciplina", "CodigoDaTurma" });

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_DisciplinaTurma_CodigoDisciplina_CodigoDaTurma",
                table: "Matricula",
                columns: new[] { "CodigoDisciplina", "CodigoDaTurma" },
                principalTable: "DisciplinaTurma",
                principalColumns: new[] { "CodigoDisciplina", "CodigoDaTurma" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_DisciplinaTurma_CodigoDisciplina_CodigoDaTurma",
                table: "Matricula");

            migrationBuilder.DropIndex(
                name: "IX_Matricula_CodigoDisciplina_CodigoDaTurma",
                table: "Matricula");

            migrationBuilder.DeleteData(
                table: "Disciplina",
                keyColumn: "CodigoDisciplina",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DisciplinaTurma",
                keyColumns: new[] { "CodigoDisciplina", "CodigoDaTurma" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DisciplinaTurma",
                keyColumns: new[] { "CodigoDisciplina", "CodigoDaTurma" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "DisciplinaTurma",
                keyColumns: new[] { "CodigoDisciplina", "CodigoDaTurma" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Matricula",
                keyColumn: "CodigoMatricula",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Disciplina",
                keyColumn: "CodigoDisciplina",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Disciplina",
                keyColumn: "CodigoDisciplina",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DisciplinaTurma",
                keyColumns: new[] { "CodigoDisciplina", "CodigoDaTurma" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Disciplina",
                keyColumn: "CodigoDisciplina",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CodigoDaTurma",
                table: "Matricula");

            migrationBuilder.DropColumn(
                name: "CodigoDisciplina",
                table: "Matricula");

            migrationBuilder.AddColumn<int>(
                name: "DisciplinaTurmaCodigoDaTurma",
                table: "Matricula",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisciplinaTurmaCodigoDisciplina",
                table: "Matricula",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_DisciplinaTurmaCodigoDisciplina_DisciplinaTurmaCodigoDaTurma",
                table: "Matricula",
                columns: new[] { "DisciplinaTurmaCodigoDisciplina", "DisciplinaTurmaCodigoDaTurma" });

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_DisciplinaTurma_DisciplinaTurmaCodigoDisciplina_DisciplinaTurmaCodigoDaTurma",
                table: "Matricula",
                columns: new[] { "DisciplinaTurmaCodigoDisciplina", "DisciplinaTurmaCodigoDaTurma" },
                principalTable: "DisciplinaTurma",
                principalColumns: new[] { "CodigoDisciplina", "CodigoDaTurma" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
