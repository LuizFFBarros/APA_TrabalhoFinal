using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Dominio.Entidades;

namespace UniversidadeXYZ.Infra.Data.Mapping
{
    public class DisciplinaTurmaMap : IEntityTypeConfiguration<DisciplinaTurma>
    {
        public void Configure(EntityTypeBuilder<DisciplinaTurma> builder)
        {
            builder.ToTable("DisciplinaTurma")
                    .HasKey(a => new { a.CodigoDisciplina, a.CodigoDaTurma });

            builder.Property(a => a.QuantidadeVagas)
                   .IsRequired();

            builder.HasOne(a => a.Disciplina)
                .WithMany(b => b.DisciplinaTurma)
                .HasForeignKey(a => a.CodigoDisciplina);

            builder.HasOne(a => a.Turma)
                .WithMany(b => b.DisciplinaTurma)
                .HasForeignKey(a => a.CodigoDaTurma);

            builder.HasMany(a => a.Matricula)
                   .WithOne(b => b.DisciplinaTurma);
        }
    }
}
