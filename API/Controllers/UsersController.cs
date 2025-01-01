using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;

namespace API.Controllers;

// // them attribute control
// [ApiController]
// // them route : co nghia la khi truy cap den path nay thi dan thang den class
// // /api/users
// [Route("api/[controller]")]

public class UsersController(DataContext context) : BaseApiController
{
    //  private readonly DataContext _context;
    // // dung ham constructor de nap context 
    // public UsersController(DataContext context)
    // {
    //     _context = context;
    // }
    //sau khi dung primary constructor , nap thang vao tham so thi ko con dung cach nay nua 

    // [Authorize] dat trc 1 Http co y nghia rang phuong thuc nay neu muon dung can phai duoc xac thuc trc 
    // [AllowAnonymous] thi cho phep phuong thuc hoat dong ma khgong can xac thuc 

    // [Authorize]

    [AllowAnonymous]
    // api lay full users  
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUsers>>> GetUser()
    {
        if (context.Users == null) return NotFound();
        var users = await context.Users.ToListAsync();
        return users;
    }

    [Authorize]
    // api lay users cu the  (truyen id , dung ham find, thay doi kieu du lieu IEnumerable)
    [HttpGet("{id:int}")]       // api/Users/1
    public async Task<ActionResult<AppUsers>> GetUser(int id)
    {
        if (context.Users == null) return NotFound();
        var user = await context.Users.FindAsync(id);
        if (user == null) return NotFound();
        return user;
    }
}
