using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Data;
using AMS.Entities;

namespace Ams.Services
{
      public    class AccomodationsService
    {
       
            AmsContext context = new AmsContext();
            public IEnumerable<Accomodation> GetAllAccomodations()
            {

                return context.accomodation.ToList(); ;
            }
            public IEnumerable<Accomodation> SearchAccomodations(string searchTerm, int? accomodationPackageID, int page, int recordSize)
            {

                var accomodations = context.accomodation.AsQueryable();
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    accomodations = accomodations.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
                }
                if (accomodationPackageID.HasValue && accomodationPackageID.Value > 0)
                {
                    accomodations = accomodations.Where(a => a.AccomodationPackageID == accomodationPackageID.Value);
                }
                var skip = (page - 1) * recordSize;
                //(1-1)*3=0
                //(2-1)*3=3
                //(3-1)*3=6

                return accomodations.OrderBy(n => n.AccomodationPackageID).Skip(skip).Take(recordSize).ToList();
            }

            public int SearchAccomodationsCount(string searchTerm, int? accomodationPackageID)
            {

                var accomodations = context.accomodation.AsQueryable();
                if (!string.IsNullOrEmpty(searchTerm))
                {
                   accomodations = accomodations.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
                }
                if (accomodationPackageID.HasValue && accomodationPackageID.Value > 0)
                {
                    accomodations= accomodations.Where(a => a.AccomodationPackageID== accomodationPackageID.Value);
                }

                return accomodations.Count();
            }

            public Accomodation GetAllAccomodationById(int ID)
            {

                return context.accomodation.Find(ID);
            }
            public bool SaveAccomodation(Accomodation accomodations)
            {

                context.accomodation.Add(accomodations);
                return context.SaveChanges() > 0;

            }

            public bool UpdateAccomodation(Accomodation accomodation)
            {

                context.Entry(accomodation).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges() > 0;

            }

            public bool DeleteAccomodation(Accomodation accomodation)
            {

                context.Entry(accomodation).State = System.Data.Entity.EntityState.Deleted;
                return context.SaveChanges() > 0;

            }

        }
    }


