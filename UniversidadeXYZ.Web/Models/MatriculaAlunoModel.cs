using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversidadeXYZ.Web.Models
{
    public class MatriculaAlunoModel
    {
        public int Codigo { get; set; }
        public DateTime Data { get; set; }
        public int Turma { get; set; }
        public string Disciplina { get; set; }
        public string Situacao { get; set; }
    }
}
