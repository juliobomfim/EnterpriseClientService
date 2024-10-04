namespace EnterpriseClientService.Domain.Interfaces.UnityOfWork
{
    public interface IUnityOfWork
    {
        Task CommitAsync(CancellationToken ct);
    }
}
