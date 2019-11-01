using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ams.Services;
using AMS.Areas.DashBoard.Models.ViewModels;
using AMS.ViewModels;
using AMS.Entities;


namespace AMS.Areas.DashBoard.Controllers
{
    public class AccomodationController : Controller
    {
        // GET: DashBoard/Accomodation


        #region

        AccomodationsService AccomodationsService = new AccomodationsService();
        AccomodtionPackagesServices AccomodtionPackagesServices = new AccomodtionPackagesServices();

        // public object accomodation { get; private set; }

        // GET: DashBoard/AccomodationTypes
        public ActionResult Index(string searchTerm, int? accomodationPackageID, int? page)
        {
            int recordSize = 3;
            page = page ?? 1;
            AccomodationsListingModel model = new AccomodationsListingModel();
            model.SearchTerm = searchTerm;
            model.AccomodationPackageID = accomodationPackageID;
            model.AccomodationPackages = AccomodtionPackagesServices.GetAllAccomodationPackages();
            model.Accomodations = AccomodationsService.SearchAccomodations(searchTerm, accomodationPackageID, page.Value, recordSize);

            var totalRecords = AccomodationsService.SearchAccomodationsCount(searchTerm, accomodationPackageID);

            model.Pager = new Pager(totalRecords, page, recordSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccomodationActionModel accomodationActionModel = new AccomodationActionModel();
            if (ID.HasValue)
            {
                var accomodation = AccomodationsService.GetAllAccomodationById(ID.Value);
                accomodationActionModel.ID = accomodation.ID;
                accomodationActionModel.AccomodationPackageID = accomodation.AccomodationPackageID;
                accomodationActionModel.Name = accomodation.Name;
                accomodationActionModel.Description = accomodation.Description;

            }
            accomodationActionModel.AccomodationPackages = AccomodtionPackagesServices.GetAllAccomodationPackages();

            return PartialView("_Action", accomodationActionModel);
        }

        [HttpPost]
        public JsonResult Action(AccomodationActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            if (model.ID > 0) //we are trying to edit a record
            {
                var accomodation = AccomodationsService.GetAllAccomodationById(model.ID);

                accomodation.AccomodationPackageID = model.AccomodationPackageID;
                accomodation.Name = model.Name;
                accomodation.Description = model.Description;

                result = AccomodationsService.UpdateAccomodation(accomodation);
            }
            else //we are trying to create a record
            {
                Accomodation accomodation = new Accomodation();

                accomodation.AccomodationPackageID = model.AccomodationPackageID;
                accomodation.Name = model.Name;
                accomodation.Description = model.Description;

                result = AccomodationsService.SaveAccomodation(accomodation);
            }

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Accomodation." };
            }

            return json;
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AccomodationActionModel model = new AccomodationActionModel();

            var accomodation = AccomodationsService.GetAllAccomodationById(ID);

            model.ID = accomodation.ID;

            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(AccomodationActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var accomodation = AccomodationsService.GetAllAccomodationById(model.ID);

            result = AccomodationsService.DeleteAccomodation(accomodation);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Accomodation." };
            }

            return json;
        }
        #endregion
    }
}

