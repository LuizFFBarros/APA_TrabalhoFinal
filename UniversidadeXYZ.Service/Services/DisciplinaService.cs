using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Interfaces;

namespace UniversidadeXYZ.Service.Services
{
    public class DisciplinaService : BaseService<Disciplina>
    {
        private readonly IRepository<Disciplina> _repository;
        public DisciplinaService(IRepository<Disciplina> repository)
        {
            _repository = repository;
        }

        public Disciplina Inserir(Disciplina novo)
        {
            var retorno = _repository.Insert(novo);
            return retorno;
        }
    }
}
