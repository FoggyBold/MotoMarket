using MotoMarket.Storage.PostgreSQL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MotoMarket.Storage.PostgreSQL.Setup
{
    public class DbInit
    {
        public static void Execute(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetService<IServiceScopeFactory>()?.CreateScope();
            ArgumentNullException.ThrowIfNull(scope);

            var context = scope.ServiceProvider.GetRequiredService<MainDBContext>();
            context.Database.Migrate();
        }
    }
}
