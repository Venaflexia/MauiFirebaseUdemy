using MauiFirebase.mvvm.Models;
using MauiFirebase.mvvm.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiFirebase.mvvm.ViewModels
{
    class NotLisVm
    {
        public ICommand CmdSelection { get; set; }
        public NotOzellikleri SelectedItem { get; set; }
        public NotLisVm()
        {
            CmdSelection = new Command(SelectionChanged);
        }

        private async void SelectionChanged(object obj)
        {
          await Application.Current.MainPage.Navigation.PushAsync(new SelectedItemPage() { BindingContext=SelectedItem});
        }
    }
}
