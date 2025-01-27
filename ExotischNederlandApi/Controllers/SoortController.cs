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

        // GET: api/Soorten/{SoortID}
        [HttpGet("{soortID}")]
        public IActionResult HaalSoortOp(int soortID) {
            var soort = _service.HaalSoortOp(soortID);
            if (soort == null) {
                return NotFound($"Soort met id {soortID} niet gevonden.");
            }
            return Ok(soort);
        }

        // GET: api/Soorten
        [HttpGet]
        public IActionResult HaalAlleSoortenOp()
        {
            var soorten = _service.HaalAlleSoortenOp();
            return Ok(soorten);
        }

        // PUT: api/Soorten/{SoortID}
        [HttpPut("{soortID}")]
        public IActionResult UpdateSoort(int soortID, Soort updatedSoort)
        {
            if (updatedSoort == null) 
            { 
                return BadRequest("Ongeldige gegevens.");
            }

            var isUpdated = _service.UpdateSoort(soortID, updatedSoort);
            if (!isUpdated)
            {
                return NotFound($"soort met id {soortID} niet gevonden.");
            }

            return Ok($"soort met id {soortID} is bijgewerkt.");
        }


        // DELETE: api/Soorten/{SoortID}
        [HttpDelete("{soortID}")]
        public IActionResult VerwijderSoort(int soortID)
        {
            var isVerwijderd = _service.VerwijderSoort(soortID);
            if (!isVerwijderd)
            {
                return NotFound($"Soort met id {soortID} niet gevonden.");
            }

            return Ok($"Soort met id {soortID} is verwijderd.");
        }
    }
}
