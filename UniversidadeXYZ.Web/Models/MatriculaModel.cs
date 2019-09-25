using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversidadeXYZ.Web.Models
{
    public class MatriculaModel
    {
        public int CodigoMatricula { get; set; }
        public DateTime DataMatricula { get; set; }
        public int CodigoAluno { get; set; }
        public int CodigoDaTurma { get; set; }
        public int CodigoDisciplina { get; set; }
        public int CodigoSituacao { get; set; }
        public DisciplinaTurmaModel DisciplinaTurma { get; set; }
    }
}
