using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Web.Models;

namespace UniversidadeXYZ.Web.Mapping
{
    public class DominToModel : Profile
    {
        public DominToModel()
        {
            CreateMap<Aluno, AlunoModel>();
        }
    }
}
