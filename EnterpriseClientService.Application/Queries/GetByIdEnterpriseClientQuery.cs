using EnterpriseClientService.Application.Dtos;
using EnterpriseClientService.Domain.Interfaces.Models;
using MediatR;

namespace EnterpriseClientService.Application.Queries
{
    public class GetByIdEnterpriseClientQuery : IRequest<IResult<EnterpriseClientDto>> 
    {
        public Guid Id { get; set; }
        public GetByIdEnterpriseClientQuery(Guid id) { Id = id; }
    }
}
