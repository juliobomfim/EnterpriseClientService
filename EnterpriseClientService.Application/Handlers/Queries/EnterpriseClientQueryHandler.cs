using EnterpriseClientService.Application.Dtos;
using EnterpriseClientService.Application.Extensions;
using EnterpriseClientService.Application.Queries;
using EnterpriseClientService.Domain.Entities;
using EnterpriseClientService.Domain.Interfaces.Models;
using EnterpriseClientService.Domain.Interfaces.Repositories;
using EnterpriseClientService.Domain.Models;
using MediatR;

namespace EnterpriseClientService.Application.Handlers.Queries
{
    public class EnterpriseClientQueryHandler : IRequestHandler<GetAllEnterpriseClientQuery, IResult<IEnumerable<EnterpriseClientDto>>>,
                                                IRequestHandler<GetByIdEnterpriseClientQuery, IResult<EnterpriseClientDto>>
    {
        private readonly IReadRepository<EnterpriseClient> _repository;
        public EnterpriseClientQueryHandler(IReadRepository<EnterpriseClient> repository)
        {
            _repository = repository;
        }
        public async Task<IResult<EnterpriseClientDto>> Handle(GetByIdEnterpriseClientQuery request, CancellationToken ct)
        {
            var enterpriseClient = await _repository.GetAsync(request.Id, ct);

            if (enterpriseClient != null) 
                return await Result<EnterpriseClientDto>.SuccessAsync(enterpriseClient.MapToDto());
            
            return await Result<EnterpriseClientDto>.FailAsync();
        }

        public async Task<IResult<IEnumerable<EnterpriseClientDto>>> Handle(GetAllEnterpriseClientQuery request, CancellationToken ct)
        {
            var enterpriseClient = await _repository.GetAllAsync(ct);

            if (enterpriseClient == null || enterpriseClient.Count == 0)
                return await Result<IEnumerable<EnterpriseClientDto>>.SuccessAsync(new List<EnterpriseClientDto>());

            return await Result<IEnumerable<EnterpriseClientDto>>.SuccessAsync(enterpriseClient.Select(e => e.MapToDto()).ToList()); 
        }
    }
}
