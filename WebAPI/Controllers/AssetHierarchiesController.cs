using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

// Implementare CRUD operations (GET, POST, PUT, DELETE)
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetHierarchiesController : ControllerBase
    {
        private readonly LeasingDbContext _context;

        // constructor cu instanta de LeasingDBContext pentru a face operatii cu (in) baza de date. Prin constructor vom primi datele si le vom asigna prin _context = context unde _context este o proprietate privata definita mai sus.
        // _context vine din DependencyInjection fiind asignat in Startup.cs

        public AssetHierarchiesController(LeasingDbContext context)
        {
            _context = context;
        }

        // GET: api/AssetHierarchies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetHierarchy>>> GetAssetHierarchy()
        {
            return await _context.AssetHierarchy.ToListAsync();
        }

        // GET: api/AssetHierarchies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssetHierarchy>> GetAssetHierarchy(int id)
        {
            var assetHierarchy = await _context.AssetHierarchy.FindAsync(id);

            if (assetHierarchy == null)
            {
                return NotFound();
            }

            return assetHierarchy;
        }

        // PUT: api/AssetHierarchies/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssetHierarchy(int id, AssetHierarchy assetHierarchy)
        {
            assetHierarchy.Id = id;

            _context.Entry(assetHierarchy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetHierarchyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); //nu returnez nimic cand fac update
        }

        // POST: api/AssetHierarchies
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AssetHierarchy>> PostAssetHierarchy(AssetHierarchy assetHierarchy)
        {
            _context.AssetHierarchy.Add(assetHierarchy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssetHierarchy", new { id = assetHierarchy.Id }, assetHierarchy);
        }

        // DELETE: api/AssetHierarchies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AssetHierarchy>> DeleteAssetHierarchy(int id)
        {
            var assetHierarchy = await _context.AssetHierarchy.FindAsync(id);
            if (assetHierarchy == null)
            {
                return NotFound();
            }

            _context.AssetHierarchy.Remove(assetHierarchy);
            await _context.SaveChangesAsync();

            return assetHierarchy;
        }

        private bool AssetHierarchyExists(int id)
        {
            return _context.AssetHierarchy.Any(e => e.Id == id);
        }
    }
}