using JoeCoffeeStore.StockManagement.App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JoeCoffeeStore.StockManagement.App.Services
{
    public class DialogService: IDialogService
    {
        Window coffeeDetailView = null;

        public void ShowDetailDialog()
        {
            coffeeDetailView = new CoffeeDetailView();
            coffeeDetailView.ShowDialog();
        }

        public void CloseDetailDialog()
        {
            if (coffeeDetailView != null)
                coffeeDetailView.Close();
        }
    }
}
