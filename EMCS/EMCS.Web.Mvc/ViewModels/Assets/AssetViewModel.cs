using EMCS.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EMCS.Web.Mvc.ViewModels.Assets
{
    public class AssetViewModel
    {
        public String Brand { get; set; }
        public int BrandID { get; set; }
        public SelectList BrandList { get; set; }
        public String Category { get; set; }
        public int CategoryID { get; set; }
        public SelectList CategoryList { get; set; }
        public int ID { get; set; }
        public bool IsArchived { get; set; }
        public String Model { get; set; }
        public int ModelID { get; set; }
        public SelectList ModelList { get; set; }
        public String PhoneNumber { get; set; }
        public String SerialNumber { get; set; }
        public String Status { get; set; }
        public int StatusID { get; set; }
        public SelectList StatusList { get; set; }
        public int Tag { get; set; }
    }
}