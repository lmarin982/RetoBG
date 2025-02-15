using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reto_bg.Domain.Models;

[Table("Cliente")]
public class ClienteModel
{
    [Key][Column("id", TypeName = "int")] public int Id { get; set; }
    [Column("nombre", TypeName = "varchar(50)")] public string? Nombre { get; set; }
    [Column("apellido", TypeName = "varchar(50)")] public string? Apellido { get; set; }
    [Column("correo", TypeName = "nvarchar(50)")] public string? Correo { get; set; }
    [Column("cedula", TypeName = "varchar(10)")] public string? Cedula { get; set; }
}
