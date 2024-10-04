using EnterpriseClientService.Application.Dtos;
using EnterpriseClientService.Domain.Enumerables;
using EnterpriseClientService.Domain.Interfaces.Models;
using MediatR;

namespace EnterpriseClientService.Application.Commands
{
    public class UpdateEnterpriseClientCommand : IRequest<IResult<EnterpriseClientDto>>
    {
        public Guid EnterpriseClientId { get; set; }
        public string EnterpriseClientName { get; set; } = string.Empty;
        public EnumEnterpriseScale EnterpriseScale { get; set; }
    }
}
