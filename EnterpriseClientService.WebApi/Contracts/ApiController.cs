using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseClientService.WebApi.Contracts
{
    public class ApiController : ControllerBase
    {
        protected readonly IMediator _mediator;

        protected ApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> SendAsync<TCommand>(TCommand command, CancellationToken ct) where TCommand : notnull
        {
            var response = await _mediator.Send(command, ct);
            return Ok(response);
        }
    }
}
