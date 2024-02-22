﻿using Microsoft.AspNetCore.Mvc;
using TarHome1.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TarHome1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationsController : ControllerBase
    {
        // GET: api/<VacationsController>
        [HttpGet]
        public IEnumerable<Vacation> Get()
        {
            return Vacation.Read();
        }

        
        [HttpGet("getByDates/startDate/{startDate}/endDate/{endDate}")]
        public IEnumerable<Vacation> GetByDates(DateTime startDate, DateTime endDate)
        {
            return Vacation.ReadByDates(startDate,endDate);
        }

        // GET api/<VacationsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VacationsController>
        [HttpPost]
        public int Post([FromBody] Vacation v)
        {
            bool res=v.Insert();
            if (res)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        // PUT api/<VacationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VacationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
