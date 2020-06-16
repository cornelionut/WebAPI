using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositories;

// Implementare CRUD operations (GET, POST, PUT, DELETE)
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IOfferListRepository _leasingRepository;

        // constructor cu instanta de LeasingDBContext pentru a face operatii cu (in) baza de date. Prin constructor vom primi datele si le vom asigna prin _context = context unde _context este o proprietate privata definita mai sus.
        // _context vine din DependencyInjection fiind asignat in Startup.cs

        public AssetController(IOfferListRepository leasingRepository)
        {
            _leasingRepository = leasingRepository;
        }

        // GET: api/AssetHierarchies
        [HttpGet("GetAsset")]
        public ActionResult<IEnumerable<AssetHierarchy>> GetAssetHierarchy()
        {
            return _leasingRepository.GetAssets().ToList();
        }

        // GET: api/AssetHierarchies/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<AssetHierarchy>> GetAssetHierarchy(int id)
        {
            var assetHierarchy = _leasingRepository.GetAsset(id).ToList();

            if (assetHierarchy == null)
            {
                return NotFound();
            }

            return assetHierarchy;
        }

        // GET: api/OfferList
        [HttpGet("GetOffer")]
        public async Task<ActionResult<List<LeasingDocument>>> GetOfferList()
        {
            return await _leasingRepository.GetOffers();
        }

        // GET: api/LeasingDocument
        [HttpGet("GetLeasingDocument/{leasingDocumentId}")]
        public ActionResult<IEnumerable<LeasingDocument>> GetOffer(int leasingDocumentId)
        {
            return _leasingRepository.GetOffer(leasingDocumentId).ToList();
        }

        // GET: api/Documents
        [HttpGet("GetDocument")]
        public ActionResult<IEnumerable<Document>> GetDocuments()
        {
            return _leasingRepository.GetDocuments().ToList();
        }

        // GET: api/Asset
        [HttpGet("GetAsset/{itemId}")]
        public ActionResult<IEnumerable<AssetHierarchy>> GetAsset(int assetHierarchyId)
        {
            return _leasingRepository.GetAsset(assetHierarchyId).ToList();
        }

        // GET: api/AssetType
        [HttpGet("GetAssetTypes")]
        public ActionResult<IEnumerable<AssetHierarchy>> GetAssetType()
        {
            return _leasingRepository.GetAssetTypes().ToList();
        }

        // GET: api/CarMake
        [HttpGet("GetCarMakes")]
        public ActionResult<IEnumerable<AssetHierarchy>> GetCarMake()
        {
            return _leasingRepository.GetCarMakes().ToList();
        }

        // GET: api/CarModels
        [HttpGet("GetCarModels")]
        public ActionResult<IEnumerable<AssetHierarchy>> GetCarModels()
        {
            return _leasingRepository.GetCarModels().ToList();
        }

        // GET: api/CarVersions
        [HttpGet("GetCarVersions")]
        public ActionResult<IEnumerable<AssetHierarchy>> GetCarVersions()
        {
            return _leasingRepository.GetCarVersions().ToList();
        }

        //// PUT: api/AssetHierarchies/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAssetHierarchy(int id, AssetHierarchy assetHierarchy)
        //{
        //    assetHierarchy.Id = id;

        //    _context.Entry(assetHierarchy).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AssetHierarchyExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent(); //nu returnez nimic cand fac update
        //}

        //// POST: api/AssetHierarchies
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<AssetHierarchy>> PostAssetHierarchy(AssetHierarchy assetHierarchy)
        //{
        //    _context.AssetHierarchy.Add(assetHierarchy);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAssetHierarchy", new { id = assetHierarchy.Id }, assetHierarchy);
        //}

        //// DELETE: api/AssetHierarchies/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<AssetHierarchy>> DeleteAssetHierarchy(int id)
        //{
        //    var assetHierarchy = await _context.AssetHierarchy.FindAsync(id);
        //    if (assetHierarchy == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.AssetHierarchy.Remove(assetHierarchy);
        //    await _context.SaveChangesAsync();

        //    return assetHierarchy;
        //}

        //private bool AssetHierarchyExists(int id)
        //{
        //    return _context.AssetHierarchy.Any(e => e.Id == id);
        //}
    }
}