using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Interfaces;

namespace UniversidadeXYZ.Service.Services
{
    public class TurmaService : BaseService<Turma>
    {
        private readonly IRepository<Turma> _repository;
        public TurmaService(IRepository<Turma> repository)
        {
            _repository = repository;
        }

        public Turma Inserir(Turma novo)
        {
            var retorno = _repository.Insert(novo);
            return retorno;
        }
    }
}
