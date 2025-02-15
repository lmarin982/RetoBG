using System;
using reto_bg.Domain.Types;

namespace reto_bg.Application.Contracts;

public interface IClienteRepository
{
    public Task<ClienteType> GetClienteAsync(int id);
    public Task<ICollection<ClienteType>> GetClientesAsync();
    public Task<bool> AddClienteAsync(ClienteType cliente);
    public Task<bool> UpdateClienteAsync(ClienteType cliente);
    public Task<bool> DeleteClienteAsync(int id);
}
