using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reto_bg.Domain.Models;

[Table("DetalleFactura")]
public class DetalleFacturaModel
{
    [Key][Column("id", TypeName = "int")] public int Id { get; set; }
    [Column("id_factura", TypeName = "int")] public int IdFactura { get; set; }
    [Column("id_producto", TypeName = "int")] public int IdProducto { get; set; }
    [Column("cantidad", TypeName = "int")] public int Cantidad { get; set; }
    [Column("precio_unitario", TypeName = "decimal(10,2)")] public decimal PrecioUnitario { get; set; }
    [Column("precio_total", TypeName = "decimal(10,2)")] public decimal PrecioTotal { get; set; }
}
