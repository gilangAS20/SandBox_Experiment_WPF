using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace DataBinding_INotifyPropertyChanged
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        private string boundText;

        public event PropertyChangedEventHandler PropertyChanged;

        public string BoundText
        {
            get { return boundText; }
            set
            {
                boundText = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BoundText"));
                OnPropertyChanged();
            }
        }

        private void ButtonSet_Click(object sender, RoutedEventArgs e)
        {
            BoundText = "Tombol Set telah diklik";
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
