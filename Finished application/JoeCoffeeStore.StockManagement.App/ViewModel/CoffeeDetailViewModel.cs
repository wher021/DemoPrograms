using JoeCoffeeStore.StockManagement.App.Messages;
using JoeCoffeeStore.StockManagement.App.Services;
using JoeCoffeeStore.StockManagement.App.Utility;
using JoeCoffeeStore.StockManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JoeCoffeeStore.StockManagement.App.ViewModel
{
    public class CoffeeDetailViewModel : INotifyPropertyChanged, ICoffeeDetailViewModel
    {
        private IDialogService dialogService;
        private ICoffeeDataService coffeeDataService;

        private Coffee selectedCoffee;
        public Coffee SelectedCoffee 
        {
            get
            {
                return selectedCoffee;
            }
            set
            {
                selectedCoffee = value;
                RaisePropertyChanged("SelectedCoffee");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public CoffeeDetailViewModel(ICoffeeDataService coffeeDataService, IDialogService dialogService)
        {
            this.coffeeDataService = coffeeDataService;
            this.dialogService = dialogService;

            Messenger.Default.Register<Coffee>(this, OnCoffeeReceived);

            SaveCommand = new CustomCommand(SaveCoffee, CanSaveCoffee);
            DeleteCommand = new CustomCommand(DeleteCoffee, CanDeleteCoffee);
        }

        private bool CanDeleteCoffee(object obj)
        {
            return true;
        }

        private void DeleteCoffee(object coffee)
        {
            coffeeDataService.DeleteCoffee(selectedCoffee);

            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }

        private bool CanSaveCoffee(object obj)
        {
            return true;
        }

        private void SaveCoffee(object coffee)
        {
            coffeeDataService.UpdateCoffee(selectedCoffee);

            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }

        private void OnCoffeeReceived(Coffee coffee)
        {
            SelectedCoffee = coffee;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
