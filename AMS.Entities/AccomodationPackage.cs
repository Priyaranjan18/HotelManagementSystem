using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Entities
{
   public  class AccomodationPackage
    {
        public int ID { get; set; }
        public int AccomodationTypeID{ get; set; }
        public AccomodationType accomodationType { get; set; }
        public string Name { get; set; }
        public string NoofRooms { get; set; }
        public decimal FeesperNight { get; set; }

    }
}
