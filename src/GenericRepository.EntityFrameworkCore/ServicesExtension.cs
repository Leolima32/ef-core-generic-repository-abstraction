using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace LF.GenericRepository.EntityFrameworkCore
{
    public static class ServicesExtension
    {
        public static void AddGenericRepositorySqlServer<T>(this IServiceCollection services, string? connectionString, Action<SqlServerDbContextOptionsBuilder>? sqlServerOptionsAction = null) where T : GenericDbContext
        {
            services.AddDbContext<T>(options =>
                options.UseSqlServer(connectionString, sqlServerOptionsAction));
        }

        public static void CreateDatabaseIfNotExists(this IServiceCollection services, GenericDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
