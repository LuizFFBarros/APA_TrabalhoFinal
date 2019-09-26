using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Interfaces;
using UniversidadeXYZ.Infra.Data.Repository;

namespace UniversidadeXYZ.Service.Services
{
    public class TurmaService : IService<Turma>
    {
        private readonly COBOL.Services.TurmaService _cobolTurmaService;
        public TurmaService(COBOL.Services.TurmaService cobolTurma)
        {
            _cobolTurmaService = cobolTurma;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Turma Insert<V>(Turma obj) where V : AbstractValidator<Turma>
        {
            var maxCodigo = _cobolTurmaService.Select().Max(a => a.CodigoDaTurma);
            var cobol = new COBOL.Entidades.Turma
            {
                CodigoDaTurma = maxCodigo + 1,
                DataInicio = obj.DataInicio
            };
            var entidade = new Turma
            {
                CodigoDaTurma = cobol.CodigoDaTurma,
                DataInicio = cobol.DataInicio
            };

            _cobolTurmaService.Insert(cobol);
            return entidade;
        }

        public Turma Select(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Turma> Select()
        {
            var retorno = _cobolTurmaService.Select().Select(a => new Turma
            {
                CodigoDaTurma = a.CodigoDaTurma,
                DataInicio = a.DataInicio

            }).ToList();

            return retorno;
        }

        public Turma Update<V>(Turma obj) where V : AbstractValidator<Turma>
        {
            throw new NotImplementedException();
        }
    }
}
