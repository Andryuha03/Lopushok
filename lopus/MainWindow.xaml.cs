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

namespace lopus
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Manager.MainFrame = MainFrame;
            MainFrame.Navigate(new LoginPage());

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {



            if (MainFrame.CanGoBack)
            {
                Button_Login.Visibility = Visibility.Hidden;
                BtnBack.Visibility = Visibility.Visible;
                Materials.Visibility = Visibility.Visible;
                Supplier.Visibility = Visibility.Visible;
                //Button_Proizvodstvo.Visibility = Visibility.Hidden;

                if (master.ismaster == true)
                {
                    BtnBack.Visibility = Visibility.Visible;
                    Materials.Visibility = Visibility.Hidden;
                    Supplier.Visibility = Visibility.Hidden;
                }
                else if (admin.isadmin == true)
                {
                    BtnBack.Visibility = Visibility.Visible;
                    Materials.Visibility = Visibility.Visible;
                    Supplier.Visibility = Visibility.Visible;
                }
                else if (admin.isadmin == false && master.ismaster == false)
                {
                    BtnBack.Visibility = Visibility.Visible;
                    Materials.Visibility = Visibility.Hidden;
                    Supplier.Visibility = Visibility.Hidden;








                }
            }
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void Materials_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Product());
        }

        private void Supplier_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Materials());
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
