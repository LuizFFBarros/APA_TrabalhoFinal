using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Infra.Data.Repository;
using UniversidadeXYZ.Service.Services;
using UniversidadeXYZ.Service.Validators;
using Xunit;

namespace UniversidadeXYZ.Test.Disciplina
{
    public class DisciplinaTest
    {
        [Fact]
        public void TestaInclusao()
        {
            DisciplinaRepository repository = new DisciplinaRepository();
            DisciplinaService disciplinaService = new DisciplinaService(repository);

            Dominio.Entidades.Disciplina disciplina = new Dominio.Entidades.Disciplina
            {
                Nome = "Matemática",
                CargaHoraria = 30
            };


            var retorno = disciplinaService.Insert<DisciplinaValidator>(disciplina);

            Assert.True(retorno != null);

        }

        [Fact]
        public void TestaListagem()
        {
            DisciplinaRepository repository = new DisciplinaRepository();
            DisciplinaService disciplinaService = new DisciplinaService(repository);
            
            var retorno = disciplinaService.Select();

            Assert.True(retorno.Count > 0);

        }
    }
}
