using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace crud_web.Models;

[Table("person")]
public partial class Person
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    [Range(1, 125, ErrorMessage = "Too much value")]
    public int? Age { get; set; }
}
