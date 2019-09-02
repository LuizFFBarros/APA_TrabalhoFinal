using System;
using System.Collections.Generic;
using System.Text;

namespace UniversidadeXYZ.Dominio.Entidades
{
    public class DisciplinaTurma : BaseEntity
    {
        public virtual ICollection<Disciplina> Disciplina { get; set; }
        public virtual ICollection<Turma> Turma { get; set; }

        public virtual ICollection<Matricula> Matricula { get; set; }
    } 
}
