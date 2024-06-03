using Service;
using System.Collections.ObjectModel;
using System.ComponentModel;

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
        }

        public ViewModel(IServiceApi serviceApi)
        {
            this.serviceApi = serviceApi;
        }

        public void Add()
        {
            var newItem = new T()
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
