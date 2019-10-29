using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ams.Services;
using AMS.Areas.DashBoard.Models.ViewModels;
using AMS.Entities;
using AMS.ViewModels;

namespace AMS.Areas.DashBoard.Controllers
{
    public class AccomodationPackagesController : Controller
    {
        #region

        AccomodtionPackagesServices PackagesServices = new AccomodtionPackagesServices();
        AccomodationTypesService typesService = new AccomodationTypesService();

        public object accomodation { get; private set; }

        // GET: DashBoard/AccomodationTypes
        public ActionResult Index(string searchTerm,int? accomodationTypeID,int? page)
        {
            int recordSize = 3;
            page = page ?? 1;
            AccomodationPackageListingModel model = new AccomodationPackageListingModel();
            model.SearchTerm = searchTerm;
            model.AccomodationTypeID = accomodationTypeID;
            model.accomodationPackages = PackagesServices.SearchAccomodationPackages(searchTerm, accomodationTypeID,page.Value,recordSize);
            model.accomodationTypes = typesService.GetAllAccomodationType();
            model.pagers = new Pager(9,page,recordSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccomodationPackageActionModels packageActionModels = new AccomodationPackageActionModels();
            if (ID.HasValue)
            {
                var accomodationpackage = PackagesServices.GetAllAccomodationPackageById(ID.Value);
                packageActionModels.ID = accomodationpackage.ID;
                packageActionModels.AccomodationTypeID = accomodationpackage.AccomodationTypeID;
                packageActionModels.Name = accomodationpackage.Name;
                packageActionModels.NoofRooms = accomodationpackage.NoofRooms;
                packageActionModels.FeesperNight = accomodationpackage.FeesperNight;
            }
            packageActionModels.accomodationTypes = typesService.GetAllAccomodationType();

            return PartialView("_Action", packageActionModels);
        }
        [HttpPost]
        public JsonResult Action(AccomodationPackageActionModels model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            if (model.ID > 0)//Edit
            {
                
                var accomodationpackage = PackagesServices.GetAllAccomodationPackageById(model.ID);
                accomodationpackage.AccomodationTypeID = model.AccomodationTypeID;
               accomodationpackage.Name = model.Name;
               accomodationpackage.NoofRooms = model.NoofRooms;
                accomodationpackage.FeesperNight= model.FeesperNight;
                result = PackagesServices.UpdateAccomodationPackage(accomodationpackage);
            }

            else//Create
            {
                AccomodationPackage accomodationpackage = new AccomodationPackage();
                accomodationpackage.AccomodationTypeID = model.AccomodationTypeID;
                accomodationpackage.Name = model.Name;
                accomodationpackage.NoofRooms = model.NoofRooms;
                accomodationpackage.FeesperNight = model.FeesperNight;
                result = PackagesServices.SaveAccomodationPackage(accomodationpackage);

            }

            if (result)
            {
                json.Data = new { success = true };
            }
            else
            {
                json.Data = new { success = false, message = "unable to perform Accomodation packages" };


            }
            return json;

        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
           AccomodationPackageActionModels accomodationPackageAction = new AccomodationPackageActionModels();
            var accomodationpackage = PackagesServices.GetAllAccomodationPackageById(ID);
            accomodationPackageAction.ID = accomodationpackage.ID;
            return PartialView("_Delete", accomodationPackageAction);
        }
        [HttpPost]
        public JsonResult Delete( AccomodationPackageActionModels model)
        {
            JsonResult json = new JsonResult();
           
            var accomodationPackage =PackagesServices.GetAllAccomodationPackageById(model.ID);
           var result = false;
           result = PackagesServices.DeleteAccomodationPackage(accomodationPackage);

            if (result)
            {
                json.Data = new { success = true };
            }
            else
            {
                json.Data = new { success = false, message = "unable to perform Accomodation package" };


            }
            return json;

        }
        #endregion
    }

}