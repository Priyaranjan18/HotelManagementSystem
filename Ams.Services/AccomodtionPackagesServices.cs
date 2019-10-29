using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Entities;
using AMS.Data;
namespace Ams.Services
{
   public class AccomodtionPackagesServices
    {
        AmsContext context = new AmsContext();
        public IEnumerable<AccomodationPackage> GetAllAccomodationPackages()
        {

            return context.accomodationPackages.ToList(); ;
        }
        public IEnumerable<AccomodationPackage> SearchAccomodationPackages(string searchTerm)
        {

            var accomodationpackage = context.accomodationPackages.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                accomodationpackage = accomodationpackage.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }
            return accomodationpackage.ToList();
        }
        public AccomodationPackage GetAllAccomodationPackageById(int ID)
        {

            return context.accomodationPackages.Find(ID);
        }
         public bool SaveAccomodationPackage(AccomodationPackage accomodationpackage)
        {

            context.accomodationPackages.Add(accomodationpackage);
            return context.SaveChanges() > 0;

        }

        public bool UpdateAccomodationPackage(AccomodationPackage accomodationpackage)
        {

            context.Entry(accomodationpackage).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges() > 0;

        }

        public bool DeleteAccomodationPackage(AccomodationPackage accomodationpackage)
        {

            context.Entry(accomodationpackage).State = System.Data.Entity.EntityState.Deleted;
            return context.SaveChanges() > 0;

        }

    }
}
