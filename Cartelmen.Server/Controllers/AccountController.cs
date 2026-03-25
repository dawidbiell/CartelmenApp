using System.Security.Cryptography;
using System.Text;
using Cartelmen.Application.DTOs;
using Cartelmen.Application.Services;
using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cartelmen.Server.Controllers;

public class AccountController(IAppUserRepository repository, ITokenService tokenService): AppBaseController
{
    [HttpPost("register")] // api/account/register
    public async Task<ActionResult<AppUserDto>> Register([FromBody] AppUserRegisterDto user)
    {
        var mailExists = (await repository.GetByEmailAsync(user.Email)) is not null;
        if (mailExists) return  BadRequest("Email already exists");
            
        using var hmac = new HMACSHA512();
        
        var appUser = new AppUser()
        {
            Username = user.Username,
            Email = user.Email,
            Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),
            HashSeed = hmac.Key

        };
        
        await repository.AddAsync(appUser);
        
        var userDto = AppUserDto.FromAppUser(appUser);
        userDto.Token = tokenService.CreateToken(appUser);

        return Ok(userDto);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AppUserDto>> Login(AppUserLoginDto userLogin)
    {
        var appUser = await repository.GetByEmailAsync(userLogin.Email);
        if (appUser == null) return Unauthorized("User not found");

        using var hmac = new HMACSHA512(appUser.HashSeed);

        var hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLogin.Password));

        for (var i = 0; i < appUser.Password.Length; i++)
        {
            var bytesEqual = appUser.Password[i]==hashedPassword[i];
            if (!bytesEqual) return  Unauthorized("Invalid password");
        }

        var userDto = AppUserDto.FromAppUser(appUser);
        userDto.Token = tokenService.CreateToken(appUser);

        return Ok(userDto);
    }
}