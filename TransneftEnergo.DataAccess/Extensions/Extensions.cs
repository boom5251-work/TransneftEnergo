using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TransneftEnergo.DataAccess.Context;

namespace TransneftEnergo.DataAccess.Extensions
{
    /// <summary>
    /// Методы расширения.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Добавляет контекст базы данных в DI-контейнер.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <param name="connection">Строка подключения.</param>
        /// <returns>Коллекция сервисов.</returns>
        public static IServiceCollection AddDbContext(this IServiceCollection services, string connection)
        {
            return services.AddDbContext<IDatabaseContext, DatabaseContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(connection);

                #if DEBUG
                optionsBuilder.EnableSensitiveDataLogging();
                #endif
            });
        }
    }
}