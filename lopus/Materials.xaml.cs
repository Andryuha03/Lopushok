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
    /// Логика взаимодействия для Materials.xaml
    /// </summary>
    public partial class Materials : Page
    {
        public Materials()
        {
            InitializeComponent();
            dataGridSupplier.ItemsSource = LOXEntities.GetContext().Материал.ToList();
        }

        private void dataGridSupplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new MaterialsAddPage((sender as Button).DataContext as Материал));
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new MaterialsAddPage((sender as Button).DataContext as Материал));
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            var SupplierForRemoving = dataGridSupplier.SelectedItems.Cast<Материал>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {SupplierForRemoving.Count()} элементов?", "Внимание",
               MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    LOXEntities.GetContext().Материал.RemoveRange(SupplierForRemoving);
                    LOXEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    dataGridSupplier.ItemsSource = LOXEntities.GetContext().Материал.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
