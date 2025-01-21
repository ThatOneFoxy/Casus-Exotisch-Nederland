using Microsoft.AspNetCore.Mvc;

namespace MinimalApiExample.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SoortenController : ControllerBase
    {
        private readonly SoortService _service;

        public SoortenController(SoortService service)
        {
            _service = service;
        }

        // POST: api/Soorten
        [HttpPost]
        public IActionResult VoegSoortToe([FromBody] Soort soort)
        {
            if (soort == null)
            {
                return BadRequest("Soort mag niet null zijn.");
            }

            _service.RegistreerSoort(soort);
            return Ok("Soort toegevoegd.");
        }
        
        // GET: api/Soorten
        [HttpGet]
        public IActionResult HaalAlleSoortenOp()
        {
            var soorten = _service.HaalAlleSoortenOp();
            return Ok(soorten);
        }

        // PUT: api/Soorten/{naam}
        [HttpPut("{naam}")]
        public IActionResult UpdateSoort(string naam, Soort updatedSoort)
        {
            if (updatedSoort == null || updatedSoort.naam != naam)
            {
                return BadRequest("Ongeldige gegevens.");
            }

            var isUpdated = _service.UpdateSoort(naam, updatedSoort);
            if (!isUpdated)
            {
                return NotFound($"Inheemse soort met naam {naam} niet gevonden.");
            }

            return Ok($"Inheemse soort met naam {naam} is bijgewerkt.");
        }


        // DELETE: api/Soorten/{naam}
        [HttpDelete("{naam}")]
        public IActionResult VerwijderSoort(String naam)
        {
            var isVerwijderd = _service.VerwijderSoort(naam);
            if (!isVerwijderd)
            {
                return NotFound($"Soort met naam {naam} niet gevonden.");
            }

            return Ok($"Soort met naam {naam} is verwijderd.");
        }
    }
}
