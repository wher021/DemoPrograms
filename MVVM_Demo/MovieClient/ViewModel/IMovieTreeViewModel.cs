using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MovieClient
{
    public interface IMovieTreeViewModel
    {
        ObservableCollection<Movie> Movies { get; }
        Movie SelectedMovie { get; set; }
        ICommand DeleteCommand { get; set; }
        ICommand SaveCommand { get; set; }
        ICommand MagicCommand { get; set; }
        event PropertyChangedEventHandler PropertyChanged;
    }
}
