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
        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Item>();

            Items.Add(new Item
            {
                Name = "Oreo",
                ID = "0001",
                Quantity = 432,
                DateUpdate = DateTime.Now
            });

            Items.Add(new Item
            {
                Name = "Marimas",
                ID = "0002",
                Quantity = 43,
                DateUpdate = DateTime.Now
            });

            Items.Add(new Item
            {
                Name = "Buah Naga",
                ID = "0003",
                Quantity = 318,
                DateUpdate = DateTime.Now
            });
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



    }
}
