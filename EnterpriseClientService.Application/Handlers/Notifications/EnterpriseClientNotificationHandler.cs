using EnterpriseClientService.Application.Notifications;
using EnterpriseClientService.Domain.Entities;
using EnterpriseClientService.Domain.Enumerables;
using EnterpriseClientService.Domain.Interfaces.Repositories;
using MediatR;

namespace EnterpriseClientService.Application.Handlers.Notifications
{
    public class EnterpriseClientNotificationHandler : INotificationHandler<EnterpriseClientActionNotification>
    {
        private readonly IReadRepository<EnterpriseClient> _repository;
        public EnterpriseClientNotificationHandler(IReadRepository<EnterpriseClient> repository)
        {
            _repository = repository;
        }
        public async Task Handle(EnterpriseClientActionNotification notification, CancellationToken cancellationToken)
        {
            switch (notification.ActionNotification)
            {
                case EnumActionNotification.Updated:
                    await _repository.UpdateAsync(notification.EnterpriseClient, cancellationToken);
                    break;
                case EnumActionNotification.Deleted:
                    await _repository.DeleteAsync(notification.EnterpriseClient, cancellationToken);
                    break;
                default:
                    await _repository.InsertAsync(notification.EnterpriseClient, cancellationToken);
                    break;
            }
        }
    }
}
