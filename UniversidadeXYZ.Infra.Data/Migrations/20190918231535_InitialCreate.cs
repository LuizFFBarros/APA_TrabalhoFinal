using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversidadeXYZ.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    CPF = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Telefone = table.Column<int>(nullable: false),
                    Logradouro = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.CPF);
                });

            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    CodigoDisciplina = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    CargaHoraria = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.CodigoDisciplina);
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

            migrationBuilder.CreateTable(
                name: "DisciplinaTurma",
                columns: table => new
                {
                    CodigoDisciplina = table.Column<int>(nullable: false),
                    CodigoDaTurma = table.Column<int>(nullable: false),
                    QuantidadeVagas = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaTurma", x => new { x.CodigoDisciplina, x.CodigoDaTurma });
                    table.ForeignKey(
                        name: "FK_DisciplinaTurma_Turma_CodigoDaTurma",
                        column: x => x.CodigoDaTurma,
                        principalTable: "Turma",
                        principalColumn: "CodigoDaTurma",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinaTurma_Disciplina_CodigoDisciplina",
                        column: x => x.CodigoDisciplina,
                        principalTable: "Disciplina",
                        principalColumn: "CodigoDisciplina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    CodigoMatricula = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataMatricula = table.Column<DateTime>(nullable: false),
                    AlunoCPF = table.Column<long>(nullable: true),
                    DisciplinaTurmaCodigoDisciplina = table.Column<int>(nullable: true),
                    DisciplinaTurmaCodigoDaTurma = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula", x => x.CodigoMatricula);
                    table.ForeignKey(
                        name: "FK_Matricula_Aluno_AlunoCPF",
                        column: x => x.AlunoCPF,
                        principalTable: "Aluno",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matricula_DisciplinaTurma_DisciplinaTurmaCodigoDisciplina_DisciplinaTurmaCodigoDaTurma",
                        columns: x => new { x.DisciplinaTurmaCodigoDisciplina, x.DisciplinaTurmaCodigoDaTurma },
                        principalTable: "DisciplinaTurma",
                        principalColumns: new[] { "CodigoDisciplina", "CodigoDaTurma" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaTurma_CodigoDaTurma",
                table: "DisciplinaTurma",
                column: "CodigoDaTurma");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_AlunoCPF",
                table: "Matricula",
                column: "AlunoCPF");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_DisciplinaTurmaCodigoDisciplina_DisciplinaTurmaCodigoDaTurma",
                table: "Matricula",
                columns: new[] { "DisciplinaTurmaCodigoDisciplina", "DisciplinaTurmaCodigoDaTurma" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matricula");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "DisciplinaTurma");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Disciplina");
        }
    }
}
