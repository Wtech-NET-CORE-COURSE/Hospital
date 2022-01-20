using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<Users>>> Get()
        {
            var user = await _userService.GetAllUser();
            return Ok(user);
        }
        [HttpPost("CreateUser")]
        public async Task<ActionResult<IEnumerable<Users>>> Post([FromBody] Users User)
        {
            var createUser = await _userService.CreateUser(User);
            return Ok(createUser);
        }
    }
}
