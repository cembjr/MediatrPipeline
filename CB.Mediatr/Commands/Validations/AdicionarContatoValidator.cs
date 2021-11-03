using CB.MediatrPipeline.Domain;
using FluentValidation;
using System;

namespace CB.MediatrPipeline.Commands.Validations
{
    public class AdicionarContatoValidator : AbstractValidator<AdicionarContatoCommand>
    {
        public AdicionarContatoValidator(IContatoRepository contatoRepository)
        {
            RuleFor(f => f.Id)
                .NotEqual(Guid.Empty)
                .NotEmpty()
                .WithMessage("Id Obrigatório");

            RuleFor(f => f.Nome)
                .NotEmpty()
                .WithMessage("Nome Obrigatório");

            RuleFor(f => f.Telefone)
                .NotEmpty()
                .WithMessage("Telefone Obrigatório");

            RuleFor(f => f)                
                .Must(m => contatoRepository.ContatoJaExiste(m.Telefone))                
                .WithMessage(msg => $"Já existe um contato para o telefone {msg.Telefone}");
        }
    }
}
