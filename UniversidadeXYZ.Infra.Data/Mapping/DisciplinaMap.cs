using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Dominio.Entidades;

namespace UniversidadeXYZ.Infra.Data.Mapping
{
    public class DisciplinaMap : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.ToTable("Disciplina")
                   .HasKey(a => a.CodigoDisciplina);

            builder.Property(a => a.Nome)
                   .IsRequired();

            builder.Property(a => a.CargaHoraria)
                    .IsRequired();

            builder.HasMany(c => c.DisciplinaTurma)
                   .WithOne(e => e.Disciplina);
        }
    }
}
