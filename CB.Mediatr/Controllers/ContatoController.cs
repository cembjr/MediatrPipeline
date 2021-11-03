using CB.MediatrPipeline.Commands;
using CB.MediatrPipeline.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CB.MediatrPipeline.Controllers
{
    [ApiController]
    [Route("v1/contato")]
    public class ContatoController : Controller
    {
        private readonly IMediator _mediator;

        public ContatoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<IActionResult> Adicionar(AdicionarContatoCommand contato)
        {
            var result = await _mediator.Send(contato);

            return result.IsValid ? Ok() : BadRequest();

        }
    }
}
