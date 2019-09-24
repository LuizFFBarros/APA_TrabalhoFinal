using AutoMapper;

namespace UniversidadeXYZ.Service.Mapping
{
    public class CobolToDomain : Profile
    {
        public CobolToDomain()
        {
            CreateMap<COBOL.Entidades.Aluno, UniversidadeXYZ.Dominio.Entidades.Aluno>();
        }
    }
}
