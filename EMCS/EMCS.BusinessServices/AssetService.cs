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
        private IEMCSRepositoryBase<Asset> repository;

        public AssetService(IEMCSRepositoryBase<Asset> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Asset> getAll()
        {
            return repository.GetAll( a => a.AssetCategory, a => a.AssetStatusSVT, a => a.Brand, a => a.Model );
        }

        public Asset getByID(int id)
        {
            return repository.GetByID( id );
        }
    }
}