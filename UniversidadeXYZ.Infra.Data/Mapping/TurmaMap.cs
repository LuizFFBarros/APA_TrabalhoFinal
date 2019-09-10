using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Dominio.Entidades;

namespace UniversidadeXYZ.Infra.Data.Mapping
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("Turma")
                   .HasKey(a => a.CodigoDaTurma);

            builder.Property(a => a.DataInicio)
                   .IsRequired();

            builder.HasMany(c => c.DisciplinaTurma)
                    .WithOne(e => e.Turma);

        }
    }
}
