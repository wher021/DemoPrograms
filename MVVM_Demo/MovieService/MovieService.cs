using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model;
using System.ComponentModel;
using System;

namespace Service
{
    public class MovieService : IMovieService//remove INOTIFYPropertychanged as not part of MVVM here
    {
        private List<Movie> _movies;//should I make this one static?

        public MovieService()
        {
            LoadMovies();
        }

        public List<Movie> Movies
        {
            set
            {
                _movies = value;
            }
            get
            {
                return _movies;
            }
        }
        public event EventHandler ModelChangedNotifier;

        private void OnModelChanged()
        {
            if(ModelChangedNotifier != null)
            {
                ModelChangedNotifier(this, EventArgs.Empty);
            }
        }

        //Delegate Method
        public event StartDelegate myEvent;

        public void DeleteMovie(Movie movie)
        {
            Movies.Remove(movie);
            OnModelChanged();
            myEvent();//fire custom event
        }

        private void LoadMovies()
        {
            _movies = new List<Movie>();
            var m1 = new Movie() {Title = "Gladiator"};
            var m2 = new Movie() {Title = "Starship Troopers"};
            _movies.Add(m1);
            _movies.Add(m2);
        }
    }
}
