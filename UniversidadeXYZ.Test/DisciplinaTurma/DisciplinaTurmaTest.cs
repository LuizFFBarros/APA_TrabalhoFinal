using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Infra.Data.Repository;
using UniversidadeXYZ.Service.Services;
using UniversidadeXYZ.Service.Validators;
using Xunit;

namespace UniversidadeXYZ.Test.DisciplinaTurma
{
    public class DisciplinaTurmaTest
    {
        [Fact]
        public void TestaInclusao()
        {
            DisciplinaTurmaRepository repository = new DisciplinaTurmaRepository();
            DisciplinaTurmaService disciplinaTurmaService = new DisciplinaTurmaService(repository);

            Dominio.Entidades.DisciplinaTurma DisciplinaTurma = new Dominio.Entidades.DisciplinaTurma
            {
                CodigoDisciplina = 1,
                CodigoDaTurma = 3,
                QuantidadeVagas = 20
            };


            var retorno = disciplinaTurmaService.Insert<DisciplinaTurmaValidator>(DisciplinaTurma);

            Assert.True(retorno != null);

        }

        [Fact]
        public void TestaBusca()
        {
            DisciplinaTurmaRepository repository = new DisciplinaTurmaRepository();
            DisciplinaTurmaService disciplinaTurmaService = new DisciplinaTurmaService(repository);

            var retorno = disciplinaTurmaService.Select();

            Assert.True(retorno.Count > 0);

        }
    }
}
