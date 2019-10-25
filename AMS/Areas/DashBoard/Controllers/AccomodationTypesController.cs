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
        AccomodationTypesService typesService = new AccomodationTypesService();

        // GET: DashBoard/AccomodationTypes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listing()
        {
            AccomodationTypeModels model = new AccomodationTypeModels();
            model.accomodationTypes = typesService.GetAllAccomodationType();
            return PartialView("_Listing", model);
        }
        [HttpGet]
        public ActionResult Action()
        {
            AccomodationTypeActionModels accomodationTypeActionModels = new AccomodationTypeActionModels();

            return PartialView("_Action", accomodationTypeActionModels);
        }
        [HttpPost]
        public JsonResult Action(AccomodationTypeActionModels model)
        {
            JsonResult json = new JsonResult();
            AccomodationType accomodationType = new AccomodationType();
            accomodationType.Name = model.Name;
            accomodationType.Description = model.Description;
            var res = typesService.SaveAccomodationType(accomodationType);

            if (res)
            {
                json.Data = new { success = true };
            }
            else
            {
                json.Data = new { success = false, message = "unable to add Accomodation type" };


            }
            return json;
        }
    }
}
