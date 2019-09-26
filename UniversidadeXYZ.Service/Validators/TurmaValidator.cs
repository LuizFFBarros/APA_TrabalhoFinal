using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Dominio.Entidades;

namespace UniversidadeXYZ.Service.Validators
{
    public class TurmaValidator : AbstractValidator<Turma>
    {
        public TurmaValidator()
        {
            RuleFor(a => a)
                .NotNull()
                .OnAnyFailure(x => { throw new ArgumentException($"Objeto {nameof(Turma)} nulo"); });
        }
    }
}
