using System;
using reto_bg.Domain.Models;

namespace reto_bg.Domain.Types;

public class DetalleFacturaType
{
    public int Id { get; set; }
    public int IdFactura { get; set; }
    public int IdProducto { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal PrecioTotal { get; set; }
}