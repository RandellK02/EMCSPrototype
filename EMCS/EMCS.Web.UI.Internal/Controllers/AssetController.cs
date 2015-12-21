using EMCS.BusinessServices.Abstract;
using EMCS.Data.Abstract;
using EMCS.Data.DataModel;
using EMCS.Data.Repositories;
using EMCS.Web.Mvc.ViewModels.Assets;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EMCS.Web.UI.Internal.Controllers
{
    public class AssetController : Controller
    {
        private IAssetService assetService;
        private EMCSEntities db = new EMCSEntities();

        public AssetController(IAssetService assetService)
        {
            this.assetService = assetService;
        }

        // GET: Asset/Create
        public ActionResult Create()
        {
            AssetViewModel asset = new AssetViewModel
            {
                CategoryList = new SelectList( assetService.getAllCategories(), "ID", "Name" ),
                StatusList = new SelectList( assetService.getAllStatuses(), "ID", "Name" ),
                BrandList = new SelectList( assetService.getAllBrands(), "ID", "Name" ),
                ModelList = new SelectList( assetService.getAllModels(), "ID", "Name" )
            };
            return View( asset );
        }

        // POST: Asset/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind( Include = "ID,Tag,SerialNumber,CategoryID,CategoryList,StatusID,StatusList,BrandID,BrandList,ModelID,ModelList,PhoneNumber,IsArchived" )] AssetViewModel viewModel)
        {
            Asset asset = new Asset
            {
                ID = viewModel.ID,
                Tag = viewModel.Tag,
                CategoryID = viewModel.CategoryID,
                ModelID = viewModel.ModelID,
                BrandID = viewModel.BrandID,
                StatusID = viewModel.StatusID,
                SerialNumber = viewModel.SerialNumber,
                IsArchived = viewModel.IsArchived,
                PhoneNumber = viewModel.PhoneNumber
            };
            if ( ModelState.IsValid )
            {
                assetService.Save( asset );
                return RedirectToAction( "Index" );
            }

            return View( viewModel );
        }

        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory([Bind( Include = "ID,Description,Name,DisplayOrder" )] AssetCategory assetCategory)
        {
            if ( ModelState.IsValid )
            {
                int maxDisplayOrder = db.AssetCategories.Max( ac => ac.DisplayOrder );
                assetCategory.DisplayOrder = maxDisplayOrder++;
                db.AssetCategories.Add( assetCategory );
                db.SaveChanges();
                return RedirectToAction( "Create" );
            }

            return View( assetCategory );
        }

        // GET: Asset/Delete/5
        public ActionResult Delete(int? id)
        {
            if ( id == null )
            {
                return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
            }

            Asset asset = assetService.getByID( (int)id );
            AssetViewModel assetViewModel = new AssetViewModel
            {
                ID = asset.ID,
                Tag = asset.Tag,
                SerialNumber = asset.SerialNumber,
                IsArchived = asset.IsArchived,
                PhoneNumber = asset.PhoneNumber,
                Brand = asset.Brand.Name,
                Category = asset.AssetCategory.Name,
                Model = asset.Model.Name,
                Status = asset.AssetStatusSVT.Name
            };

            if ( asset == null )
            {
                return HttpNotFound();
            }
            return View( assetViewModel );
        }

        // POST: Asset/Delete/5
        [HttpPost, ActionName( "Delete" )]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind( Include = "ID" )]AssetViewModel viewModel)
        {
            Asset asset = assetService.getByID( viewModel.ID );
            assetService.delete( asset );
            return RedirectToAction( "Index" );
        }

        public ActionResult Details(int? id)
        {
            if ( id == null )
            {
                return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
            }
            Asset asset = assetService.getByID( (int)id );
            AssetViewModel assetViewModel = new AssetViewModel
            {
                ID = asset.ID,
                Tag = asset.Tag,
                PhoneNumber = asset.PhoneNumber,
                SerialNumber = asset.SerialNumber,
                IsArchived = asset.IsArchived,
                Status = asset.AssetStatusSVT.Name,
                Brand = asset.Brand.Name,
                Model = asset.Model.Name,
                Category = asset.AssetCategory.Name
            };

            if ( asset == null )
            {
                return HttpNotFound();
            }

            return View( assetViewModel );
        }

        // GET: Asset/Edit/5
        public ActionResult Edit(int? id)
        {
            if ( id == null )
            {
                return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
            }

            Asset asset = assetService.getByID( (int)id );
            AssetViewModel assetViewModel = new AssetViewModel
            {
                ID = asset.ID,
                Tag = asset.Tag,
                SerialNumber = asset.SerialNumber,
                IsArchived = asset.IsArchived,
                PhoneNumber = asset.PhoneNumber,
                BrandList = new SelectList( db.Brands, "ID", "Name" ),
                StatusList = new SelectList( db.AssetStatusSVTs, "ID", "Name" ),
                ModelList = new SelectList( db.Models, "ID", "Name" ),
                CategoryList = new SelectList( db.AssetCategories, "ID", "Name" ),
                CategoryID = asset.CategoryID,
                ModelID = asset.ModelID,
                BrandID = asset.BrandID,
                StatusID = asset.StatusID
            };

            if ( asset == null )
            {
                return HttpNotFound();
            }

            return View( assetViewModel );
        }

        // POST: Asset/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind( Include = "ID,Tag,SerialNumber,CategoryID,StatusID,BrandID,ModelID,PhoneNumber,IsArchived" )]AssetViewModel viewModel)
        {
            Asset asset = new Asset
            {
                ID = viewModel.ID,
                Tag = viewModel.Tag,
                CategoryID = viewModel.CategoryID,
                ModelID = viewModel.ModelID,
                BrandID = viewModel.BrandID,
                StatusID = viewModel.StatusID,
                SerialNumber = viewModel.SerialNumber,
                IsArchived = viewModel.IsArchived,
                PhoneNumber = viewModel.PhoneNumber
            };

            if ( ModelState.IsValid )
            {
                assetService.Update( asset );
                return RedirectToAction( "Index" );
            }

            return View( viewModel );
        }

        // GET: Asset
        public ActionResult Index()
        {
            return View( assetService.getAll() );
        }

        protected override void Dispose(bool disposing)
        {
            if ( disposing )
            {
                db.Dispose();
            }
            base.Dispose( disposing );
        }
    }
}