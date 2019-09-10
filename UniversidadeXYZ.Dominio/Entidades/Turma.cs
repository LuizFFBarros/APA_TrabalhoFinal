using System;
using System.Collections.Generic;
using System.Text;

namespace UniversidadeXYZ.Dominio.Entidades
{
    public class Turma : BaseEntity
    {
        public int CodigoDaTurma { get; set; }
        public DateTime DataInicio { get; set; }

        public virtual ICollection<DisciplinaTurma> DisciplinaTurma { get; set; }
    }
}
