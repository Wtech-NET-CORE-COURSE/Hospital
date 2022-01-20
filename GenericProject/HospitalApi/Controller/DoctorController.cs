using Business.Abstract;
using DataAccess;
using Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
namespace HospitalApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IDoctorService _doctorService;
        private IHospitalService _hospitalService;
        public DoctorController(IDoctorService doctorService,IHospitalService hospitalService)
        {
            _doctorService = doctorService;
            _hospitalService = hospitalService;
        }
       
        [HttpPost("GetAllDoctors")]
        public async Task<ActionResult<Doctors>> GetAllDoctors()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                var doctor = await _doctorService.GetAllDoctor();
                var customerData = (from tempcustomer in doctor select tempcustomer);
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    //customerData = customerData.OrderBy(s => s.Doctor_Name == (sortColumn + " " + sortColumnDirection));
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    //customerData = customerData.Where(m => m.Doctor_Name.Contains(searchValue));
                }
                recordsTotal = customerData.Count();
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
                return Ok(jsonData);
            }
            catch (Exception ex)
            {

                throw;
            }
            return Ok();
            //var doctor = await _doctorService.GetAllDoctor();
            //return Ok(doctor);
           
        }
        [HttpPost("CreateDoctor")]
        public async Task<ActionResult<IEnumerable<Doctors>>> Post([FromBody] Doctors Doctor)
        {
            var createDoctor = await _doctorService.CreateDoctor(Doctor);
            return Ok(createDoctor);


        }

    }
}
