using System;
using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController(DataContext context, ITokenService tokenService) : BaseApiController
{
    // end point register
    [HttpPost("register")]      //  api/account/register
    // Account/register
    // public async Task<ActionResult<AppUsers>> Register(string username, string password)

    // thay vi dung tham so la 1 string binh thuong, gio day ta lay tham so la 1 Obj registerDTO
    public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
    {
        // check username truoc 
        if (await UserExists(registerDTO.UserName))
        {
            return BadRequest("UserName da co ng dung !");
        }

        // dung using thay cho cac ham dispose vi muon tiet kiem dung luong
        // using dung xong thi tu xoa bo, cac ham dispose se xoa bo khi can thiet => ko control dc  
        using var hmac = new HMACSHA512();

        // sau khi nhan U.Name + pass thi xu li va tao moi 1 AppUsers
        var user = new AppUsers
        {
            UserName = registerDTO.UserName.ToLower(),
            // Hash => bam pass
            HashPassWord = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.PassWord)),
            // luu key salt
            SaltPassWord = hmac.Key
        };

        // voi context la 1 O cua class Datacontext va prop Users co kieu DbSet thuoc Entity nen co Add
        context?.Users?.Add(user);
        await context.SaveChangesAsync();
        // return user;
        // tra ve 1 UserDTO chua userName thay vi ca user - pass ,...
        return new UserDTO
        {
            UserName = user.UserName,
            Token = tokenService.CreateToken(user),

        };

    }

    // end point login 
    [HttpPost("login")]
    public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
    {
        // tao ra user de so sanh voi loginDTO.UserName
        // FirstAsync : neu ko co thi phat sinh Ex
        // chon FirstOrDefaultAsync de tim roi do xem co rong ko
        // Single chi tim nguoi ton tai duy nhat  
        var user = await context?.Users?.FirstOrDefaultAsync(x => x.UserName == loginDTO.UserName.ToLower());
        // check null
        if (user == null) return Unauthorized("Invalid USERNAME! Pls Check!");
        // check pass voi key la SaltPassWord
        using var hmac = new HMACSHA512(user.SaltPassWord);
        // hash pass cua loginDTO
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.PassWord));
        // so sanh 2 pass 
        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.HashPassWord[i]) return Unauthorized("Invalid PASSWORD! Pls");
        }
        return new UserDTO
        {
            UserName = loginDTO.UserName,
            Token = tokenService.CreateToken(user),
        };
    }


    // phuong thuc check userName trung lap
    private async Task<bool> UserExists(string username)
    {
        return await context?.Users?.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
    }

}
