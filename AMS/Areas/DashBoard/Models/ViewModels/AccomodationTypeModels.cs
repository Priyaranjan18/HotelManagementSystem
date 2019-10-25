using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AMS.Entities;

namespace AMS.Areas.DashBoard.Models.ViewModels
{
    public class AccomodationTypeModels
    {
        public IEnumerable<AccomodationType> accomodationTypes { get; set; }
    }
    public class AccomodationTypeActionModels
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
