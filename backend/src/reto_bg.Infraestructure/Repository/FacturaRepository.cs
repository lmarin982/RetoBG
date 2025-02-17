using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using reto_bg.Application.Contracts;
using reto_bg.Domain.Models;
using reto_bg.Domain.Responses;
using reto_bg.Domain.Types;
using reto_bg.Infraestructure.Context;

namespace reto_bg.Infraestructure.Repository;

public class FacturaRepository : IFacturaRepository
{
    private readonly ILogger<FacturaRepository> _logger;
    private readonly DB _context;

    public FacturaRepository(ILogger<FacturaRepository> logger, DB context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<bool> AddFacturaAsync(FacturaType factura)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - AddFacturaAsync");
            FacturaModel model = new FacturaModel() { Fecha = factura.Fecha, IdCliente = factura.IdCliente, FormaDePago = factura.FormaDePago, IdUsuario = factura.IdUsuario };
            _context.Factura.Add(model);
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
            _logger.LogInformation("Finaliza metodo repository - AddFacturaAsync");
        }
    }

    public async Task<bool> DeleteFacturaAsync(int id)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - DeleteFacturaAsync");
            FacturaModel? model = await _context.Factura.FindAsync(id);
            if (model != null)
            {
                _context.Factura.Remove(model);
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
            _logger.LogInformation("Finaliza metodo repository - DeleteFacturaAsync");
        }
    }

    public async Task<FacturaType?> GetFacturaAsync(int id)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - GetFacturaAsync");
            FacturaModel? model = await _context.Factura.FindAsync(id);
            if (model != null)
            {
                List<DetalleFacturaModel> detalleFactura = await _context.DetalleFactura.Where(x => x.IdFactura == model.Id).ToListAsync();

                decimal total_a_pagar = 0;
                detalleFactura.ForEach(item =>
                {
                    total_a_pagar += item.PrecioUnitario * item.PrecioTotal;
                });

                FacturaType factura = new FacturaType()
                {
                    Fecha = model.Fecha,
                    FormaDePago = model.FormaDePago,
                    Id = model.Id,
                    IdCliente = model.IdCliente,
                    IdUsuario = model.IdUsuario
                };

                /* FacturaResponsesType factura = new FacturaResponsesType()
                {
                    Id = model.Id,
                    Fecha = model.Fecha,
                    IdCliente = model.IdCliente,
                    FormaDePago = model.FormaDePago,
                    IdUsuario = model.IdUsuario,
                    TotalAPagar = total_a_pagar,
                    detalleFacturaTypes = detalleFactura.Select(x => new DetalleFacturaType
                    {
                        Cantidad = x.Cantidad,
                        Id = x.Id,
                        IdFactura = x.IdFactura,
                        IdProducto = x.IdProducto,
                        PrecioTotal = x.PrecioTotal,
                        PrecioUnitario = x.PrecioUnitario
                    }).ToList()
                }; */

                return factura;
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
            _logger.LogInformation("Finaliza metodo repository - GetFacturaAsync");
        }
    }

    public async Task<ICollection<FacturaType>> GetFacturasAsync()
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - GetFacturasAsync");
            ICollection<FacturaModel> facturas = await _context.Factura.ToListAsync();
            return facturas.Select(factura => new FacturaType() { Id = factura.Id, Fecha = factura.Fecha, IdCliente = factura.IdCliente, FormaDePago = factura.FormaDePago, IdUsuario = factura.IdUsuario }).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("Finaliza metodo repository - GetFacturasAsync");
        }
    }

    public async Task<bool> UpdateFacturaAsync(FacturaType factura)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - UpdateFacturaAsync");
            FacturaModel model = new FacturaModel() { Id = factura.Id, Fecha = factura.Fecha, IdCliente = factura.IdCliente, FormaDePago = factura.FormaDePago, IdUsuario = factura.IdUsuario };
            FacturaModel? find = await _context.Factura.FindAsync(factura.Id);
            if (find == null) return false;
            _context.Factura.Update(model);
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
            _logger.LogInformation("Finaliza metodo repository - UpdateFacturaAsync");
        }
    }
}
