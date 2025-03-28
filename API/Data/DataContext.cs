using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

// public class DataContext : DbContext
// {
//     // dung ctrl . => quick fix => tao dc 1 ham tao 
//     public DataContext(DbContextOptions options) : base(options)
//     {
//     }
// }

// hoac co the viet nhu nay (ham tao chinh)
public class DataContext(DbContextOptions options) : DbContext(options)
{
    // DbSet<AppUsers> link vs Entity Framework
    // Kieu du lieu AppUsers da duoc dinh nghia truoc : ID + UserName

    public DbSet<AppUsers>? Users { get; set; }
    // public DbSet<AppBrands>? Brands { get; set; }
    // SELF
}
