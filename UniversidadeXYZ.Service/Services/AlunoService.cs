using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Interfaces;
using UniversidadeXYZ.Infra.Data.Repository;

namespace UniversidadeXYZ.Service.Services
{
    public class AlunoService : IService<Aluno>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Aluno Insert<V>(Aluno obj) where V : AbstractValidator<Aluno>
        {
            throw new NotImplementedException();
        }

        public Aluno Select(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Aluno> Select()
        {
            return new List<Aluno>
            {
                new Aluno{ Codigo = 1, Nome = "external service" },
                new Aluno{ Codigo = 2, Nome = "external service" }
            };
        }

        public Aluno Update<V>(Aluno obj) where V : AbstractValidator<Aluno>
        {
            throw new NotImplementedException();
        }
    }
}
