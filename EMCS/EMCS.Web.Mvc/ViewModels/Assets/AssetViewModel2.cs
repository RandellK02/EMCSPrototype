using EMCS.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EMCS.Web.Mvc.ViewModels.Assets
{
    public class AssetViewModel2
    {
        private Asset asset;

        public Asset Asset
        {
            get
            {
                if ( asset == null )
                {
                    asset = new Asset();
                }

                return asset;
            }
            set { asset = value; }
        }

        public int BrandID { get { return asset.BrandID; } set { BrandID = value; } }

        public SelectList BrandList { get; set; }
        public int CategoryID { get { return asset.CategoryID; } set { CategoryID = value; } }
        public SelectList CategoryList { get; set; }
        public int ID { get { return asset.ID; } set { ID = value; } }
        public bool IsArchived { get { return asset.IsArchived; } set { IsArchived = value; } }
        public int ModelID { get { return asset.ModelID; } set { ModelID = value; } }
        public SelectList ModelList { get; set; }
        public String PhoneNumber { get { return asset.PhoneNumber; } set { PhoneNumber = value; } }
        public String SerialNumber { get { return asset.SerialNumber; } set { SerialNumber = value; } }
        public int StatusID { get { return asset.StatusID; } set { StatusID = value; } }
        public SelectList StatusList { get; set; }
    }
}