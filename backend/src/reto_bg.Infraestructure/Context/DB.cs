using System;
using Microsoft.EntityFrameworkCore;
using reto_bg.Domain.Models;

namespace reto_bg.Infraestructure.Context;

public class DB : DbContext
{
    public DB(DbContextOptions<DB> options) : base(options) { }

    public DbSet<UsuarioModel> Usuario => Set<UsuarioModel>();
    public DbSet<ClienteModel> Cliente => Set<ClienteModel>();
    public DbSet<ProductosModel> Productos => Set<ProductosModel>();
    public DbSet<FacturaModel> Factura => Set<FacturaModel>();
    public DbSet<DetalleFacturaModel> DetalleFactura => Set<DetalleFacturaModel>();
}
