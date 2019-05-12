using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using LeBonAngle.Models;
using LeBonAngle.Services;
using LeBonAngle.Interfaces;
using LeBonAngle.DAL;

namespace LeBonAngle.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public INavigation NavigationService;
        public BaseViewModel(INavigation Navigation)
        {
            NavigationService = Navigation;
        }

        public IDataStore<Product> ProductDataStore => DependencyService.Get<IDataStore<Product>>() ?? new ProductDataStore();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
