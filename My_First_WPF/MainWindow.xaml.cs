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

namespace My_First_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isProgramOn = false;

        public MainWindow()
        {
            InitializeComponent();
            ProgramStatus.Text = "program is off";
        }

        private void ButtonSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (!isProgramOn)
            {
                RunProgram();
            }
            else
            {
                StopProgram();
            }
        }

        private void StopProgram()
        {
            ProgramStatus.Text = "program is off";
            ButtonSwitch.Content = "Run";
            isProgramOn = false;
        }

        private void RunProgram()
        {
            ProgramStatus.Text = "progam is on";
            ButtonSwitch.Content = "Stop";
            isProgramOn = true;
        }
    }
}
