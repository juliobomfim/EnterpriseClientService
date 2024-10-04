using EnterpriseClientService.Domain.Entities;
using EnterpriseClientService.Domain.Interfaces.Repositories;
using EnterpriseClientService.Domain.Interfaces.UnityOfWork;
using EnterpriseClientService.Infrastructure.DataContexts;
using EnterpriseClientService.Infrastructure.Repositories;
using EnterpriseClientService.Infrastructure.UnityOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace EnterpriseClientService.CrossCutting.InversionOfControl
{
    public static class DataExtensions
    {
        public static IServiceCollection ConfigureDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region SQLServer Context IO

            services.AddDbContext<EnterpriseClientServiceContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("sqlServer")));

            #endregion

            #region MongoDB Context Read

            services.AddSingleton(x =>
            {
                var config = x.GetRequiredService<IConfiguration>();
                var connectionString = config.GetConnectionString("mongoDb");
                return new MongoClient(connectionString);
            });

            #endregion

            #region Services

            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IRepository<EnterpriseClient>, Repository<EnterpriseClient>>();
            services.AddScoped<IReadRepository<EnterpriseClient>, EnterpriseClientReadRepository>();

            #endregion

            #region CQRS MediatR

            var CQRSHandlers = AppDomain.CurrentDomain.Load("EnterpriseClientService.Application");
            services.AddMediatR(opts => opts.RegisterServicesFromAssemblies(CQRSHandlers));
            
            #endregion
            
            return services;
        }
    }
}
