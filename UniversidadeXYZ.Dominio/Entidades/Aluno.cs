﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UniversidadeXYZ.Dominio.Entidades
{
    public class Aluno : BaseEntity
    {
        public string Nome { get; set; }
        public long CPF { get; set; }
        public long Telefone { get; set; }
        public string Logradouro { get; set; }

        public virtual ICollection<Matricula> Matricula { get; set; }

    }
}
