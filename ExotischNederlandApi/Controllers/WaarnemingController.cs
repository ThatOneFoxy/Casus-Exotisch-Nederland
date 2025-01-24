using Microsoft.AspNetCore.Mvc;

namespace MinimalApiExample.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class WaarnemingController : ControllerBase
    {
        private readonly WaarnemingService _service;

        public WaarnemingController(WaarnemingService service)
        {
            _service = service;
        }

        // POST: api/Waarenming
        [HttpPost]
        public IActionResult VoegWaarnemingToe([FromBody] Waarneming waarneming)
        {
            if (waarneming == null)
            {
                return BadRequest("Waarneming mag niet null zijn.");
            }

            _service.RegistreerWaarneming(waarneming);
            return Ok("Waarneming toegevoegd.");
        }

        // GET: api/Waarenming
        [HttpGet]
        public IActionResult HaalAlleWaarnemingenOp()
        {
            var waarnemingen = _service.HaalAlleWaarnemingenOp();
            return Ok(waarnemingen);
        }


        // DELETE: api/Waarenming{WaarnemingID}
        [HttpDelete("{waarnemingID}")]
        public IActionResult VerwijderSoort(int waarnemingID)
        {
            var isVerwijderd = _service.VerwijderWaarneming(waarnemingID);
            if (!isVerwijderd)
            {
                return NotFound($"Waarneming met id {waarnemingID} niet gevonden.");
            }

            return Ok($"Waarneming met id {waarnemingID} is verwijderd.");
        }
    }
}
