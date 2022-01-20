using Entity.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.TokenModels
{
    public class TokenHandler
    {
        public IConfiguration Configuration { get; set; }
        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //Token Üretecek Metot
        public Token CreateToken(Users User)
        {
            Token token = new Token();        
                //SecurityKey'in simetrik yansımasını alır.
                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));
                SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);//Şifreli kimlik oluşturur.

                token.Expration = DateTime.Now.AddMinutes(5);//token süremize 5 dakika ekledik.

                JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                    issuer: Configuration["Token:Issuer"],
                    audience: Configuration["Token:Audience"],
                    expires: token.Expration,
                    notBefore: DateTime.Now, //Token üretidildikten sonra ne zaman devreye girsin.
                    signingCredentials: signingCredentials
                    );
                //Bu iki satır access tokenımızı üretir.
                JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                token.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

                token.ResfreshToken = CreateResfreshToken();
            
     
            return token;
        }
        public string CreateResfreshToken()
        {
            byte[] tokenArray = new byte[32]; //32 karakterli string array
            using (RandomNumberGenerator randomNumberGenerator=RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(tokenArray);//arrayın içini doldurduk.
                return Convert.ToBase64String(tokenArray);//arrayı dönüştürüp gönderdik.
            }
        }
    }
}
