using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AMS.Entities;

namespace AMS.Areas.DashBoard.Models.ViewModels
{
    public class AccomodationPackageListingModel
    {
        public IEnumerable<AccomodationPackage> accomodationPackages { get; set; }
        public string SearchTerm { get; set; }
    }
    public class AccomodationPackageActionModels
    {
        public int ID { get; set; }
        public int AccomodationTypeID { get; set; }
        public AccomodationType accomodationType { get; set; }
        public string Name { get; set; }
        public string NoofRooms { get; set; }
        public decimal FeesperNight { get; set; }
        public IEnumerable<AccomodationType> accomodationTypes { get; set; }

    }
}