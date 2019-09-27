using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Interfaces;
using UniversidadeXYZ.Infra.Data.Repository;

namespace UniversidadeXYZ.Service.Services
{
    public class MatriculaService : IService<Matricula>
    {
        private readonly MatriculaRepository _repository;
        public MatriculaService(MatriculaRepository repository)
        {
            _repository = repository;
        }

        public Matricula Inserir(Matricula novo)
        {
            try
            {
                bool valido = ValidaNovaMatricula(novo);

                if (valido)
                {
                    var retorno = _repository.Insert(novo);
                    return retorno;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private bool ValidaNovaMatricula(Matricula matricula)
        {
            return _repository.BuscaMatriculaDuplicadaAtiva(matricula.CodigoAluno, matricula.CodigoDaTurma, matricula.CodigoDisciplina) == null;
        }

        public Matricula Update(Matricula matricula)
        {
            var retorno = _repository.Update(matricula);
            return retorno;
        }

        public List<Matricula> BuscaMatriculasAluno(int codigoAluno)
        {
            return _repository.BuscaMatriculasAluno(codigoAluno);
        }

        public Matricula Insert<V>(Matricula obj) where V : AbstractValidator<Matricula>
        {
            return _repository.Insert(obj);
        }

        public Matricula Update<V>(Matricula obj) where V : AbstractValidator<Matricula>
        {
            return _repository.Update(obj);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Matricula Select(int id)
        {
            return _repository.Select(id);
        }

        public IList<Matricula> Select()
        {
            return _repository.Select();
        }

        public void CancelarMatricula(int codigoMatricula)
        {
            _repository.CancelarMatriculaI(codigoMatricula);
        }
    }
}
