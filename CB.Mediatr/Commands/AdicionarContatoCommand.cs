using FluentValidation.Results;
using MediatR;
using System;

namespace CB.MediatrPipeline.Commands
{
    public class AdicionarContatoCommand : IRequest<ValidationResult>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
    }
}
