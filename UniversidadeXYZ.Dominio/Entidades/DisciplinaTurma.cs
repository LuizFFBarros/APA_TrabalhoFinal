using System;
using System.Collections.Generic;
using System.Text;

namespace UniversidadeXYZ.Dominio.Entidades
{
    public class DisciplinaTurma : BaseEntity
    {
        public virtual Disciplina Disciplina { get; set; }
        public int CodigoDisciplina { get; set; }
        public virtual Turma Turma { get; set; }
        public int CodigoDaTurma { get; set; }
        public decimal QuantidadeVagas { get; set; }

        public virtual ICollection<Matricula> Matricula { get; set; }
    } 
}
