using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Models;
using MovieApp.Data;    

namespace DataManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieData db = new MovieData();

            using (db)
            {
                //create a new movie
                var m1 = new Movie
                {
                    Title = "Inception",
                    Description = "A mind-bending thriller",
                    Cast = "Leonardo DiCaprio, Joseph Gordon-Levitt",
                    ImageName = "inception.jpg"
                };

                //add the movie to the database
                db.Movies.Add(m1);
                Console.WriteLine($"Added movie: {m1.Title}");

                //save the changes to the database
                db.SaveChanges();
                Console.WriteLine($"Saved changes for movie: {m1.Title}");

                //create a new booking for the movie
                var b1 = new Booking
                {
                    BookingDate = DateTime.Now,
                    NumberOfTickets = 2,
                    MovieID = m1.MovieID
                };

                //add the booking to the database
                db.Bookings.Add(b1);
                Console.WriteLine($"Added booking for movie: {m1.Title}");

                //save the changes to the database
                db.SaveChanges();
                Console.WriteLine($"Saved changes for booking: {b1.BookingID}");
            }
        }
    }
}
