using System;

namespace reto_bg.Domain.Types;

public class FacturaType
{
    public int Id { get; set; }
    public int IdCliente { get; set; }
    public int IdUsuario { get; set; }
    public DateTime Fecha { get; set; }
    public string? FormaDePago { get; set; }
}
