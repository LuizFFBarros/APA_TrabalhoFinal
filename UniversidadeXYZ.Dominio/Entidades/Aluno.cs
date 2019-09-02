using System;
using System.Collections.Generic;
using System.Text;

namespace UniversidadeXYZ.Dominio.Entidades
{
    public class Aluno : BaseEntity
    {
        public string Nome { get; set; }
        public int CPF { get; set; }
        public int Telefone { get; set; }
        public string Logradouro { get; set; }

    }
}
