using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Dominio.Entidades;

namespace UniversidadeXYZ.Service.Validators
{
    public class DisciplinaTurmaValidator : AbstractValidator<DisciplinaTurma>
    {
        public DisciplinaTurmaValidator()
        {
            RuleFor(a => a)
                .NotNull()
                .OnAnyFailure(x => { throw new ArgumentException($"Objeto {nameof(DisciplinaTurma)} nulo"); });
        }
    }
}
