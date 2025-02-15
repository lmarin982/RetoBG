using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using reto_bg.Application.Contracts;
using reto_bg.Domain.Models;
using reto_bg.Domain.Types;
using reto_bg.Infraestructure.Context;

namespace reto_bg.Infraestructure.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ILogger<UsuarioRepository> _logger;
    private readonly DB _context;

    public UsuarioRepository(ILogger<UsuarioRepository> logger, DB context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<bool> AddUsuarioAsync(UsuarioType usuario)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - AddUsuarioAsync");
            UsuarioModel usuarioModel = new() { Password = usuario.Password, Rol = usuario.Rol, Username = usuario.Username };

            UsuarioModel? usuarioExistente = await _context.Usuario.FirstOrDefaultAsync(x => x.Username == usuarioModel.Username);
            if (usuarioExistente == null) return false;
            _context.Usuario.Add(usuarioModel);
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
            _logger.LogInformation("Usuario agregado");
        }
    }

    public async Task<bool> DeleteUsuarioAsync(int id)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - DeleteUsuarioAsync");
            UsuarioModel? usuarioExistente = await _context.Usuario.FirstOrDefaultAsync(x => x.Id == id);
            if (usuarioExistente == null) return false;
            _context.Usuario.Remove(usuarioExistente);
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
            _logger.LogInformation("Usuario agregado");
        }
    }

    public async Task<UsuarioType?> GetUsuarioAsync(int id)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository - GetUsuarioAsync");
            UsuarioModel? usuarioExistente = await _context.Usuario.FirstOrDefaultAsync(x => x.Id == id);
            if (usuarioExistente == null) return null;
            UsuarioType usuario = new() { Id = usuarioExistente.Id, Password = usuarioExistente.Password, Rol = usuarioExistente.Rol, Username = usuarioExistente.Username };
            return usuario;
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
            _logger.LogInformation("Inicia metodo repository - GetUsuariosAsync");
            ICollection<UsuarioModel> usuarios = await _context.Usuario.ToListAsync();
            ICollection<UsuarioType> usuariosType = usuarios.Select(x => new UsuarioType { Id = x.Id, Password = x.Password, Rol = x.Rol, Username = x.Username }).ToList();
            return usuariosType;
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
            _logger.LogInformation("Inicia metodo repository - UpdateUsuarioAsync");
            UsuarioModel usuarioModel = new() { Id = usuario.Id, Password = usuario.Password, Rol = usuario.Rol, Username = usuario.Username };
            UsuarioModel? usuarioExistente = await _context.Usuario.FirstOrDefaultAsync(x => x.Id == usuarioModel.Id);
            if (usuarioExistente == null) return false;

            usuarioExistente.Password = usuarioModel.Password;
            usuarioExistente.Username = usuarioModel.Username;
            usuarioExistente.Rol = usuarioModel.Rol;

            _context.Usuario.Update(usuarioExistente);
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
            _logger.LogInformation("Usuario agregado");
        }
    }
}
