using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using reto_bg.Application.Contracts;
using reto_bg.Domain.Models;
using reto_bg.Domain.Types;
using reto_bg.Infraestructure.Context;

namespace reto_bg.Infraestructure.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ILogger<ClienteRepository> _logger;
        private readonly DB _context;

        public ClienteRepository(ILogger<ClienteRepository> logger, DB context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<ICollection<ClienteType>> GetClientesAsync()
        {
            try
            {
                _logger.LogInformation("Inicia metodo repository - GetAllClientesAsync");
                ICollection<ClienteModel>? clienteModel = await _context.Cliente.ToListAsync();
                return clienteModel.Select(x => new ClienteType { Id = x.Id, Nombre = x.Nombre, Apellido = x.Apellido, Cedula = x.Cedula, Correo = x.Correo }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<ClienteType?> GetClienteAsync(int id)
        {
            try
            {
                _logger.LogInformation("Inicia metodo repository - GetClienteByIdAsync");
                ClienteModel? clienteModel = await _context.Cliente.FindAsync(id);
                if (clienteModel != null)
                {
                    return new ClienteType { Id = clienteModel.Id, Nombre = clienteModel.Nombre, Apellido = clienteModel.Apellido, Cedula = clienteModel.Cedula, Correo = clienteModel.Correo };
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
        }

        public async Task<bool> AddClienteAsync(ClienteType cliente)
        {
            try
            {
                _logger.LogInformation("Inicia metodo repository - AddClienteAsync");
                ClienteModel cliente_model = new() { Nombre = cliente.Nombre, Apellido = cliente.Apellido, Cedula = cliente.Cedula, Correo = cliente.Correo };
                await _context.Cliente.AddAsync(cliente_model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<bool> UpdateClienteAsync(ClienteType cliente)
        {
            try
            {
                _logger.LogInformation("Inicia metodo repository - UpdateClienteAsync");
                ClienteModel cliente_model = new() { Id = cliente.Id, Nombre = cliente.Nombre, Apellido = cliente.Apellido, Cedula = cliente.Cedula, Correo = cliente.Correo };
                _context.Cliente.Update(cliente_model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<bool> DeleteClienteAsync(int id)
        {
            try
            {
                _logger.LogInformation("Inicia metodo repository - DeleteClienteAsync");
                var cliente = await _context.Cliente.FindAsync(id);
                if (cliente != null)
                {
                    _context.Cliente.Remove(cliente);
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
        }
    }
}
