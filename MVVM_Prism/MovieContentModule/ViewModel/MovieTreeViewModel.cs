using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Service;
using Prism.Events;
using Prism.Mvvm;
using System.Windows.Input;
using Prism.Commands;

namespace MovieContentModule.ViewModel
{
    public class MovieTreeViewModel : BindableBase, IMovieTreeViewModel
    {
        private ObservableCollection<Movie> _movieList;
        private Movie _selectedMovie;
        private IMovieService _movieService;
        IEventAggregator _eventAggregator;
        public ICommand DeleteCommand { get; set; }
        public ICommand MagicCommand { get; set; }
        public ICommand MagicCommand2 { get; set; }
        public bool DeleteEnabled;

        public MovieTreeViewModel(IMovieService movieService, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _movieService = movieService;

            //Get Movies
            _movieList = new ObservableCollection<Movie>(_movieService.Movies);//calls service to load movies
            _movieService.myEvent += _movieService_myEvent;//regular event
            //Load Commands
            LoadCommands();
            DeleteEnabled = true;
        }

        private void _movieService_myEvent()
        {
            Console.WriteLine("something changed in the model");
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
                OnPropertyChanged();
            }
        }

        public Movie SelectedMovie
        {
            set
            {
                _selectedMovie = value;
                OnPropertyChanged();
            }
            get
            {
                _eventAggregator.GetEvent<PubSubEvent<Movie>>().Publish(_selectedMovie);
                return _selectedMovie;
            }
        }

        private void LoadCommands()
        {
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
            MagicCommand = new DelegateCommand(Magic, CanDoMagic);
            //MagicCommand2 = new Command(Magic);
        }
        private void Delete()
        {
            if (SelectedMovie != null)
            {
                _movieService.DeleteMovie(_selectedMovie);
                Movies.Remove(_selectedMovie);
                Console.WriteLine("deleted successfully");
            }
        }
        private bool CanDelete()
        {
            return DeleteEnabled;
        }
        private void Magic()
        {
            var tmpMovieList = new ObservableCollection<Movie>();
            foreach (var m in Movies)
            {
                int begin = 0;
                int end = m.Title.Length - 1;
                char[] reverseString = m.Title.ToCharArray();

                while (begin < end)
                {
                    char tmp = reverseString[end];
                    reverseString[end] = reverseString[begin];
                    reverseString[begin] = tmp;
                    begin++;
                    end--;
                }
                string result = new string(reverseString);
                m.Title = result;//this updates the model!
                tmpMovieList.Add(m);
            }
            Movies = tmpMovieList;//this updates the view
            OnPropertyChanged(()=>SelectedMovie);//Alert SelectedMovie that the ObservableList has been updated!
        }
        private bool CanDoMagic()
        {
            return true;
        }

    }
}
