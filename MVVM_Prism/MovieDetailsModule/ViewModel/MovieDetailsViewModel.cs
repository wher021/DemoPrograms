using Model;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDetailsModule.ViewModel
{
    public class MovieDetailsViewModel : BindableBase, IMovieDetailsViewModel
    {
        public Movie _selectedMove;
        public IEventAggregator _eventAggregator;

        public MovieDetailsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<PubSubEvent<Movie>>().Subscribe(EditMovie);
        }

        private void EditMovie(Movie payload)
        {
            SelectedMovie = payload;
        }
        public Movie SelectedMovie
        {
            get
            {
                return _selectedMove;
            }
            set
            {
                _selectedMove = value;
                OnPropertyChanged();
            }
        }
    }
}
