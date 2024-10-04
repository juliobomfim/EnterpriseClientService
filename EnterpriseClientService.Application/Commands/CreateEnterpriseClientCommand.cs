using EnterpriseClientService.Application.Dtos;
using EnterpriseClientService.Domain.Enumerables;
using EnterpriseClientService.Domain.Interfaces.Models;
using MediatR;

namespace EnterpriseClientService.Application.Commands
{
    public class CreateEnterpriseClientCommand : IRequest<IResult<EnterpriseClientDto>>
    {
        public string EnterpriseClientName { get; set; } = string.Empty;
        public EnumEnterpriseScale EnterpriseClientScale { get; set; }
    }
}
