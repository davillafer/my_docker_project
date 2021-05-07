using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS.Proyecto.Mapa.WebAPI.DataAccessLayer;
using WS.Proyecto.Mapa.WebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WS.Proyecto.Mapa.WebAPI.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class PetitionsController : ControllerBase
    {
        private readonly PetitionsDbContext _petitionsDbContext;

        public PetitionsController(PetitionsDbContext petitionsDbContext)
        {
          this._petitionsDbContext = petitionsDbContext;
        }

        //GET: api/Petitions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Petition>>> GetPetition()
        {
          return Ok(await _petitionsDbContext.Petitions.ToListAsync());
        }

        // GET: api/Petitions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Petition>> GetPetition(int id)
        {
          var petition = await _petitionsDbContext.Petitions.FindAsync(id);

          if (petition == null)
          {
            return NotFound();
          }

          return Ok(petition);
        }

        // PUT: api/Petitions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetition(int id, Petition petition)
        {
            if (id != petition.Id)
            {
                return BadRequest();
            }

            _petitionsDbContext.Entry(petition).State = EntityState.Modified;

            try
            {
                await _petitionsDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsPetitionExists(id))
                {
                    return NotFound();
                }

                throw;
            }
            
            return NoContent();
        }

        // POST: api/Petitions
        [HttpPost]
        public async Task<ActionResult<Petition>> PostPetition(Petition petition)
        {
            _petitionsDbContext.Petitions.Add(petition);
            await _petitionsDbContext.SaveChangesAsync();

            return CreatedAtAction("GetPetition", new { id = petition.Id }, petition);
        }

        // DELETE: api/Petitions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Petition>> DeletePetition(int id)
        {
            var petition = await _petitionsDbContext.Petitions.FindAsync(id);
            if (petition == null)
            {
                return NotFound();
            }

            _petitionsDbContext.Petitions.Remove(petition);
            await _petitionsDbContext.SaveChangesAsync();

            return Ok(petition);
        }

        private bool IsPetitionExists(int id)
        {
          return _petitionsDbContext.Petitions.Any(e => e.Id == id);
        }
    }
}