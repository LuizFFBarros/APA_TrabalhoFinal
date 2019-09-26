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
            optionsBuilder.UseLazyLoadingProxies()
                          .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=UniversidadeXYZ;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Disciplina>(new DisciplinaMap().Configure);
            modelBuilder.Entity<DisciplinaTurma>(new DisciplinaTurmaMap().Configure);
            modelBuilder.Entity<Matricula>(new MatriculaMap().Configure);

            modelBuilder.Entity<Disciplina>().HasData(new Disciplina { CodigoDisciplina = 1, Nome = "Arquitetura e Desenho de APIs", CargaHoraria = 32 });
            modelBuilder.Entity<Disciplina>().HasData(new Disciplina { CodigoDisciplina = 2, Nome = "Análise, Projeto e Avaliação de Arquiteturas", CargaHoraria = 24 });
            modelBuilder.Entity<Disciplina>().HasData(new Disciplina { CodigoDisciplina = 3, Nome = "Arquitetura JEE", CargaHoraria =  16});
            modelBuilder.Entity<Disciplina>().HasData(new Disciplina { CodigoDisciplina = 4, Nome = "Arquitetura de Backend e Microsserviços", CargaHoraria = 40 });

            modelBuilder.Entity<DisciplinaTurma>().HasData(new DisciplinaTurma { CodigoDisciplina = 1, CodigoDaTurma = 1, QuantidadeVagas = 10 });
            modelBuilder.Entity<DisciplinaTurma>().HasData(new DisciplinaTurma { CodigoDisciplina = 1, CodigoDaTurma = 2, QuantidadeVagas = 15 });
            modelBuilder.Entity<DisciplinaTurma>().HasData(new DisciplinaTurma { CodigoDisciplina = 2, CodigoDaTurma = 2, QuantidadeVagas = 20 });
            modelBuilder.Entity<DisciplinaTurma>().HasData(new DisciplinaTurma { CodigoDisciplina = 3, CodigoDaTurma = 3, QuantidadeVagas = 20 });

            modelBuilder.Entity<Matricula>().HasData(new Matricula { CodigoMatricula = 1, CodigoAluno = 1, DataMatricula = new System.DateTime(2019, 09, 19), CodigoDaTurma = 1, CodigoDisciplina = 1, CodigoSituacao = 1 });
            modelBuilder.Entity<Matricula>().HasData(new Matricula { CodigoMatricula = 2, CodigoAluno = 2, DataMatricula = new System.DateTime(2019, 09, 19), CodigoDaTurma = 2, CodigoDisciplina = 2, CodigoSituacao = 1 });
            modelBuilder.Entity<Matricula>().HasData(new Matricula { CodigoMatricula = 3, CodigoAluno = 3, DataMatricula = new System.DateTime(2019, 09, 25), CodigoDaTurma = 2, CodigoDisciplina = 1, CodigoSituacao = 1 });
            modelBuilder.Entity<Matricula>().HasData(new Matricula { CodigoMatricula = 7, CodigoAluno = 3, DataMatricula = new System.DateTime(2019, 08, 17), CodigoDaTurma = 3, CodigoDisciplina = 3, CodigoSituacao = 1 });
        }
    }
}
