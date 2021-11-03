using CB.MediatrPipeline.Commands;
using CB.MediatrPipeline.Domain;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CB.MediatrPipeline.Handlers
{
    public class ContatoCommandHandler : IRequestHandler<AdicionarContatoCommand, ValidationResult>
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoCommandHandler(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public Task<ValidationResult> Handle(AdicionarContatoCommand request, CancellationToken cancellationToken)
        {
            _contatoRepository.Adicionar(new Contato { Id = request.Id, Nome = request.Nome, Telefone = request.Telefone });

            return Task.FromResult(new ValidationResult());

        }
    }
}
