using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.COBOL.Services;
using Xunit;

namespace UniversidadeXYZ.Test.Turma
{
    public class TumaTest
    {
        [Fact]
        public void TestaInclusao()
        {
            TurmaService turmaService = new TurmaService();

            COBOL.Entidades.Turma turma = new COBOL.Entidades.Turma
            {
                CodigoDaTurma = 1,
                DataInicio = DateTime.Now
            };

            var retorno = turmaService.Insert(turma);

            Assert.True(retorno != null);

        }

        [Fact]
        public void TestaBusca()
        {
            TurmaService turmaService = new TurmaService();

            var listaTurmas = turmaService.Select();

            Assert.True(listaTurmas.Count > 0);

        }
    }
}
