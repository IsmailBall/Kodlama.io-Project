using Kodlama.io.Devs.Application.Services.Repositoreis;
using Kodlama.io.Devs.Persistence.Contexts;
using Kodlama.io.Devs.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kodlama.io.Devs.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            serviceDescriptors.AddDbContext<BaseDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString:SQLServer"]);
            });
            serviceDescriptors.AddScoped<ILanguageRepository,LanguageRepository>();

            return serviceDescriptors;
        }
    }
}