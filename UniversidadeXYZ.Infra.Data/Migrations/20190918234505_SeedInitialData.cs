using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversidadeXYZ.Infra.Data.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Aluno",
                columns: new[] { "CPF", "Codigo", "Logradouro", "Nome", "Telefone" },
                values: new object[] { 1238723L, 0, "Rua A", "Carina", 2323 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Aluno",
                keyColumn: "CPF",
                keyValue: 1238723L);
        }
    }
}
