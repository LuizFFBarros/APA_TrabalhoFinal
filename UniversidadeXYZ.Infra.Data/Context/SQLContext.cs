using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseInMemoryDatabase(databaseName: "UniversidadeXYZ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>(new AlunoMap().Configure);
            modelBuilder.Entity<Disciplina>(new DisciplinaMap().Configure);
            modelBuilder.Entity<DisciplinaTurma>(new DisciplinaTurmaMap().Configure);
            modelBuilder.Entity<Matricula>(new MatriculaMap().Configure);
            modelBuilder.Entity<Turma>(new TurmaMap().Configure);
        } 
    }
}
