using EnterpriseClientService.Application.Commands;
using EnterpriseClientService.Application.Queries;
using EnterpriseClientService.WebApi.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseClientService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnterpriseClientController : ApiController
    {
        public EnterpriseClientController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken ct) => await SendAsync(new GetAllEnterpriseClientQuery(), ct);

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(Guid Id, CancellationToken ct) => await SendAsync(new GetByIdEnterpriseClientQuery(Id), ct);

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEnterpriseClientCommand command, CancellationToken ct) => await SendAsync(command, ct);

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id, CancellationToken ct) => await SendAsync(new DeleteEnterpriseClientCommand(Id), ct);

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEnterpriseClientCommand command, CancellationToken ct) => await SendAsync(command, ct);
    }
}
