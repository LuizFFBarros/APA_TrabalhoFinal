using Microsoft.EntityFrameworkCore;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Infra.Data.Mapping;

namespace UniversidadeXYZ.Infra.Data.Context
{
    public class SQLContext : DbContext
    {
        public DbSet<Aluno> Aluno { set; get; }
        public DbSet<Disciplina> Disciplina { set; get; }
        public DbSet<DisciplinaTurma> DisciplinaTurma { set; get; }
        public DbSet<Matricula> Matricula { set; get; }
        public DbSet<Turma> Turma { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=UniversidadeXYZ;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>(new AlunoMap().Configure);
            modelBuilder.Entity<Disciplina>(new DisciplinaMap().Configure);
            modelBuilder.Entity<DisciplinaTurma>(new DisciplinaTurmaMap().Configure);
            modelBuilder.Entity<Matricula>(new MatriculaMap().Configure);
            modelBuilder.Entity<Turma>(new TurmaMap().Configure);

            modelBuilder.Entity<Aluno>().HasData(new Aluno { CPF = 1238723, Nome = "Carina", Logradouro = "Rua A", Telefone = 2323 });
        } 
    }
}
