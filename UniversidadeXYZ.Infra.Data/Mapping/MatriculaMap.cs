using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Dominio.Entidades;

namespace UniversidadeXYZ.Infra.Data.Mapping
{
    public class MatriculaMap : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.ToTable("Matricula")
                   .HasKey(a => a.CodigoMatricula);

            builder.Property(a => a.DataMatricula)
                   .IsRequired();

            builder.Property(a => a.CodigoAluno)
                   .IsRequired();

            builder.Property(a => a.CodigoDaTurma)
                   .IsRequired();

            builder.Property(a => a.CodigoDisciplina)
                   .IsRequired();

            builder.HasOne(a => a.DisciplinaTurma)
                   .WithMany(b => b.Matricula);

        }
    }
}
