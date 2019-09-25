using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Enum;
using UniversidadeXYZ.Infra.Data.Context;

namespace UniversidadeXYZ.Infra.Data.Repository
{
    public class MatriculaRepository : BaseRepository<Matricula>
    {
        private SQLContext context = new SQLContext();

        public List<Matricula> BuscaMatriculasAluno(int codigoAluno)
        {
            return context.Matricula.Where(m => m.CodigoAluno == codigoAluno).ToList();
        }

        public Matricula BuscaMatriculaDuplicadaAtiva(int codigoAluno, int codigoTurma, int codigoDisciplina)
        {
            return context.Matricula.Where(m => m.CodigoAluno == codigoAluno && m.CodigoDaTurma == codigoTurma && m.CodigoDisciplina == codigoDisciplina && m.CodigoSituacao == (int)SituacaoMatricula.Ativa).FirstOrDefault();
        }

    }
}
