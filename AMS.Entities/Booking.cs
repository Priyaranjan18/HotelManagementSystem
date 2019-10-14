using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Entities
{
    public class Booking
    {
        public int ID { get; set; }
        public int AccomodationID { get; set; }
        public Accomodation accomodation { get; set;  }
        public DateTime CheckInDate{ get; set; }
        public int DuarationOfNights{ get; set; }
    }
}
