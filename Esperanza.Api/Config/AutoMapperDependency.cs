using System.Reflection;

namespace Esperanza.Api.Config
{
    public static class AutoMapperDependency
    {
        public static IServiceCollection AddAutoMapperDependency(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
