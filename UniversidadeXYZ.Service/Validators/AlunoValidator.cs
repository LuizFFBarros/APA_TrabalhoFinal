using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Dominio.Entidades;

namespace UniversidadeXYZ.Service.Validators
{
    public class AlunoValidator : AbstractValidator<Aluno>
    {
        public AlunoValidator()
        {
            RuleFor(a => a)
                .NotNull()
                .OnAnyFailure(x => { throw new ArgumentException($"Objeto {nameof(Aluno)} nullo"); });
            RuleFor(a => a)
                .Must(a => a.CPF != default(long))
                .OnFailure(x => { throw new ArgumentException("CPF nao pode ser nullo"); });
        }
    }
}
