using System;
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

namespace Custom_Textbox_Control
{
    /// <summary>
    /// Interaction logic for ClearableTextBox.xaml
    /// </summary>
    public partial class ClearableTextBox : UserControl
    {

        public ClearableTextBox()
        {
            InitializeComponent();
        }

        private string placeHolder;

        public string Placeholder
        {
            get { return placeHolder; }
            set
            {
                placeHolder = value;
                tbPlaceHolder.Text = placeHolder;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textInput.Clear();
            textInput.Focus();
        }

        private void TextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbPlaceHolder.Visibility = string.IsNullOrEmpty(textInput.Text) ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
