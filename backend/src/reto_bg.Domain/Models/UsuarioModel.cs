using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reto_bg.Domain.Models;

[Table("Usuario")]
public class UsuarioModel
{
    [Key][Column("id", TypeName = "int")] public int Id { get; set; }
    [Column("username", TypeName = "varchar(50)")] public string? Username { get; set; }
    [Column("password", TypeName = "varchar(50)")] public string? Password { get; set; }
    [Column("rol", TypeName = "varchar(10)")] public string? Rol { get; set; }
}