using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Interfaces;

namespace UniversidadeXYZ.Service.Services
{
    public class DisciplinaTurmaService : BaseService<DisciplinaTurma>
    {
        private readonly IRepository<DisciplinaTurma> _repository;
        public DisciplinaTurmaService(IRepository<DisciplinaTurma> repository)
        {
            _repository = repository;
        }

        public DisciplinaTurma Inserir(DisciplinaTurma novo)
        {
            var retorno = _repository.Insert(novo);
            return retorno;
        }
    }
}
