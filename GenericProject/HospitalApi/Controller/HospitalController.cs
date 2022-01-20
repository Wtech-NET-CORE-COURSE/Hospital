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
        [HttpPost("CreateHospital")]
        public async Task<ActionResult<IEnumerable<Hospitals>>> Post([FromBody]Hospitals Hospital)
        {
            var createHospital = await _hospitalService.CreateHospital(Hospital);
            return Ok(createHospital);
        }
        [HttpDelete("DeleteHospital")]
        public async Task<ActionResult<IEnumerable<Hospitals>>> Delete([FromBody] Hospitals Hospital)
        {
            if (_hospitalService.GetHospitalById(Hospital.Hospital_Id)!=null)
            {
                var deleteHospital = _hospitalService.DeleteHospital(Hospital);
                return Ok(deleteHospital);
            }
            return NotFound();
        }

    }
}
