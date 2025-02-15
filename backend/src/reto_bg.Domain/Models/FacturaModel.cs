using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reto_bg.Domain.Models;

[Table("Factura")]
public class FacturaModel
{
    [Key][Column("id", TypeName = "int")] public int Id { get; set; }
    [Column("id_cliente", TypeName = "int")] public int IdCliente { get; set; }
    [Column("id_usuario", TypeName = "int")] public int IdUsuario { get; set; }
    [Column("fecha", TypeName = "datetime")] public DateTime Fecha { get; set; }
    [Column("forma_de_pago", TypeName = "varchar(50)")] public string? FormaDePago { get; set; }
}
