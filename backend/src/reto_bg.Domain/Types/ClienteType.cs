using System;

namespace reto_bg.Domain.Types;

public class ClienteType
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Correo { get; set; }
    public string? Cedula { get; set; }
}
