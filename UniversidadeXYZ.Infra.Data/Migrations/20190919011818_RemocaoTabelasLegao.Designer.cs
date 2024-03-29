﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversidadeXYZ.Infra.Data.Context;

namespace UniversidadeXYZ.Infra.Data.Migrations
{
    [DbContext(typeof(SQLContext))]
    [Migration("20190919011818_RemocaoTabelasLegao")]
    partial class RemocaoTabelasLegao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UniversidadeXYZ.Dominio.Entidades.Disciplina", b =>
                {
                    b.Property<int>("CodigoDisciplina")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CargaHoraria");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("CodigoDisciplina");

                    b.ToTable("Disciplina");
                });

            modelBuilder.Entity("UniversidadeXYZ.Dominio.Entidades.DisciplinaTurma", b =>
                {
                    b.Property<int>("CodigoDisciplina");

                    b.Property<int>("CodigoDaTurma");

                    b.Property<decimal>("QuantidadeVagas");

                    b.HasKey("CodigoDisciplina", "CodigoDaTurma");

                    b.ToTable("DisciplinaTurma");
                });

            modelBuilder.Entity("UniversidadeXYZ.Dominio.Entidades.Matricula", b =>
                {
                    b.Property<int>("CodigoMatricula")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoAluno");

                    b.Property<DateTime>("DataMatricula");

                    b.Property<int?>("DisciplinaTurmaCodigoDaTurma");

                    b.Property<int?>("DisciplinaTurmaCodigoDisciplina");

                    b.HasKey("CodigoMatricula");

                    b.HasIndex("DisciplinaTurmaCodigoDisciplina", "DisciplinaTurmaCodigoDaTurma");

                    b.ToTable("Matricula");
                });

            modelBuilder.Entity("UniversidadeXYZ.Dominio.Entidades.DisciplinaTurma", b =>
                {
                    b.HasOne("UniversidadeXYZ.Dominio.Entidades.Disciplina", "Disciplina")
                        .WithMany("DisciplinaTurma")
                        .HasForeignKey("CodigoDisciplina")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UniversidadeXYZ.Dominio.Entidades.Matricula", b =>
                {
                    b.HasOne("UniversidadeXYZ.Dominio.Entidades.DisciplinaTurma", "DisciplinaTurma")
                        .WithMany("Matricula")
                        .HasForeignKey("DisciplinaTurmaCodigoDisciplina", "DisciplinaTurmaCodigoDaTurma");
                });
#pragma warning restore 612, 618
        }
    }
}
