using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Learn_MVVM_1.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Learn_MVVM_1.MVVM;

namespace Learn_MVVM_1.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; set; }
        public RelayCommand AddCommand => new RelayCommand(execute => AddItem());
        public RelayCommand RemoveCommand => new RelayCommand(execute => RemoveItem(), canExecute => SelectedItem != null);
        public RelayCommand SaveCommand => new RelayCommand(execute => SaveItem(), canExecute => CanSave());

        private string _name;
        private string _ID;
        private int _quantity;
        private DateTime _createTime;
        public MainWindowViewModel(string name, string ID, int quantity, DateTime createTime)
        {
            _name = name;
            _ID = ID;
            _quantity = quantity;
            _createTime = createTime;

            Items = new ObservableCollection<Item>();
       
        }


        private Item selectedItem;


        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        #region Buttons Function
        private void AddItem()
        {
            Items.Add(new Item
            {
                Name = _name,
                ID = _ID,
                Quantity = _quantity,
                DateUpdate = _createTime
            });
        }

        private void RemoveItem()
        {
            var choosenData = SelectedItem;

            if(choosenData != null)
            {
                Items.Remove(choosenData);
            }
        }

        private void SaveItem()
        {
            // logic to save
        }

        private bool CanSave()
        {
            return true; // always can save
        }
        #endregion

    }
}
