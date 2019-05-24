using FluentValidation;
using SIS_ISENTREGA.Application;

namespace SIS_ISENTREGA.UI
{
    public class MatrizValid : AbstractValidator<MatrizViewModel>
    {
        public MatrizValid()
        {
            RuleFor(r => r.NomeMatriz)
               .NotEmpty()
                .WithMessage("Por favor Preencha o campo!")
                .Length(3, 100)
                .WithMessage("O campo deve ser preenchido no minimo 3 caracteres e no maximo de 100 caracteres.");

            RuleFor(r => r.CEP)
              .NotEmpty()
               .WithMessage("Por favor Preencha o campo!");
               
        }
    }
}