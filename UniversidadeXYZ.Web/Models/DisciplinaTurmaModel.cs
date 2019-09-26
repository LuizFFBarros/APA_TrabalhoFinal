using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversidadeXYZ.Web.Models
{
    public class DisciplinaTurmaModel
    {
        public DisciplinaModel Disciplina { get; set; }
        public int CodigoDisciplina { get; set; }
        public int CodigoDaTurma { get; set; }
        public int QuantidadeVagas { get; set; }
    }
}
