using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using reto_bg.Application.Contracts;
using reto_bg.Domain.Models;
using reto_bg.Domain.Types;
using reto_bg.Infraestructure.Context;

namespace reto_bg.Infraestructure.Repository;

public class ProductoRepository : IProductoRepository
{
    private readonly ILogger<ProductoRepository> _logger;
    private readonly DB _context;

    public ProductoRepository(ILogger<ProductoRepository> logger, DB context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<bool> AddProductoAsync(ProductoType producto)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - AddProductoAsync");
            ProductosModel? model = await _context.Productos.FindAsync(producto.Id);
            if (model == null)
            {
                model = new ProductosModel
                {
                    Nombre = producto.Nombre,
                    PrecioUnitario = producto.PrecioUnitario,
                };
                await _context.Productos.AddAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("Finaliza metodo repository - AddProductoAsync");
        }
    }

    public async Task<bool> DeleteProductoAsync(int id)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - DeleteProductoAsync");
            ProductosModel? model = await _context.Productos.FindAsync(id);
            if (model != null)
            {
                _context.Productos.Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("Finaliza metodo repository - DeleteProductoAsync");
        }
    }

    public async Task<ProductoType?> GetProductoAsync(int id)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - GetProductoAsync");
            ProductosModel? model = await _context.Productos.FindAsync(id);
            if (model != null)
            {
                return new ProductoType
                {
                    Id = model.Id,
                    Nombre = model.Nombre,
                    PrecioUnitario = model.PrecioUnitario,
                };
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("Finaliza metodo repository - GetProductoAsync");
        }
    }

    public async Task<ICollection<ProductoType>> GetProductosAsync()
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - GetProductosAsync");
            ICollection<ProductosModel> productos = await _context.Productos.ToListAsync();
            return productos.Select(p => new ProductoType
            {
                Id = p.Id,
                Nombre = p.Nombre,
                PrecioUnitario = p.PrecioUnitario,
            }).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("Finaliza metodo repository - GetProductosAsync");
        }
    }

    public async Task<bool> UpdateProductoAsync(ProductoType producto)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - UpdateProductoAsync");
            ProductosModel model = new() { Id = producto.Id, Nombre = producto.Nombre, PrecioUnitario = producto.PrecioUnitario };
            ProductosModel? find = await _context.Productos.FindAsync(producto.Id);
            if (find == null) return false;

            find.Nombre = producto.Nombre;
            find.PrecioUnitario = producto.PrecioUnitario;

            _context.Productos.Update(find);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("Finaliza metodo repository - UpdateProductoAsync");
        }
    }
}
