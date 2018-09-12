using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model;
using System.ComponentModel;
using System;
using Prism.Events;

namespace Service
{
    public class MovieService : IMovieService
    {
        IEventAggregator _eventAggregator;
        private List<Movie> _movies;

        public MovieService(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
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

            // Broadcast Prism Event
            _eventAggregator.GetEvent<PubSubEvent<string>>().Publish("Hi 3");
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
    public class PrismMessage 
    {
        public string PayLoad { get; set; }
    }
}
