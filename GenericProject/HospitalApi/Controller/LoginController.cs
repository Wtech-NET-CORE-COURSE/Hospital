using DataAccess;
using Entity.Model;
using HospitalApi.Helpers;
using HospitalApi.TokenModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //static bir metottan static olmayan metot çağırılamaz.
        private readonly ProjeDbContext _context;//readonly static yapmamızı yapar.
        private readonly IConfiguration _configuration;
        private readonly GenericHelperMethods _genericHelperMethods;
       public LoginController(ProjeDbContext context,IConfiguration configuration, GenericHelperMethods genericHelperMethods)
        {
            _context = context;
            _configuration = configuration;
            _genericHelperMethods = genericHelperMethods;
        }


        [HttpPost("[action]")]//alttaki create ismini yazdığımızda çalışmasını sağlar.
                              //www.örnek.com/api/login/create şeklinde kullanmamıza izin verir.
        public async Task<bool> Create([FromBody]Users user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }


        [HttpPost("[action]")]
        public async Task<Token> Login([FromBody] UserLogin userLogin)
        {
            Users user = await _context.User.FirstOrDefaultAsync(w => w.Email == userLogin.Email && w.Password == userLogin.Password);
            if(user!=null)
            {              
                return await _genericHelperMethods.CreateRefreshToken(user, _context, _configuration);
            }
            return null;
        }


        [HttpPost("[action]")]
        public async Task<Token> RefreshTokenLogin([FromForm] string refreshToken)
        {
            Users user = await _context.User.FirstOrDefaultAsync(w => w.RefreshToken == refreshToken);
            if(user!=null && user?.RefreshTokenEndDate>DateTime.Now)// ? null olabilir anlamına gelir.
            {               
                return await _genericHelperMethods.CreateRefreshToken(user, _context, _configuration);
            }
            return null;
        }   
    }
}
