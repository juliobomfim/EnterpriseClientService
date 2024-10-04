using EnterpriseClientService.Domain.Enumerables;

namespace EnterpriseClientService.Domain.Entities
{
    public class EnterpriseClient : Entity
    {
        public string EnterpriseClientName { get; set; } = string.Empty;
        public EnumEnterpriseScale EnterpriseScale { get; set; }
    }
}
