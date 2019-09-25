using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Dominio.Enum;

namespace UniversidadeXYZ.Dominio.Entidades
{
    public class Matricula : BaseEntity
    {
        public Matricula()
        {
            this.CodigoSituacao = 1;
        }

        public int CodigoMatricula { get; set; }
        public DateTime DataMatricula { get; set; }
        public int CodigoAluno { get; set; }
        public int CodigoDaTurma { get; set; }
        public int CodigoDisciplina { get; set; }
        public int CodigoSituacao { get; set; }
        public virtual DisciplinaTurma DisciplinaTurma { get; set; }

        public void CancelaMatricula()
        {
            this.CodigoSituacao = (int)SituacaoMatricula.Inativa;
        }
    }
}
