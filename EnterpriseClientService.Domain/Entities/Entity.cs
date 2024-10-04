namespace EnterpriseClientService.Domain.Entities
{
    public class Entity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime UpdatedDate { get; private set; }
        public DateTime CreatedDate { get; private set; } = DateTime.Now;

        public void SetUpdateDate() => UpdatedDate = DateTime.Now;
    }
}
