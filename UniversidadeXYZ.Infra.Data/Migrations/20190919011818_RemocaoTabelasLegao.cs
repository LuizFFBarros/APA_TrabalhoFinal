using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversidadeXYZ.Infra.Data.Migrations
{
    public partial class RemocaoTabelasLegao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplinaTurma_Turma_CodigoDaTurma",
                table: "DisciplinaTurma");

            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Aluno_AlunoCPF",
                table: "Matricula");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropIndex(
                name: "IX_Matricula_AlunoCPF",
                table: "Matricula");

            migrationBuilder.DropIndex(
                name: "IX_DisciplinaTurma_CodigoDaTurma",
                table: "DisciplinaTurma");

            migrationBuilder.DropColumn(
                name: "AlunoCPF",
                table: "Matricula");

            migrationBuilder.AddColumn<int>(
                name: "CodigoAluno",
                table: "Matricula",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoAluno",
                table: "Matricula");

            migrationBuilder.AddColumn<long>(
                name: "AlunoCPF",
                table: "Matricula",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    CPF = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<int>(nullable: false),
                    Logradouro = table.Column<string>(maxLength: 200, nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    Telefone = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.CPF);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    CodigoDaTurma = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataInicio = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.CodigoDaTurma);
                });

            migrationBuilder.InsertData(
                table: "Aluno",
                columns: new[] { "CPF", "Codigo", "Logradouro", "Nome", "Telefone" },
                values: new object[] { 1238723L, 0, "Rua A", "Carina", 2323L });

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_AlunoCPF",
                table: "Matricula",
                column: "AlunoCPF");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaTurma_CodigoDaTurma",
                table: "DisciplinaTurma",
                column: "CodigoDaTurma");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinaTurma_Turma_CodigoDaTurma",
                table: "DisciplinaTurma",
                column: "CodigoDaTurma",
                principalTable: "Turma",
                principalColumn: "CodigoDaTurma",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Aluno_AlunoCPF",
                table: "Matricula",
                column: "AlunoCPF",
                principalTable: "Aluno",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
