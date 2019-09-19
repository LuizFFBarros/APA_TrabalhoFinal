﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UniversidadeXYZ.Dominio.Entidades
{
    public class Matricula : BaseEntity
    {
        public int CodigoMatricula { get; set; }
        public DateTime DataMatricula { get; set; }

        public int CodigoAluno { get; set; }
        public virtual DisciplinaTurma DisciplinaTurma { get; set; }

    }
}
