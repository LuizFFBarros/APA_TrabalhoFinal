using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Interfaces;
using UniversidadeXYZ.Infra.Data.Repository;

namespace UniversidadeXYZ.Service.Services
{
    public class MatriculaService : BaseService<Matricula>
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
    }
}
