using EMCS.BusinessServices.Abstract;
using EMCS.Data.Abstract;
using EMCS.Data.DataModel;
using EMCS.Data.Repositories;
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
            ViewBag.CategoryID = new SelectList( db.AssetCategories, "ID", "Name" );
            ViewBag.StatusID = new SelectList( db.AssetStatusSVTs, "ID", "Name" );
            ViewBag.BrandID = new SelectList( db.Brands, "ID", "Name" );
            ViewBag.ModelID = new SelectList( db.Models, "ID", "Name" );
            return View();
        }

        // POST: Asset/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind( Include = "ID,SerialNumber,CategoryID,StatusID,BrandID,ModelID,PhoneNumber,IsArchived" )] Asset asset)
        {
            if ( ModelState.IsValid )
            {
                db.Assets.Add( asset );
                db.SaveChanges();
                return RedirectToAction( "Index" );
            }

            ViewBag.CategoryID = new SelectList( db.AssetCategories, "ID", "Description", asset.CategoryID );
            ViewBag.StatusID = new SelectList( db.AssetStatusSVTs, "ID", "Name", asset.StatusID );
            ViewBag.BrandID = new SelectList( db.Brands, "ID", "Name", asset.BrandID );
            ViewBag.ModelID = new SelectList( db.Models, "ID", "Name", asset.ModelID );
            return View( asset );
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
            Asset asset = db.Assets.Find( id );
            if ( asset == null )
            {
                return HttpNotFound();
            }
            return View( asset );
        }

        // POST: Asset/Delete/5
        [HttpPost, ActionName( "Delete" )]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asset asset = db.Assets.Find( id );
            db.Assets.Remove( asset );
            db.SaveChanges();
            return RedirectToAction( "Index" );
        }

        // GET: Asset/Details/5
        public ActionResult Details(int? id)
        {
            if ( id == null )
            {
                return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
            }
            Asset asset = assetService.getByID( (int)id );
            if ( asset == null )
            {
                return HttpNotFound();
            }
            return View( asset );
        }

        // GET: Asset/Edit/5
        public ActionResult Edit(int? id)
        {
            if ( id == null )
            {
                return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
            }
            Asset asset = db.Assets.Find( id );
            if ( asset == null )
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList( db.AssetCategories, "ID", "Name", asset.CategoryID );
            ViewBag.StatusID = new SelectList( db.AssetStatusSVTs, "ID", "Name", asset.StatusID );
            ViewBag.BrandID = new SelectList( db.Brands, "ID", "Name", asset.BrandID );
            ViewBag.ModelID = new SelectList( db.Models, "ID", "Name", asset.ModelID );
            return View( asset );
        }

        // POST: Asset/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind( Include = "ID,SerialNumber,CategoryID,StatusID,BrandID,ModelID,PhoneNumber,IsArchived" )] Asset asset)
        {
            if ( ModelState.IsValid )
            {
                db.Entry( asset ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction( "Index" );
            }
            ViewBag.CategoryID = new SelectList( db.AssetCategories, "ID", "Description", asset.CategoryID );
            ViewBag.StatusID = new SelectList( db.AssetStatusSVTs, "ID", "Name", asset.StatusID );
            ViewBag.BrandID = new SelectList( db.Brands, "ID", "Name", asset.BrandID );
            ViewBag.ModelID = new SelectList( db.Models, "ID", "Name", asset.ModelID );
            return View( asset );
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