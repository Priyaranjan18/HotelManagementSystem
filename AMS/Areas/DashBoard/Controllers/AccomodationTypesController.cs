using Ams.Services;
using AMS.Areas.DashBoard.Models.ViewModels;
using AMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AMS.Areas.DashBoard.Controllers
{
    public class AccomodationTypesController : Controller
    {
        #region
        AccomodationTypesService typesService = new AccomodationTypesService();

        // GET: DashBoard/AccomodationTypes
        public ActionResult Index(string searchTerm)
        {
            AccomodationTypeModels model = new AccomodationTypeModels();
            model.SearchTerm = searchTerm;
            model.accomodationTypes = typesService.SearchAccomodationType(searchTerm);
            return View(model);
        }
      
        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccomodationTypeActionModels accomodationTypeActionModels = new AccomodationTypeActionModels();
            if (ID.HasValue)
            {
                var accomodationtype = typesService.GetAllAccomodationTypeById(ID.Value);
                accomodationTypeActionModels.ID = accomodationtype.ID;
                accomodationTypeActionModels.Name = accomodationtype.Name;
                accomodationTypeActionModels.Description = accomodationtype.Description;
            }
            else
            {

            }

            return PartialView("_Action", accomodationTypeActionModels);
        }
        [HttpPost]
        public JsonResult Action(AccomodationTypeActionModels model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            if (model.ID > 0)
            {
                var accomodationtype = typesService.GetAllAccomodationTypeById(model.ID);
                accomodationtype.Name = model.Name;
                accomodationtype.Description = model.Description;
                 result = typesService.UpdateAccomodationType(accomodationtype);
            }

            else
            {
                AccomodationType accomodation = new AccomodationType();
                accomodation.Name = model.Name;
                accomodation.Description = model.Description;
                 result = typesService.SaveAccomodationType(accomodation);

            }

            if (result)
            {
                json.Data = new { success = true };
            }
            else
            {
                json.Data = new { success = false, message = "unable to perform Accomodation type" };


            }
            return json;

        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AccomodationTypeActionModels accomodationTypeActionModels = new AccomodationTypeActionModels();
            var accomodationtype = typesService.GetAllAccomodationTypeById(ID);
          accomodationTypeActionModels.ID = accomodationtype.ID ;
            return PartialView("_Delete", accomodationTypeActionModels);
        }
        [HttpPost]
        public JsonResult  Delete(AccomodationTypeActionModels model)
        {
            JsonResult json = new JsonResult();
            var accomodationtype = typesService.GetAllAccomodationTypeById(model.ID);
        
              var  result = typesService.DeleteAccomodationType(accomodationtype);

            if (result)
            {
                json.Data = new { success = true };
            }
            else
            {
                json.Data = new { success = false, message = "unable to perform Accomodation type" };


            }
            return json;

        }
        #endregion
    }
}