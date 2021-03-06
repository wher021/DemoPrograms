﻿using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieContentModule.ViewModel
{
    public interface IMovieTreeViewModel
    {
        ObservableCollection<Movie> Movies { get; }
    }
}
