using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Infra.Data.Context;

namespace UniversidadeXYZ.Infra.Data.Repository
{
    public class DisciplinaTurmaRepository : BaseRepository<DisciplinaTurma>
    {
        private SQLContext context = new SQLContext();
        public List<DisciplinaTurma> BuscaPorTurma(int codigoTurma)
        {
            return context.DisciplinaTurma.Where(d=>d.CodigoDaTurma == codigoTurma).ToList();
        }
        public List<DisciplinaTurma> BuscaPorDisciplina(int codigoDisciplina)
        {
            return context.DisciplinaTurma.Where(d => d.CodigoDisciplina == codigoDisciplina).ToList();
        }
    }
}
