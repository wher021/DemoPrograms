using System;
using System.Collections.Generic;
using Model;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Service
{
    public delegate void StartDelegate();
    public interface IMovieService
    {
        List<Movie> Movies { get; set; }
        void DeleteMovie(Movie movie);
        event EventHandler ModelChangedNotifier;

        event StartDelegate myEvent;
    }
}
