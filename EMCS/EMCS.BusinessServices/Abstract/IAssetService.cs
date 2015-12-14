using EMCS.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMCS.BusinessServices.Abstract
{
    public interface IAssetService
    {
        IEnumerable<Asset> getAll();

        Asset getByID(int id);
    }
}