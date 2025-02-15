using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reto_bg.Domain.Models;

[Table("Productos")]
public class ProductosModel
{
    [Key][Column("id", TypeName = "int")] public int Id { get; set; }
    [Column("nombre", TypeName = "varchar(50)")] public string? Nombre { get; set; }
    [Column("precio_unitario", TypeName = "decimal(10,2)")] public decimal PrecioUnitario { get; set; }
}
