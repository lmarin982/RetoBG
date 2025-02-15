using System;
using reto_bg.Domain.Types;

namespace reto_bg.Application.Contracts;

public interface IDetalleFacturaRepository
{
    public Task<DetalleFacturaType> GetDetalleFacturaAsync(int id);
    public Task<ICollection<DetalleFacturaType>> GetDetallesFacturaAsync();
    public Task<bool> AddDetalleFacturaAsync(DetalleFacturaType detalleFactura);
    public Task<bool> UpdateDetalleFacturaAsync(DetalleFacturaType detalleFactura);
    public Task<bool> DeleteDetalleFacturaAsync(int id);

}
