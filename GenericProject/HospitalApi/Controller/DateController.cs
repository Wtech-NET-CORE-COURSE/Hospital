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
    public class DateController : ControllerBase
    {
        private IDateService _dateService;
        public DateController(IDateService dateService)
        {
            _dateService = dateService;
        }
        [HttpGet("GetAllDates")]
        public async Task<ActionResult<IEnumerable<Dates>>> Get()
        {
            var date = await _dateService.GetAllDates();
            return Ok(date);
        }
        [HttpPost("CreateDate")]
        public async Task<ActionResult<IEnumerable<Dates>>> Post([FromBody] Dates Date)
        {
            var createDate = await _dateService.CreateDate(Date);
            return Ok(createDate);
        }
    }
}
