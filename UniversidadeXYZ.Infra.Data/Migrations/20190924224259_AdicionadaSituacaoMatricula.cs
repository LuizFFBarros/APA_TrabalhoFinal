using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversidadeXYZ.Infra.Data.Migrations
{
    public partial class AdicionadaSituacaoMatricula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "Matricula",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CodigoSituacao",
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

            migrationBuilder.UpdateData(
                table: "Matricula",
                keyColumn: "CodigoMatricula",
                keyValue: 1,
                column: "CodigoSituacao",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Matricula");

            migrationBuilder.DropColumn(
                name: "CodigoSituacao",
                table: "Matricula");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "DisciplinaTurma");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Disciplina");
        }
    }
}
