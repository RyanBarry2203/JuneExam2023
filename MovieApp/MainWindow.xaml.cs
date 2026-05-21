using MovieApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MovieApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MovieData db;
        private int availableSeats = 100;
        private int availableSeatsForSelectedMovie = 100;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new MovieData();

            using (db)
            {
                var movies = db.Movies.ToList();
                lbxMovies.ItemsSource = movies;
            }

            txtAvailableSeats.Text = availableSeats.ToString();
        }

        private void lbxMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedMovie = lbxMovies.SelectedItem as Models.Movie;

            if (selectedMovie != null)
            {
                txtSynopsis.Text = $"Description: {selectedMovie.Description}\nCast: {selectedMovie.Cast}";
            }
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            // get selected movie, date and required seats from screen, create a new booking and save to database

            db = new MovieData();

            var selectedMovie = lbxMovies.SelectedItem as Models.Movie;
            var selectedDate = dtpQuickBook.SelectedDate;
            var requiredSeats = int.Parse(txtRequiredSeats.Text);

            if (selectedMovie != null && selectedDate != null && requiredSeats > 0 && requiredSeats <= availableSeatsForSelectedMovie)
            {
                var booking = new Models.Booking
                {
                    MovieID = selectedMovie.MovieID,
                    BookingDate = selectedDate.Value,
                    NumberOfTickets = requiredSeats
                };

                using (db)
                {
                    db.Bookings.Add(booking);
                    db.SaveChanges();
                }

                MessageBox.Show("Booking successful!");

                // update available seats
                availableSeats -= requiredSeats;
                txtAvailableSeats.Text = availableSeats.ToString();
            }
            else
            {
                MessageBox.Show("Sold Out!");
            }
        }
    }
}
