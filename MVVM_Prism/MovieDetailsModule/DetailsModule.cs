using Microsoft.Practices.Unity;
using MovieDetailsModule.ViewModel;
using MovieDetailsModule.Views;
using Prism.Modularity;
using Prism.Regions;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDetailsModule
{
    [Module(ModuleName = "DetailsModule")]
    public class DetailsModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _manager;
        public DetailsModule(IUnityContainer container, IRegionManager manager)
        {
            _container = container;
            _manager = manager;
        }

        public void Initialize()
        {
            _container.RegisterType<IMovieDetailsViewModel, MovieDetailsViewModel>(new ContainerControlledLifetimeManager()); ;//register interface with viewmodel
            _container.RegisterType<IMovieService, MovieService>(new ContainerControlledLifetimeManager());//need to register all dependencies
            _manager.RegisterViewWithRegion("MovieView", typeof(MovieDetailsView));//register view with region
        }
    }
}
