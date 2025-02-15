using System;
using reto_bg.Domain.Responses;
using reto_bg.Domain.Types;

namespace reto_bg.Application.Contracts;

public interface IFacturaRepository
{
    public Task<FacturaResponsesType?> GetFacturaAsync(int id);
    public Task<ICollection<FacturaType>> GetFacturasAsync();
    public Task<bool> AddFacturaAsync(FacturaType factura);
    public Task<bool> UpdateFacturaAsync(FacturaType factura);
    public Task<bool> DeleteFacturaAsync(int id);
}
