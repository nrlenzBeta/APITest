#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APITest.Models;

namespace APITest.Controllers
{
    [Route("api/SuperHeroes")]
    [ApiController]
    public class SuperHeroesController : ControllerBase
    {
        private readonly SuperHeroContext _context;

        public SuperHeroesController(SuperHeroContext context)
        {
            _context = context;
        }

        // GET: api/SuperHeroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperHeroDTO>>> GetSuperHeroes()
        {
            return await _context.SuperHeroes
                .Select(x => SuperHeroToDTO(x))
                .ToListAsync();
        }

        // GET: api/SuperHeroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHeroDTO>> GetSuperHero(long id)
        {
            var superHero = await _context.SuperHeroes.FindAsync(id);

            if (superHero == null)
            {
                return NotFound();
            }

            return SuperHeroToDTO(superHero);
        }

        // PUT: api/SuperHeroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSuperHero(long id, SuperHeroDTO superHeroDTO)
        {
            if (id != superHeroDTO.Id)
            {
                return BadRequest();
            }

            var superHero = await _context.SuperHeroes.FindAsync(id);
            if(superHero == null)
            {
                return NotFound();
            }

            superHero.Name = superHeroDTO.Name;
            superHero.Universe = superHeroDTO.Universe;
            superHero.IsEvil = superHeroDTO.IsEvil;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!SuperHeroExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/SuperHeroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SuperHeroDTO>> PostSuperHero(SuperHeroDTO superHeroDTO)
        {
            var superHero = new SuperHero
            {
                IsEvil = superHeroDTO.IsEvil,
                Name = superHeroDTO.Name,
                Universe = superHeroDTO.Universe
            };

            _context.SuperHeroes.Add(superHero);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetSuperHero),
                new { id = superHero.Id },
                SuperHeroToDTO(superHero));
        }

        // DELETE: api/SuperHeroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuperHero(long id)
        {
            var superHero = await _context.SuperHeroes.FindAsync(id);
            if (superHero == null)
            {
                return NotFound();
            }

            _context.SuperHeroes.Remove(superHero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuperHeroExists(long id)
        {
            return _context.SuperHeroes.Any(e => e.Id == id);
        }

        private static SuperHeroDTO SuperHeroToDTO(SuperHero superHero) => new SuperHeroDTO
        {
            Id = superHero.Id,
            Name = superHero.Name,
            Universe = superHero.Universe,
            IsEvil = superHero.IsEvil
        };
    }
}
