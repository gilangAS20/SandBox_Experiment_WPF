using System;
using System.Collections;
using System.Collections.Generic;
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

namespace TestListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ListViewPeople.Items.Add(textEntry.Text);
            textEntry.Clear();
            textEntry.Focus();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            //int deleteIndex = ListViewPeople.SelectedIndex;
            //object deletedItem = ListViewPeople.SelectedItem;
            var deletedItems = ListViewPeople.SelectedItems;
            StringBuilder stringDeletedItems = new StringBuilder();
            foreach(var item in deletedItems)
            {
                stringDeletedItems.AppendLine("- " + item.ToString());
            }
            var confirmWindow = MessageBox.Show($"Do you want to delete the item(s)? \n\n{stringDeletedItems.ToString()}", "Delete Items", MessageBoxButton.YesNo);
            if(confirmWindow == MessageBoxResult.Yes)
            {
                var itemList = new ArrayList(deletedItems);
                foreach(var item in itemList)
                {
                    ListViewPeople.Items.Remove(item);
                }
            }
            //ListViewPeople.Items.RemoveAt(deletedItem);
        }

        private void BtnClearAll_Click(object sender, RoutedEventArgs e)
        {
            ListViewPeople.Items.Clear();
        }
    }
}
