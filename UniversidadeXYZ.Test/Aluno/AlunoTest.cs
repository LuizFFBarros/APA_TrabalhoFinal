using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Service.Services;
using UniversidadeXYZ.Service.Validators;
using UniversidadeXYZ.Dominio.Entidades;
using Xunit;
using UniversidadeXYZ.Infra.Data.Repository;

namespace UniversidadeXYZ.Test.Aluno
{
    public class AlunoTest
    {
        [Fact]
        public void TestaInclusao()
        {
            AlunoRepository repository = new AlunoRepository();
            AlunoService alunoService = new AlunoService(repository);

            Dominio.Entidades.Aluno aluno = new Dominio.Entidades.Aluno
            {
                CPF = 12345678900,
                Nome = "Aluno 1",
                Logradouro = "Rua Aluno",
                Telefone = 11223344
            };
            

           var retorno = alunoService.Insert<AlunoValidator>(aluno);

            Assert.True(retorno != null);          
            
        }
    }
}
