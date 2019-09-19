using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Web.Models;

namespace UniversidadeXYZ.Web.AutoMapper
{
    public class MappingProfile : Profile
    {
        public static MapperConfiguration configure()
        {
            return new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
        }
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Aluno, AlunoModel>().ReverseMap();
            
        }
    }
}
