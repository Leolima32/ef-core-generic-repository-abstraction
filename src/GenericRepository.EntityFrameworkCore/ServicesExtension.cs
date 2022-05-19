using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LF.GenericRepository.EntityFrameworkCore
{
    public static class ServicesExtension
    {
        public static void AddGenericRepositorySqlServer<T>(this IServiceCollection services, string connectionString) where T : GenericDbContext
        {
            services.AddDbContext<T>(options =>
                options.UseSqlServer(connectionString));
        }

        public static void CreateDatabaseIfNotExists(this IServiceCollection services, GenericDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
