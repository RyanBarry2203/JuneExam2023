using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MovieApp.Data
{
    public class MovieData : DbContext
    {
        public MovieData() : base("name=OODExam_RyanBarry"){ }
        public DbSet<Models.Movie> Movies { get; set; }
        public DbSet<Models.Booking> Bookings { get; set; }
    }
}
