using System;

namespace reto_bg.Domain.Types;

public class UsuarioType
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Rol { get; set; }
}
