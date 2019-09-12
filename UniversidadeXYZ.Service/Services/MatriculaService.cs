using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Interfaces;

namespace UniversidadeXYZ.Service.Services
{
    public class MatriculaService : BaseService<Matricula>
    {
        private readonly IRepository<Matricula> _repository;
        public MatriculaService(IRepository<Matricula> repository)
        {
            _repository = repository;
        }

        public Matricula Inserir(Matricula novo)
        {
            var retorno = _repository.Insert(novo);
            return retorno;
        }
    }
}
