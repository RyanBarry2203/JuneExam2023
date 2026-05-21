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
        public MovieData() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OODExam_Movies_RyanBarry;Integrated Security=True;") { }
        public DbSet<Models.Movie> Movies { get; set; }
        public DbSet<Models.Booking> Bookings { get; set; }
    }
}
