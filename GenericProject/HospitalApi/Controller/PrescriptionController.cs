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
    public class PrescriptionController : ControllerBase
    {
        private IPrescriptionService _prescriptionService;
        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }
        [HttpGet("GetAllPrescriptions")]
        public async Task<ActionResult<IEnumerable<Prescriptions>>> Get()
        {
            var prescription = await _prescriptionService.GetAllPrescription();
            return Ok(prescription);
        }
        [HttpPost("CreatePrescription")]
        public async Task<ActionResult<IEnumerable<Prescriptions>>> Post([FromBody] Prescriptions Prescription)
        {
            var createPrescription = await _prescriptionService.CreatePrescription(Prescription);
            return Ok(createPrescription);
        }
    }
}
