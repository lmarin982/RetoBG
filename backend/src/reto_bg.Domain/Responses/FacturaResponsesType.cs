using System;
using reto_bg.Domain.Types;

namespace reto_bg.Domain.Responses;

public class FacturaResponsesType
{
    public int Id { get; set; }
    public int IdCliente { get; set; }
    public int IdUsuario { get; set; }
    public DateTime Fecha { get; set; }
    public string? FormaDePago { get; set; }
    public decimal TotalAPagar { get; set; }
    public List<DetalleFacturaType>? detalleFacturaTypes { get; set; }
}
