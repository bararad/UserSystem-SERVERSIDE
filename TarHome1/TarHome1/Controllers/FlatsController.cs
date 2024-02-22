using Microsoft.AspNetCore.Mvc;
using TarHome1.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TarHome1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatsController : ControllerBase
    {
        // GET: api/<FlatsController>
        [HttpGet]
        public IEnumerable<Flat> Get()
        {
            return Flat.Read();
        }
        [HttpGet("city and price")]
        public IActionResult GetbyCityandPrice(string city,double price)
        {
            List<Flat> flats = Flat.ReadbyCityandPrice(city, price);
            if (flats.Count==0)
            {
                return NotFound("no flats as filtered");
                
            }
            else
            {
                return Ok(flats);
            }
            
        }
       
       

        // POST api/<FlatsController>
        [HttpPost]
        public int Post([FromBody] Flat f)
        {
            if (f.Insert())
            {
                return 1;
            }
            return 0;
        }

        // PUT api/<FlatsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FlatsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
