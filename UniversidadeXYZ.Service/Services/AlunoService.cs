using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using FluentValidation;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Interfaces;
using UniversidadeXYZ.Infra.Data.Repository;

namespace UniversidadeXYZ.Service.Services
{
    public class AlunoService : IService<Aluno>
    {
        private readonly COBOL.Services.AlunoService _cobolAlunoService;
        public AlunoService(COBOL.Services.AlunoService cobolAluno)
        {
            _cobolAlunoService = cobolAluno;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Aluno Insert<V>(Aluno obj) where V : AbstractValidator<Aluno>
        {
            var maxCodigo = _cobolAlunoService.Select().Max(a => a.Codigo);
            var cobol = new COBOL.Entidades.Aluno
            {
                Codigo     = maxCodigo + 1,
                CPF        = obj.CPF,
                Logradouro = obj.Logradouro,
                Nome       = obj.Nome,
                Telefone   = obj.Telefone
            };
            var entidade = new Aluno
            {
                Codigo      = cobol.Codigo,
                CPF         = cobol.CPF,
                Logradouro  = cobol.Logradouro,
                Nome        = cobol.Nome,
                Telefone    = cobol.Telefone
            };
           
            _cobolAlunoService.Insert(cobol);
            return  entidade;
        }

        public Aluno Select(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Aluno> Select()
        {
            
            var retorno = _cobolAlunoService.Select().Select(a => new Aluno { 
                Codigo      = a.Codigo,
                CPF         = a.CPF,
                Logradouro  = a.Logradouro,
                Nome        = a.Nome,
                Telefone    = a.Telefone,
            }).ToList();

            return retorno;
        }

        public Aluno Update<V>(Aluno obj) where V : AbstractValidator<Aluno>
        {
            throw new NotImplementedException();
        }
    }
}
