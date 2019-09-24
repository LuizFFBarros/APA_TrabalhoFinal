using System;
using System.Collections.Generic;
using System.Text;

namespace UniversidadeXYZ.COBOL.Entidades
{
    public class Aluno
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public long CPF { get; set; }
        public long Telefone { get; set; }
        public string Logradouro { get; set; }
    }
}
