using FluentValidation;
using SIS_ISENTREGA.Application;

namespace SIS_ISENTREGA.UI
{
    public class PontoValid : AbstractValidator<PontoViewModel>
    {
        public PontoValid()
        {
            RuleFor(r => r.OidMatriz)
                .NotNull()
                .WithMessage("Por favor selecione uma matriz!");
               // .Equal(0)
               // .WithMessage("Por favor selecione uma matriz!")
               //.Empty()
               //.WithMessage("Por favor selecione uma matriz!");

            RuleFor(r => r.CEP)
              .NotEmpty()
              .WithMessage("Por favor Preencha o campo!");
        }
    }
}