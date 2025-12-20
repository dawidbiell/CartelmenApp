using System.Security.Cryptography;
using System.Text;
using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Entities;
using Cartelmen.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cartelmen.Server.Controllers;

public class AccountController(CartelmenDbContext context): AppBaseController
{
    [HttpPost("register")] // api/account/register
    public async Task<ActionResult<AppUser>> Register([FromBody] AppUserCreateDto user)
    {
        var mailExists = await context.AppUsers.AnyAsync(x => x.Email.ToLower() == user.Email.ToLower());
        if (mailExists) return  BadRequest("Email already exists");
            
        using var hmac = new HMACSHA512();
        
        var appUser = new AppUser()
        {
            Username = user.Username,
            Email = user.Email,
            Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),
            HashSeed = hmac.Key

        };
        
        context.AppUsers.Add(appUser);
        await context.SaveChangesAsync();

        return Ok(appUser);
    }
}