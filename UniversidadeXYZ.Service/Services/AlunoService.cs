using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FluentValidation;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Interfaces;
using UniversidadeXYZ.Infra.Data.Repository;

namespace UniversidadeXYZ.Service.Services
{
    public class AlunoService : IService<Aluno>
    {
        private readonly IMapper _mapper;
        private COBOL.Services.AlunoService _alunoService;
        public AlunoService(IMapper mapper, COBOL.Services.AlunoService alunoService)
        {
            _mapper = mapper;
            _alunoService = alunoService;
        }
        
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

            return _mapper.Map<IList<COBOL.Entidades.Aluno>, IList<Aluno>>(_alunoService.Select());
            
        }

        public Aluno Update<V>(Aluno obj) where V : AbstractValidator<Aluno>
        {
            throw new NotImplementedException();
        }
    }
}
