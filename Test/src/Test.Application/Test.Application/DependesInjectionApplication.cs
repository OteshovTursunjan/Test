using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application;

public  static class DependesInjectionApplication
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnvironment env)
    {
      
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DependesInjectionApplication).Assembly));
        return services;
    }
    private static void RegisterCaching(this IServiceCollection services)
    {
        // Регистрация кэша в памяти
        services.AddMemoryCache();
    }
}
