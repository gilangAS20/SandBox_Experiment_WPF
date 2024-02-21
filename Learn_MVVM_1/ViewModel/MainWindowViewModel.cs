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
        public MainWindowViewModel()
        {
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
                Name = "NEW ITEM",
                ID = "XXX",
                Quantity = 0,
                DateUpdate = DateTime.Now
            });
        }

        private void RemoveItem()
        {

        }
        #endregion

    }
}
