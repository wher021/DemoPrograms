using Microsoft.Practices.Unity;
using MovieContentModule.ViewModel;
using MovieContentModule.Views;
using Prism.Modularity;
using Prism.Regions;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieContentModule
{
    [Module(ModuleName = "ContentModule")]
    public class ContentModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _manager;
        public ContentModule(IUnityContainer container, IRegionManager manager)
        {
            _container = container;
            _manager = manager;
        }
        public void Initialize()
        {
            _container.RegisterType<IMovieTreeViewModel, MovieTreeViewModel>(new ContainerControlledLifetimeManager()); ;//register interface with viewmodel
            _container.RegisterType<IMovieService, MovieService>(new ContainerControlledLifetimeManager());//need to register all dependencies

            //When there are two Views that share the samve ViewModel then it is important that the LifeTimeManager is of Singleton = ContainerControlledLifetimeManager
            //Else the default is TransientLifetimeManager
            _manager.RegisterViewWithRegion("ControlView", typeof(ControlView));//register view with region
            _manager.RegisterViewWithRegion("ContentView", typeof(MovieTreeView));//register view with region
        }
    }
}
