using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversidadeXYZ.Infra.Data.Migrations
{
    public partial class AlteracaoTipoDadoTelefoneAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Telefone",
                table: "Aluno",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Aluno",
                keyColumn: "CPF",
                keyValue: 1238723L,
                column: "Telefone",
                value: 2323L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Telefone",
                table: "Aluno",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.UpdateData(
                table: "Aluno",
                keyColumn: "CPF",
                keyValue: 1238723L,
                column: "Telefone",
                value: 2323);
        }
    }
}
