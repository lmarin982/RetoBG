using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using reto_bg.Application.Contracts;

namespace reto_bg.Infraestructure.Repository;

public static class ServicesInfraestructure
{
    public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IFacturaRepository, FacturaRepository>();
        services.AddScoped<IProductoRepository, ProductoRepository>();

        return services;
    }
}
