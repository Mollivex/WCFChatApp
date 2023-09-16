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

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isConnected = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        void ConnectUser()
        {
            if (!isConnected)
            {
                tbUserName.IsEnabled = false;
                bConDiscon.Content = "Disconnect";
                isConnected = true;
            }
        }
        void DisconnectUser()
        {
            if (isConnected)
            {
                tbUserName.IsEnabled = true;
                bConDiscon.Content = "Connect";
                isConnected = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {
                DisconnectUser();
            }
            else
            {
                ConnectUser();
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) { }
        private void tbMessage_TextChanged(object sender, TextChangedEventArgs e) { }
    }
}
