using Microsoft.AspNetCore.Mvc;

namespace MinimalApiExample.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class WaarnemingController : ControllerBase {
        private readonly WaarnemingService _service;

        public WaarnemingController(WaarnemingService service) {
            _service = service;
        }

        // POST: api/Waarneming
        [HttpPost]
        public IActionResult VoegWaarnemingToe([FromBody] Waarneming waarneming) {
            if (waarneming == null) {
                return BadRequest("Waarneming mag niet null zijn.");
            }

            _service.RegistreerWaarneming(waarneming);

            return Ok("Waarneming toegevoegd.");
        }

        // GET: api/Waarneming
        [HttpGet]
        public IActionResult HaalAlleWaarnemingenOp() {
            var waarnemingen = _service.HaalAlleWaarnemingenOp();
            return Ok(waarnemingen);
        }

        // PUT: api/Waarneming/{waarnemingID}
        [HttpPut("{waarnemingID}")]
        public IActionResult UpdateWaarneming(int waarnemingID, [FromBody] Waarneming updatedWaarneming) {
            if (updatedWaarneming == null) {
                return BadRequest("Ongeldige gegevens.");
            }

            var isUpdated = _service.UpdateWaarneming(waarnemingID, updatedWaarneming);
            if (!isUpdated) {
                return NotFound($"Waarneming met id {waarnemingID} niet gevonden.");
            }

            return Ok($"Waarneming met id {waarnemingID} is bijgewerkt.");
        }

        // DELETE: api/Waarneming/{waarnemingID}
        [HttpDelete("{waarnemingID}")]
        public IActionResult VerwijderWaarneming(int waarnemingID) {
            var isVerwijderd = _service.VerwijderWaarneming(waarnemingID);
            if (!isVerwijderd) {
                return NotFound($"Waarneming met id {waarnemingID} niet gevonden.");
            }

            return Ok($"Waarneming met id {waarnemingID} is verwijderd.");
        }
    }
}
