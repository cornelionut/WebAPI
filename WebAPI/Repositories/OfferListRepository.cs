using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Repositories
{
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
            return _context.AssetHierarchy.Where(x => x.Id == assetHierarchyId).ToList();
        }

        public IEnumerable<LeasingDocument> GetOffers()
        {
            return _context.LeasingDocument
                .Include(l=>l.Document)
                .Include(l=>l.Partner)
                .Include(l=>l.Product)
                .Include(l=>l.Currency)
                .ToList();
        }

        public IEnumerable<Document> GetDocuments()
        {
            return _context.Document.ToList();
        }
    }
}