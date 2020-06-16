using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public enum AssetType
    {
        AssetType =  -1,
        CarMake = -2,
        CarModel = -3,
        CarVersion = -4
    }

    public class OfferListRepository : IOfferListRepository
    {
        protected readonly LeasingDbContext _context;

        public OfferListRepository(LeasingDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AssetHierarchy> GetAssets()
        {
            return _context.AssetHierarchy.ToList();
        }

        public IEnumerable<AssetHierarchy> GetAssets(int assetHierarchyId)
        {
            return _context.AssetHierarchy.Where(x => x.AssetHierarchyId == assetHierarchyId).ToList();
        }

        public Task<List<LeasingDocument>> GetOffers()
        {
            return _context.LeasingDocument
                .Include(l => l.Document).ThenInclude(m => m.DocumentDetail).ThenInclude(n => n.Item).ThenInclude(n => n.AssetHierarchy)
                .Include(l => l.Partner)
                .Include(l => l.Product)
                .Include(l => l.Currency)
                .ToListAsync();
        }

        public IEnumerable<LeasingDocument> GetOffer(int leasingDocumentId)
        {
            return _context.LeasingDocument
                 .Include(l => l.Document).ThenInclude(m => m.DocumentDetail).ThenInclude(n => n.Item).ThenInclude(n => n.AssetHierarchy)
                .Include(l => l.Partner)
                .Include(l => l.Product)
                .Include(l => l.Currency)
                .Where(l => l.LeasingDocumentId == leasingDocumentId)
                .ToList();
        }

        public IEnumerable<Document> GetDocuments()
        {
            return _context.Document.ToList();
        }

         public IEnumerable<AssetHierarchy> GetAssetTypes()
        {
            return _context.AssetHierarchy.Where(x=>x.TypeId == (int?)AssetType.AssetType).ToList();
        }

        public IEnumerable<AssetHierarchy> GetCarMakes()
        {
            return _context.AssetHierarchy.Where(x => x.TypeId == (int?)AssetType.CarMake).ToList();
        }

        public IEnumerable<AssetHierarchy> GetCarModels()
        {
            return _context.AssetHierarchy.ToList();
        }

        public IEnumerable<AssetHierarchy> GetCarVersions()
        {
            return _context.AssetHierarchy.Where(x => x.TypeId == (int?)AssetType.CarVersion).ToList();
        }

        public IEnumerable<AssetHierarchy> GetAsset(int assetHierarchyId)
        {
            //var asset = from q in _context.AssetHierarchy
            //            where q.AssetHierarchyId == assetHierarchyId
            //            select new
            //            {
            //                AssetHierarchy = q.
            //            };



            //return _context.AssetHierarchy
            //    .Include(l=>l.CarMake)
            //    .ToList();
            return null;
        }

    }


}