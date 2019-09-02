using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Dominio.Entidades;

namespace UniversidadeXYZ.Infra.Data.Mapping
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno")
                   .HasKey(a => a.CPF);

            builder.Property(a => a.Nome)
                   .IsRequired();

            builder.Property(a => a.Logradouro)
                    .HasMaxLength(200);

            builder.Property(a => a.Telefone);
                   
        }
    }
}
