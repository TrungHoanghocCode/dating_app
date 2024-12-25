using System;

namespace API.Entities;

public class AppUsers
{
    public int Id { get; set; }
    // public string UserName { get; set; } = "";                     // "" la value mac dinh 
    public required string UserName { get; set; }               // them required de chac chan user co nhap ten
}
