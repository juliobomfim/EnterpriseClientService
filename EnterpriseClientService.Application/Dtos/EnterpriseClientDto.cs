using EnterpriseClientService.Domain.Enumerables;

namespace EnterpriseClientService.Application.Dtos
{
    public record EnterpriseClientDto
    {
        public EnterpriseClientDto(Guid enterpriseClientId, string enterpriseClientName, EnumEnterpriseScale enterpriseScale)
        {
            EnterpriseClientId = enterpriseClientId;
            EnterpriseClientName = enterpriseClientName ?? throw new ArgumentException("Argument cannot be null.", nameof(EnterpriseClientName));
            EnterpriseScale = enterpriseScale;
        }

        public Guid EnterpriseClientId { get; set; }
        public string EnterpriseClientName { get; set; } = string.Empty;
        public EnumEnterpriseScale EnterpriseScale { get; set; }
    }
}
