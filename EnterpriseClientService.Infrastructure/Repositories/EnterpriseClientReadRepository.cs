using EnterpriseClientService.Domain.Entities;
using MongoDB.Driver;

namespace EnterpriseClientService.Infrastructure.Repositories
{
    public class EnterpriseClientReadRepository(MongoClient _mongoClient) : ReadRepository<EnterpriseClient>(_mongoClient, "EnterpriseClient")
    {
    }
}
