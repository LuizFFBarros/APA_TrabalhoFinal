using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Service.Validators;
using Xunit;
using UniversidadeXYZ.Infra.Data.Repository;
using UniversidadeXYZ.COBOL.Services;

namespace UniversidadeXYZ.Test.Aluno
{
    public class AlunoTest
    {
        [Fact]
        public void TestaInclusao()
        {
            AlunoService alunoService = new AlunoService();

            COBOL.Entidades.Aluno aluno = new COBOL.Entidades.Aluno
            {
                CPF = 1234567,
                Nome = "Aluno 1",
                Logradouro = "Rua Aluno",
                Telefone = 11223344
            };

            var retorno = alunoService.Insert(aluno);

            Assert.True(retorno != null);
            
        }

        [Fact]
        public void TestaBusca()
        {
            AlunoService alunoService = new AlunoService();
            
            var listaAlunos = alunoService.Select();

            Assert.True(listaAlunos.Count > 0);

        }

    }
}
