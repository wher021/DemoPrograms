using Prism.Unity;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using System;
using Prism.Modularity;


namespace MovieClient
{
    public class Bootstrapper : UnityBootstrapper 
    {
        private const string ModuleDirectory = "./Modules";
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog { ModulePath = ModuleDirectory };
        }
        /*
        protected override void ConfigureModuleCatalog()
        {
            
            //Type clientMovieModule = typeof(ClientMovieModule);
            Type movieContentModule = typeof(ContentModule);
            ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = movieContentModule.Name,
                ModuleType = movieContentModule.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable,
            });
            
            Type movieDetailsModule = typeof(DetailsModule);
            ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = movieDetailsModule.Name,
                ModuleType = movieDetailsModule.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable,
            });
        }
        */
    }
}
