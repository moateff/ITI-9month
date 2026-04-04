using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Entities.LoginManager;

public class Frontend
{
    [Key]
    [StringLength(50)]
    public string UserName { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string Password { get; set; } = null!;
}