using System;
using System.Collections.Generic;
using Service;
using Model;
using System.Collections.ObjectModel;
using MovieClient.Extensions;
using System.ComponentModel;
using System.Windows.Input;
using MovieClient.Commands;

namespace MovieClient
{
    public class MovieTreeViewModel : IMovieTreeViewModel, INotifyPropertyChanged
    {
        public ICommand DeleteCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand MagicCommand { get; set; }

        private Movie _selectedMovie;
        private IMovieService _movieService;
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Movie> _movieList;

        public MovieTreeViewModel(IMovieService movieRepository)
        {
            _movieService = movieRepository;
            LoadCommands();
            _movieService.ModelChangedNotifier += _movieService_ModelChangedHandler;
            _movieService.myEvent += _movieService_myEventHandler;
            _movieList = new ObservableCollection<Movie>(_movieService.Movies);
        }

        private void _movieService_myEventHandler()
        {
            Console.WriteLine("something changed in the Model 2");
        }

        private void _movieService_ModelChangedHandler(object sender, EventArgs e)
        {
            Console.WriteLine("something changed in the Model");
        }

		public ObservableCollection<Movie> Movies
        {
		    get
		    {
		        return _movieList;
		    }
            set
            {
                _movieList = value;
                RaisePropertyChanged("Movies");
            }
        }

        public Movie SelectedMovie
        {
            get
            {
                return _selectedMovie;
            }

            set
            {
                _selectedMovie = value;
                RaisePropertyChanged("SelectedMovie");
            }
        }

        public void LoadCommands()
        {
            DeleteCommand = new Command(DeleteMovie);
            SaveCommand = new Command(SaveMovie);
            MagicCommand = new Command(Magic);
        }
        private void DeleteMovie()
        {
            if(_selectedMovie != null)
            {
                _movieService.DeleteMovie(_selectedMovie);
                Movies.Remove(_selectedMovie);
                //make another call to delete from view
                Console.WriteLine("deleted successfully");
            }
        }

        private void SaveMovie()//not used
        {
            if (_selectedMovie != null)
            {
                Console.WriteLine("saved successfully");
            }
        }
        private void Magic()
        {
            foreach(var m in _movieService.Movies)
            {
                int begin = 0;
                int end = m.Title.Length-1;
                char []reverseString = m.Title.ToCharArray();

                while(begin<end)
                {
                    char tmp = reverseString[end];
                    reverseString[end] = reverseString[begin];
                    reverseString[begin] = tmp;
                    begin++;
                    end--;
                }
                string result = new string(reverseString);
                m.Title = result;
                RaisePropertyChanged("Movies");
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
