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
    /// Логика взаимодействия для Product.xaml
    /// </summary>
    public partial class Product : Page
    {
        public Product()
        {
            InitializeComponent();
            var currentTours = LOXEntities.GetContext().Продукт.ToList();
            ListViewMaterial.ItemsSource = currentTours.OrderBy(p => p.Наименование).ToList();
            ComboboxFilter.ItemsSource = new List<string> { "Все типы","Три слоя", "Два слоя", "Один слой", "Детская", "Супер мягкая" };
            ComboboxFilter.SelectedIndex = 0;

            ComboboxSort.ItemsSource = new List<string> { "Все типы", "По названию", "По артикулу", "Минимальная стоимость" };
            ComboboxSort.SelectedIndex = 0;
            UpdateMaterials();
        }


        private void UpdateMaterials()
        {
            var _currentMaterials = LOXEntities.GetContext().Продукт.ToList();


            if (ComboboxFilter.SelectedIndex > 0)
            {
                _currentMaterials = _currentMaterials.Where(p => p.Тип_прод.Contains(ComboboxFilter.SelectedItem.ToString())).ToList();
            }

            _currentMaterials = _currentMaterials.Where(p => p.Наименование.ToLower().Contains(TextBoxSearch.Text.ToLower())).ToList();

            if (ComboboxSort.SelectedIndex > 0)
            {

                if (ComboboxSort.SelectedItem.ToString() == "По названию")
                {
                    _currentMaterials = _currentMaterials.OrderBy(p => p.Наименование).ToList();
                }
                else if (ComboboxSort.SelectedItem.ToString() == "По артикулу")
                {
                    _currentMaterials = _currentMaterials.OrderBy(p => p.Артикул).ToList();
                }
                else if (ComboboxSort.SelectedItem.ToString() == "Минимальная стоимость")
                {
                    _currentMaterials = _currentMaterials.OrderBy(p => p.Мин_стоим).ToList();
                }

            }

            ListViewMaterial.ItemsSource = _currentMaterials;
        }
         











        private void ListViewMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateMaterials();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateMaterials();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateMaterials();
        }

        private void TextBoxSearch_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            UpdateMaterials();
        }

        private void TextBoxSearch_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            UpdateMaterials();
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateMaterials();
        }
    }
}
