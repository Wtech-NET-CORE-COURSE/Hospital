using Business.Abstract;
using Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApıHospital.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private IHospitalService _hospitalService;
        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }
        [HttpGet("GetAllHospitals")]
        public async Task<ActionResult<IEnumerable<Hospitals>>> Get()
        {
            var hospital = await _hospitalService.GetAllHospital();
            return Ok(hospital);
        }
    }
}
