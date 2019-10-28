using AMS.Data;
using AMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ams.Services
{
   public class AccomodationTypesService
    {
        AmsContext context = new AmsContext();
        public IEnumerable<AccomodationType> GetAllAccomodationType()
        {
           
            return context.accomodationTypes.ToList();
        }
        public IEnumerable<AccomodationType> SearchAccomodationType(string searchTerm)
        {

            var accomodationtype = context.accomodationTypes.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                  accomodationtype= accomodationtype.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }
            return accomodationtype.ToList();
        } 
        public AccomodationType GetAllAccomodationTypeById(int ID)
        {
        
            return context.accomodationTypes.Find(ID);
        }



        public bool SaveAccomodationType(AccomodationType accomodation)
        {
           
            context.accomodationTypes.Add(accomodation);
            return context.SaveChanges() > 0;
            
        }

        public bool UpdateAccomodationType(AccomodationType accomodationType)
        {

            context.Entry(accomodationType).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges() > 0;

        }

        public bool DeleteAccomodationType(AccomodationType accomodationType)
        {
           
            context.Entry(accomodationType).State = System.Data.Entity.EntityState.Deleted;
            return context.SaveChanges() > 0;

        }
    }
}
