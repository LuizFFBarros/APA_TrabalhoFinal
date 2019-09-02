using System;
using System.Collections.Generic;
using System.Text;

namespace UniversidadeXYZ.Dominio.Entidades
{
    public class Disciplina : BaseEntity
    {
        public int CodigoDisciplina { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }

        public virtual ICollection<DisciplinaTurma> DisciplinaTurma { get; set; }

    }
}
