using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Interfaces;
using UniversidadeXYZ.Infra.Data.Repository;

namespace UniversidadeXYZ.Service.Services
{
    public class AlunoService : BaseService<Aluno>
    {
        private readonly BaseRepository<Aluno> alunoRepository = new BaseRepository<Aluno>(); 

        

        //public Aluno Inserir(Aluno novo)
        //{
        //   var retorno = alunoRepository.Insert(novo);
        //    return retorno;
        //}
    }
}
