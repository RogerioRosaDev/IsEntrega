using FluentValidation;
using SIS_ISENTREGA.Application;

namespace SIS_ISENTREGA.UI
{
    public class UsuarioValid : AbstractValidator<UsuarioViewModel>
    {
        public UsuarioValid()
        {
            RuleFor(r => r.NomeUsuario)
                .NotEmpty()
                .WithMessage("Por favor Preencha o campo!")
                .Length(3, 30)
                .WithMessage("O campo deve ser preenchido no minimo 3 caracteres e no maximo de 30 caracteres.");

            RuleFor(r => r.Email)
                .NotEmpty()
                .WithMessage("Por favor Preencha o campo.")
                .EmailAddress()
                .WithMessage("Por favor digite um e-mail valido");

            RuleFor(r => r.Senha)
                .NotEmpty()
                .WithMessage("Por favor Preencha o campo!")
                .Equal(r => r.ConfirmarSenha)
                .WithMessage("Senhas estao diferentes!");

            RuleFor(r => r.ConfirmarSenha)
               .NotEmpty()
               .WithMessage("Por favor Preencha o campo!");

            RuleFor(r => r.Login)
              .NotEmpty()
              .WithMessage("Por favor Preencha o campo!");

            RuleFor(r => r.SenhaLogin)
              .NotEmpty()
              .WithMessage("Por favor Preencha o campo!");
        }
    }
}