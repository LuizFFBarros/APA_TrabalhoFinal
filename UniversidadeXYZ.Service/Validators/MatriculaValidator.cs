using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Dominio.Entidades;

namespace UniversidadeXYZ.Service.Validators
{
    public class MatriculaValidator : AbstractValidator<Matricula>
    {
        public MatriculaValidator()
        {
            RuleFor(a => a)
                .NotNull()
                .OnAnyFailure(x => { throw new ArgumentException($"Objeto {nameof(Matricula)} nulo"); });
        }
    }
}
