using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestListView_ObservableCollection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = this;
            dataInput = new ObservableCollection<string>();
            InitializeComponent();
        }

        private ObservableCollection<string> dataInput;

        public ObservableCollection<string> DataInput
        {
            get { return dataInput; }   
            set { dataInput = value; }
        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            dataInput.Add(textEntry.Text);
            textEntry.Clear();
            textEntry.Focus();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ListViewPeople.SelectedItems;
            var itemList = new ArrayList(selectedItem);
            StringBuilder listDeletedItems = new StringBuilder();
            foreach(var item in itemList)
            {
                listDeletedItems.AppendLine("- " + (string)item);
            }

            var deleteData = MessageBox.Show($"Are you sure delete the data? \n{listDeletedItems}", "Delete The Data", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(deleteData == MessageBoxResult.Yes)
            {

                foreach(var item in itemList)
                {
                    DataInput.Remove((string)item);
                }
            }
        }

        private void BtnClearAll_Click(object sender, RoutedEventArgs e)
        {
            var deleteAllData = MessageBox.Show("Are you sure want to delete all data?", "Delete All Data", MessageBoxButton.YesNo);
            if(deleteAllData == MessageBoxResult.Yes)
            {
                dataInput.Clear();
            }
        }
    }
}
