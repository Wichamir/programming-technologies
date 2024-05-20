using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModel
{
    class ViewModel<T> : INotifyPropertyChanged
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

        public void Create()
        {
            System.Console.WriteLine("Item created");
        }

        public void Update()
        {
            System.Console.WriteLine("Item updated");
        }

        public void Delete()
        {
            System.Console.WriteLine("Item deleted");
        }
    }
}
