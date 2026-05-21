using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class Movie
    {
        //properties for the Movie class
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public string Cast { get; set; }

        // foreign key for the Booking class
        public virtual List<Booking> Bookings { get; set; }

        // cosntructor for the Movie class
        public Movie()
        {
            Bookings = new List<Booking>();
        }

        // methods
        public override string ToString()
        {
            return $"Movie ID: {MovieID}, Title: {Title}, Description: {Description}, Cast: {Cast}";
        }
    }
}
