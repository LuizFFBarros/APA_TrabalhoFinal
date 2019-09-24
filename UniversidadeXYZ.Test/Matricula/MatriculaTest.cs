using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Infra.Data.Repository;
using UniversidadeXYZ.Service.Services;
using UniversidadeXYZ.Service.Validators;
using Xunit;

namespace UniversidadeXYZ.Test.Matricula
{
    public class MatriculaTest
    {
        [Fact]
        public void TestaInclusao()
        {
            MatriculaRepository repository = new MatriculaRepository();
            MatriculaService matriculaService = new MatriculaService(repository);

            Dominio.Entidades.Matricula Matricula = new Dominio.Entidades.Matricula
            {
                CodigoAluno = 1,
                CodigoDaTurma = 3,
                CodigoDisciplina = 1,
                DataMatricula = DateTime.Now
            };


            var retorno = matriculaService.Insert<MatriculaValidator>(Matricula);

            Assert.True(retorno != null);

        }

        [Fact]
        public void TestaListagem()
        {
            MatriculaRepository repository = new MatriculaRepository();
            MatriculaService MatriculaService = new MatriculaService(repository);

            var retorno = MatriculaService.Select();

            Assert.True(retorno.Count > 0);

        }
    }
}
