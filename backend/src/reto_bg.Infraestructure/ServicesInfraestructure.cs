using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using reto_bg.Application.Contracts;
using reto_bg.Infraestructure.Context;

namespace reto_bg.Infraestructure.Repository;

public static class ServicesInfraestructure
{
    public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IFacturaRepository, FacturaRepository>();
        services.AddScoped<IProductoRepository, ProductoRepository>();

        services.AddDbContext<DB>(opts => opts.UseSqlServer(configuration.GetConnectionString("prueba_bg")));

        return services;
    }
}
