using System;
using reto_bg.Domain.Types;

namespace reto_bg.Application.Contracts;

public interface IUsuarioRepository
{
    public Task<UsuarioType?> GetUsuarioAsync(string Username, string Password);
    public Task<ICollection<UsuarioType>> GetUsuariosAsync();
    public Task<bool> AddUsuarioAsync(UsuarioType usuario);
    public Task<bool> UpdateUsuarioAsync(UsuarioType usuario);
    public Task<bool> DeleteUsuarioAsync(int id);
}
