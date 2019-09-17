using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversidadeXYZ.Web.Models
{
    public class AlunoModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public long CPF { get; set; }
        public long Telefone { get; set; }
        public string Logradouro { get; set; }
    }
}
