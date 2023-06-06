using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApi.Entities;
using WebApi.TokenOperations.Models;

namespace WebApi.TokenOperations
{
    public class TokenHandler
    {
        public IConfiguration Configuration { get; set; }
        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Token CreateAccessToken(User user)
        {
            Token tokenModel = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));
            //key oluşturduk

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //oluşturduğumuz keyi şifreledik, kriptolama

            tokenModel.Expiration=DateTime.Now.AddMinutes(15);
            //tokenın geçerlilik süresi 15 dakika

             JwtSecurityToken securityToken = new JwtSecurityToken(
                //token oluşturma şeklimizi tanıttık
                issuer: Configuration["Token:Issuer"],
                audience: Configuration["Token:Audience"],
                expires: tokenModel.Expiration,
                //token geçerlilik süresi
                notBefore: DateTime.Now,
                //token oluştuktan sonra ne zaman devreye girecek
                signingCredentials: credentials
             );

             JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

             tokenModel.AccessToken = tokenHandler.WriteToken(securityToken);
             //token oluşturduk
             tokenModel.RefreshToken=CreateRefreshToken();

             return tokenModel;

        }

        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}