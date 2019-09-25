using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Interfaces;
using UniversidadeXYZ.Infra.Data.Repository;

namespace UniversidadeXYZ.Service.Services
{
    public class DisciplinaTurmaService : IService<DisciplinaTurma>
    {
        private readonly DisciplinaTurmaRepository _repository;
        public DisciplinaTurmaService(DisciplinaTurmaRepository repository)
        {
            _repository = repository;
        }

        public DisciplinaTurma Inserir(DisciplinaTurma novo)
        {
            var retorno = _repository.Insert(novo);
            return retorno;
        }

        public List<DisciplinaTurma> BuscaPorTurma(int codigoTurma)
        {
            return _repository.BuscaPorTurma(codigoTurma);
        }
        public List<DisciplinaTurma> BuscaPorDisciplina(int codigoDisciplina)
        {
            return _repository.BuscaPorDisciplina(codigoDisciplina);
        }

        public DisciplinaTurma Insert<V>(DisciplinaTurma obj) where V : AbstractValidator<DisciplinaTurma>
        {
            throw new NotImplementedException();
        }

        public DisciplinaTurma Update<V>(DisciplinaTurma obj) where V : AbstractValidator<DisciplinaTurma>
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DisciplinaTurma Select(int id)
        {
            throw new NotImplementedException();
        }

        public IList<DisciplinaTurma> Select()
        {
            throw new NotImplementedException();
        }
    }
}
