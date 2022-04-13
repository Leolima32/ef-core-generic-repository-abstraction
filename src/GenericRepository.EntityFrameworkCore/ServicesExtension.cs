using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GenericRepository.EntityFrameworkCore
{
    public static class ServicesExtension
    {
        public static void AddGenericRepositorySqlServer<T>(this IServiceCollection services, string connectionString) where T : GenericDbContext
        {
            services.AddDbContext<T>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
