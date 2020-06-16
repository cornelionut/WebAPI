using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IOfferListRepository
    {
        public IEnumerable<AssetHierarchy> GetAssets();

        public IEnumerable<AssetHierarchy> GetAsset(int assetHierarchyId);

        public IEnumerable<AssetHierarchy> GetAssetTypes();

        public IEnumerable<AssetHierarchy> GetCarMakes();

        public IEnumerable<AssetHierarchy> GetCarModels();

        public IEnumerable<AssetHierarchy> GetCarVersions();

        public Task<List<LeasingDocument>> GetOffers();

        public IEnumerable<LeasingDocument> GetOffer(int leasingDocumentId);

        public IEnumerable<Document> GetDocuments();

        // public IEnumerable<OfferList> GetOfferList();

        //public Task<AssetHierarchy> PutAssetHierarchy(int id, AssetHierarchy assetHierarchy);

        //public Task<AssetHierarchy>  PostAssetHierarchy(AssetHierarchy assetHierarchy);

        //public Task<AssetHierarchy>  DeleteAssetHierarchy(int id);
    }
}