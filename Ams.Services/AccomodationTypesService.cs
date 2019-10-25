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
        public IEnumerable<AccomodationType> GetAllAccomodationType()
        {
            var context = new AmsContext();
            return context.accomodationTypes.ToList();
        }

        public bool SaveAccomodationType(AccomodationType accomodation)
        {
            var context = new AmsContext();
            context.accomodationTypes.Add(accomodation);
            return context.SaveChanges() > 0;
            
        }
    }
}
