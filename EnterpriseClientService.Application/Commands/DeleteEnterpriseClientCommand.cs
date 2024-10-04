using EnterpriseClientService.Application.Dtos;
using EnterpriseClientService.Domain.Entities;
using EnterpriseClientService.Domain.Interfaces.Models;
using MediatR;

namespace EnterpriseClientService.Application.Commands
{
    public class DeleteEnterpriseClientCommand : IRequest<IResult<EnterpriseClientDto>>
    {
        public DeleteEnterpriseClientCommand(Guid id)
        {
            EnterpriseClientId = id;
        }
        public Guid EnterpriseClientId { get; set; }
    }
}
