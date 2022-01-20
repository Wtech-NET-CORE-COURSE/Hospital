using DataAccess;
using Entity.Model;
using HospitalApi.TokenModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Helpers
{
    public class GenericHelperMethods
    {
        public GenericHelperMethods()
        {

        }
       
        public async Task<Token> CreateRefreshToken(Users user, ProjeDbContext _context, IConfiguration _configuration)
        {
            //user için token üretiliyor.
            TokenHandler tokenHandler = new TokenHandler(_configuration);
            Token token = tokenHandler.CreateToken(user);

            user.RefreshToken = token.ResfreshToken;
            user.RefreshTokenEndDate = token.Expration.AddMinutes(5);//Refresh tokenın ayakta kalma süresi
            await _context.SaveChangesAsync();
            return token;
        }
    }
}
