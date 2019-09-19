using Microsoft.EntityFrameworkCore;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Infra.Data.Mapping;

namespace UniversidadeXYZ.Infra.Data.Context
{
    public class SQLContext : DbContext
    {
        public DbSet<Disciplina> Disciplina { set; get; }
        public DbSet<DisciplinaTurma> DisciplinaTurma { set; get; }
        public DbSet<Matricula> Matricula { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=UniversidadeXYZ;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Disciplina>(new DisciplinaMap().Configure);
            modelBuilder.Entity<DisciplinaTurma>(new DisciplinaTurmaMap().Configure);
            modelBuilder.Entity<Matricula>(new MatriculaMap().Configure);

        } 
    }
}
