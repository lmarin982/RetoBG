using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using reto_bg.Application.Contracts;
using reto_bg.Domain.Models;
using reto_bg.Domain.Types;
using reto_bg.Infraestructure.Context;

namespace reto_bg.Infraestructure.Repository;

public class DetalleFacturaRepository : IDetalleFacturaRepository
{
    private readonly ILogger<DetalleFacturaRepository> _logger;
    private readonly DB _context;

    public DetalleFacturaRepository(ILogger<DetalleFacturaRepository> logger, DB context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<bool> AddDetalleFacturaAsync(DetalleFacturaType detalleFactura)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - AddDetalleFacturaAsync");
            DetalleFacturaModel model = new DetalleFacturaModel()
            {
                Cantidad = detalleFactura.Cantidad,
                IdFactura = detalleFactura.IdFactura,
                IdProducto = detalleFactura.IdProducto,
                PrecioTotal = detalleFactura.PrecioTotal,
                PrecioUnitario = detalleFactura.PrecioUnitario
            };

            _context.DetalleFactura.Add(model);
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
            _logger.LogInformation("Finaliza metodo repository - AddDetalleFacturaAsync");
        }
    }

    public async Task<bool> DeleteDetalleFacturaAsync(int id)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - DeleteDetalleFacturaAsync");
            DetalleFacturaModel? model = await _context.DetalleFactura.FindAsync(id);
            if (model == null) return false;
            _context.DetalleFactura.Remove(model);
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
            _logger.LogInformation("Finaliza metodo repository - DeleteDetalleFacturaAsync");
        }
    }

    public async Task<DetalleFacturaType?> GetDetalleFacturaAsync(int id)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - GetDetalleFacturaAsync");
            DetalleFacturaModel? model = await _context.DetalleFactura.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (model == null) return null;
            DetalleFacturaType type = new DetalleFacturaType()
            {
                Cantidad = model.Cantidad,
                IdFactura = model.IdFactura,
                IdProducto = model.IdProducto,
                PrecioTotal = model.PrecioTotal,
                PrecioUnitario = model.PrecioUnitario
            };
            return type;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("Finaliza metodo repository - GetDetalleFacturaAsync");
        }
    }

    public async Task<ICollection<DetalleFacturaType>> GetDetallesFacturaAsync()
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - GetDetallesFacturaAsync");
            ICollection<DetalleFacturaModel> list_model = await _context.DetalleFactura.ToListAsync();
            var list_type = list_model.Select(model => new DetalleFacturaType
            {
                Cantidad = model.Cantidad,
                IdFactura = model.IdFactura,
                IdProducto = model.IdProducto,
                PrecioTotal = model.PrecioTotal,
                PrecioUnitario = model.PrecioUnitario
            }).ToList();
            return list_type;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("Finaliza metodo repository - GetDetallesFacturaAsync");
        }
    }

    public async Task<bool> UpdateDetalleFacturaAsync(DetalleFacturaType detalleFactura)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - UpdateDetalleFacturaAsync");
            DetalleFacturaModel? model = await _context.DetalleFactura.FindAsync(detalleFactura.Id);
            if (model == null) return false;

            model.Cantidad = detalleFactura.Cantidad;
            model.IdFactura = detalleFactura.IdFactura;
            model.IdProducto = detalleFactura.IdProducto;
            model.PrecioTotal = detalleFactura.PrecioTotal;
            model.PrecioUnitario = detalleFactura.PrecioUnitario;

            _context.DetalleFactura.Update(model);
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
            _logger.LogInformation("Finaliza metodo repository - UpdateDetalleFacturaAsync");
        }
    }
}
