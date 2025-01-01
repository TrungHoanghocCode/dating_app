using System;

namespace API.DTOs;

public class LoginDTO
{
    public required string UserName { get; set; }
    public required string PassWord { get; set; }
}
