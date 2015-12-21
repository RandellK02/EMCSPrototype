using EMCS.Data.DataModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMCS.BusinessServices.Abstract
{
    public interface IAssetService
    {
        void delete(Asset asset);

        IEnumerable<Asset> getAll();

        IEnumerable<Brand> getAllBrands();

        IEnumerable<AssetCategory> getAllCategories();

        IEnumerable<Model> getAllModels();

        IEnumerable<AssetStatusSVT> getAllStatuses();

        Asset getByID(int id);

        void Save(Asset asset);

        void Update(Asset asset);
    }
}