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
    public class PatientController : ControllerBase
    {
        private IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpGet("GetAllPatients")]
        public async Task<ActionResult<IEnumerable<Patients>>> Get()
        {
            var patient = await _patientService.GetAllPatient();
            return Ok(patient);
        }
        [HttpPost("CreatePatient")]
        public async Task<ActionResult<IEnumerable<Patients>>> Post([FromBody] Patients Patient)
        {
            var createPatient = await _patientService.CreatePatient(Patient);
            return Ok(createPatient);
        }
    }
}
