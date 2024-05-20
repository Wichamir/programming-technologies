using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModel
{
    public abstract class ViewModel<T> : INotifyPropertyChanged where T : Model.IModel, new()
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public RelayCommand AddCommand => new RelayCommand(execute => Add());
        public RelayCommand RemoveCommand => new RelayCommand(execute => Remove());
        public RelayCommand UpdateCommand => new RelayCommand(execute => Update());

        public ObservableCollection<T> Items { get; set; } = new ObservableCollection<T>();

        private T selectedItem;
        public T SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private IServiceApi serviceApi;

        public ViewModel()
        {
            serviceApi = IServiceApi.CreateDataService("");
        }

        public void Add()
        {
            var newItem = new T
            {
                ServiceApi = serviceApi
            };
            Items.Add(newItem);
        }

        public void Remove()
        {
            SelectedItem.Remove();
            Items.Remove(SelectedItem);
        }

        public void Update()
        {
            SelectedItem.Update();
        }
    }
}
