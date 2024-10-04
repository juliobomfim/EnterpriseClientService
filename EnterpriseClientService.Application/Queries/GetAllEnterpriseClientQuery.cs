using EnterpriseClientService.Application.Dtos;
using EnterpriseClientService.Domain.Interfaces.Models;
using MediatR;

namespace EnterpriseClientService.Application.Queries
{
    public class GetAllEnterpriseClientQuery : IRequest<IResult<IEnumerable<EnterpriseClientDto>>> { }
}
