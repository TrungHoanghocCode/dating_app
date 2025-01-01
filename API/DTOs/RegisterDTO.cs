using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDTO
{
    // them Attribute 
    [Required]
    [StringLength(20)]

    public required string UserName { get; set; }
    public required string PassWord { get; set; }
}
