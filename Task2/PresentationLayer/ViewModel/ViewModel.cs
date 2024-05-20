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
    public class ViewModel<T> : INotifyPropertyChanged where T : new()
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public RelayCommand CreateCommand => new RelayCommand(execute => Create());
        public RelayCommand UpdateCommand => new RelayCommand(execute => Update());
        public RelayCommand DeleteCommand => new RelayCommand(execute => Delete());

        public ObservableCollection<T> Items { get; set; } = new ObservableCollection<T>();

        private T selectedItem = new();
        public T SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public virtual void Create()
        {
            Items.Add(new T());
        }

        public virtual void Update()
        {
            
        }

        public virtual void Delete()
        {
            System.Console.WriteLine("Item deleted");
        }
    }
}
