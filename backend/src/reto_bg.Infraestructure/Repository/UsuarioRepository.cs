using System;
using Microsoft.Extensions.Logging;
using reto_bg.Application.Contracts;
using reto_bg.Domain.Types;

namespace reto_bg.Infraestructure.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ILogger<UsuarioRepository> _logger;

    public UsuarioRepository(ILogger<UsuarioRepository> logger)
    {
        _logger = logger;
    }

    public async Task<bool> AddUsuarioAsync(UsuarioType usuario)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - {AddUsuarioAsync}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("Usuario agregado");
        }
    }

    public async Task<bool> DeleteUsuarioAsync(int id)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - {DeleteUsuarioAsync}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("Usuario agregado");
        }
    }

    public async Task<UsuarioType> GetUsuarioAsync(int id)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - {GetUsuarioAsync}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("Usuario agregado");
        }
    }

    public async Task<ICollection<UsuarioType>> GetUsuariosAsync()
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - {GetUsuariosAsync}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("Usuario agregado");
        }
    }

    public async Task<bool> UpdateUsuarioAsync(UsuarioType usuario)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - {UpdateUsuarioAsync}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
        finally
        {
            _logger.LogInformation("Usuario agregado");
        }
    }
}
