using EMCS.BusinessServices.Abstract;
using EMCS.Data.Abstract;
using EMCS.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMCS.BusinessServices
{
    public class AssetService : IAssetService
    {
        private IEMCSRepositoryBase<Asset> assetRepository;
        private IEMCSRepositoryBase<Brand> brandRepository;
        private IEMCSRepositoryBase<AssetCategory> categoryRepository;
        private IEMCSRepositoryBase<Model> modelRepository;
        private IEMCSRepositoryBase<AssetStatusSVT> statusRepository;

        public AssetService(IEMCSRepositoryBase<Asset> assetRepository,
                            IEMCSRepositoryBase<Brand> brandRepository,
                            IEMCSRepositoryBase<Model> modelRepository,
                            IEMCSRepositoryBase<AssetStatusSVT> statusRepository,
                            IEMCSRepositoryBase<AssetCategory> categoryRepository)
        {
            this.assetRepository = assetRepository;
            this.brandRepository = brandRepository;
            this.modelRepository = modelRepository;
            this.statusRepository = statusRepository;
            this.categoryRepository = categoryRepository;
        }

        public void delete(Asset asset)
        {
            assetRepository.Delete( asset );
        }

        public IEnumerable<Asset> getAll()
        {
            return assetRepository.GetAll( a => a.AssetCategory, a => a.AssetStatusSVT, a => a.Brand, a => a.Model );
        }

        public IEnumerable<Brand> getAllBrands()
        {
            return brandRepository.GetAll();
        }

        public IEnumerable<AssetCategory> getAllCategories()
        {
            return categoryRepository.GetAll();
        }

        public IEnumerable<Model> getAllModels()
        {
            return modelRepository.GetAll();
        }

        public IEnumerable<AssetStatusSVT> getAllStatuses()
        {
            return statusRepository.GetAll();
        }

        public Asset getByID(int id)
        {
            return assetRepository.GetByID( id );
        }

        public void Save(Asset asset)
        {
            assetRepository.Save( asset );
        }

        public void Update(Asset asset)
        {
            assetRepository.Update( asset );
        }
    }
}