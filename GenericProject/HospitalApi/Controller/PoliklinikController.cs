using Business.Abstract;
using Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliklinikController : ControllerBase
    {
        private IPoliklinikService _poliklinikService;
        public PoliklinikController(IPoliklinikService poliklinikService)
        {
            _poliklinikService = poliklinikService;
        }
        [HttpGet("GetAllPolikliniks")]
        public async Task<ActionResult<IEnumerable<Polikliniks>>> Get()
        {
            var poliklinik = await _poliklinikService.GetAllPoliklinik();
            return Ok(poliklinik);
        }
        [HttpPost("CreatePoliklinik")]
        public async Task<ActionResult<IEnumerable<Polikliniks>>> Post([FromBody] Polikliniks Poliklinik)
        {
            var createPoliklinik = await _poliklinikService.CreatePoliklinik(Poliklinik);
            return Ok(createPoliklinik);
        }
    }
}
