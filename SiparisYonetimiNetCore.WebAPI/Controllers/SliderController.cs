using Microsoft.AspNetCore.Mvc;
using SiparisYonetimiNetCore.Entities;
using SiparisYonetimiNetCore.Service.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SiparisYonetimiNetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly IService<Slide> _service;

        public SliderController(IService<Slide> service)
        {
            _service = service;
        }

        // GET: api/<SliderController>
        [HttpGet]
        public async Task<IEnumerable<Slide>> Get()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<SliderController>/5
        [HttpGet("{id}")]
        public async Task<Slide> Get(int id)
        {
            return await _service.FindAsync(id);
        }

        // POST api/<SliderController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Slide slide)
        {
            await _service.AddAsync(slide);
            await _service.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = slide.Id }, slide);
        }

        // PUT api/<SliderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Slide slide)
        {
            _service.Update(slide);
            var sonuc = await _service.SaveChangesAsync();
            if (sonuc > 0) return NoContent();
            return StatusCode(StatusCodes.Status304NotModified);
        }

        // DELETE api/<SliderController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var kayit = await _service.FindAsync(id);
            if (kayit == null) return BadRequest();
            _service.Delete(kayit);
            var sonuc = await _service.SaveChangesAsync();
            if (sonuc > 0) return NoContent();
            return StatusCode(StatusCodes.Status304NotModified);
        }
    }
}
