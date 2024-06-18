﻿using GestaoInvestimentosCore.DTO.Usuario;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestaoInvestimentosCore.Services
{
    public class TokenService : ITokenService
    {
        public LoginUsuarioDTO GenerateToken(LoginUsuarioDTO loginUsuarioDTO)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e");//(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Email", loginUsuarioDTO.Email.ToString()),
                    new Claim("Senha", loginUsuarioDTO.Senha.ToString()),
                    new Claim(ClaimTypes.Role, "Usuario")
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            loginUsuarioDTO.Token = tokenHandler.WriteToken(token);

            return loginUsuarioDTO;

            //var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Secret"));

            //var tokenDescriptior = new SecurityTokenDescriptor()
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim("RA", student.RA.ToString()),
            //        new Claim("Id", student.Id.ToString()),
            //        new Claim(ClaimTypes.Role, "Student")
            //    }),

            //    Expires = DateTime.UtcNow.AddHours(4),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};

            //return GenerateToken(tokenDescriptior);
        }
    }
}