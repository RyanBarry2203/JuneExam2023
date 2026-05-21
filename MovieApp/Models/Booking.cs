using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class Booking
    {

        // properties for the Booking class
        public int BookingID { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfTickets { get; set; }

        // foreign key for the Movie class
        public virtual int MovieID { get; set; }
        public virtual Movie Movie { get; set; }

        // constructor for the Booking class
        public Booking()
        {
            
        }

        // methods

        // overide ToString() method to display booking information
        public override string ToString()
        {
            return $"Booking ID: {BookingID}, Booking Date: {BookingDate}, Number of Tickets: {NumberOfTickets}";
        }
    }
}
