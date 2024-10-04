using EnterpriseClientService.Application.Dtos;
using EnterpriseClientService.Domain.Entities;

namespace EnterpriseClientService.Application.Extensions
{
    public static class EnterpriseClientExtension
    {
        public static EnterpriseClientDto MapToDto(this EnterpriseClient entity) => new EnterpriseClientDto(entity.Id, entity.EnterpriseClientName, entity.EnterpriseScale);
        public static EnterpriseClientDto MapToEntity(this EnterpriseClientDto dto) => new EnterpriseClientDto(dto.EnterpriseClientId, dto.EnterpriseClientName, dto.EnterpriseScale);
    }
}
