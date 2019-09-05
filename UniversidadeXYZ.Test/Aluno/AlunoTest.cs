using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Service.Services;
using UniversidadeXYZ.Service.Validators;
using UniversidadeXYZ.Dominio.Entidades;
using Xunit;

namespace UniversidadeXYZ.Test.Aluno
{
    public class AlunoTest
    {
        [Fact]
        public void TestaInclusao()
        {
            AlunoService alunoService = new AlunoService();

            Dominio.Entidades.Aluno aluno = new Dominio.Entidades.Aluno
            {
                Id = 1,
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
