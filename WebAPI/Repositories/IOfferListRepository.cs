using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IOfferListRepository
    {
        // public IEnumerable<OfferList> GetOfferList();

        public IEnumerable<AssetHierarchy> GetAssets();

        public IEnumerable<AssetHierarchy> GetAssets(int assetHierarchyId);

        public IEnumerable<LeasingDocument> GetOffers();

        public IEnumerable<Document> GetDocuments();

        //public Task<AssetHierarchy> PutAssetHierarchy(int id, AssetHierarchy assetHierarchy);

        //public Task<AssetHierarchy>  PostAssetHierarchy(AssetHierarchy assetHierarchy);

        //public Task<AssetHierarchy>  DeleteAssetHierarchy(int id);
    }
}