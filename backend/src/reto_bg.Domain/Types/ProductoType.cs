using System;

namespace reto_bg.Domain.Types;

public class ProductoType
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public decimal PrecioUnitario { get; set; }
}
