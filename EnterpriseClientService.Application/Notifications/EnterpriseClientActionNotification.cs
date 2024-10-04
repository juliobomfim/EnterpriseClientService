using EnterpriseClientService.Domain.Entities;
using EnterpriseClientService.Domain.Enumerables;
using MediatR;

namespace EnterpriseClientService.Application.Notifications
{
    public class EnterpriseClientActionNotification : INotification
    {
        public EnterpriseClientActionNotification(EnterpriseClient enterpriseClient, EnumActionNotification actionNotification)
        {
            EnterpriseClient = enterpriseClient;
            ActionNotification = actionNotification;
        }

        public EnterpriseClient EnterpriseClient { get; set; }
        public EnumActionNotification ActionNotification { get; set; }
    }
}
