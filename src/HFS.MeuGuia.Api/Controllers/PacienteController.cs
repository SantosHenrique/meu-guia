using HFS.MeuGuia.Application.Mediator.Pacientes.Create;
using Microsoft.AspNetCore.Mvc;

namespace HFS.MeuGuia.Api.Controllers
{
    public class PacienteController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreatePacienteCommand command, CancellationToken cancellationToken)
        {
            await Mediator.Send(command, cancellationToken);
            return Created();
        }
    }
}
