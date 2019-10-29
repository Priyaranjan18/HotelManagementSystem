using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AMS.Entities;


namespace AMS.Data
{
    public class AmsContext : DbContext
    {
        public AmsContext() : base("AmsConnection")
        {

        }
        public DbSet<AccomodationType> accomodationTypes { get; set; }

        public DbSet<Accomodation> accomodation { get; set; }
        public DbSet<AccomodationPackage> accomodationPackages { get; set; }
        public DbSet<Booking> bookings { get; set; }

       // public System.Data.Entity.DbSet<AMS.Areas.DashBoard.Models.ViewModels.AccomodationPackageActionModels> AccomodationPackageActionModels { get; set; }
    }
}
