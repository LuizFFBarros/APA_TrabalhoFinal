using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversidadeXYZ.Web.Models
{
    public class MatriculaAdicionarModel
    {
        public int CodigoAluno { get; set; }
        public SelectList ListaDisciplinaTurma { get; set; }

    }
}
