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
    /// Логика взаимодействия для MaterialsAddPage.xaml
    /// </summary>
    public partial class MaterialsAddPage : Page
    {
        private Материал _currentTab = new Материал();
        public MaterialsAddPage(Материал currentTab)
        {
            InitializeComponent();
            if (currentTab != null)
                _currentTab = currentTab;
            DataContext = _currentTab;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();


            if (string.IsNullOrWhiteSpace(_currentTab.Наименование))
                errors.AppendLine("Укажите название");
            if (_currentTab.Тип_материала == null)
                errors.AppendLine("Выберите Тип_материала");
            if (string.IsNullOrWhiteSpace(_currentTab.Тип_материала))
                errors.AppendLine("Укажите тип материала");
            if (_currentTab.Количество_в_упаковке < 1 || _currentTab.Количество_в_упаковке > 500)
                errors.AppendLine("Кол-во в упаковке не больше 500 и не меньше 1");
            if (_currentTab.Единица_измерения == null)
                errors.AppendLine("Введите цену");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentTab.ID == 0)
                LOXEntities.GetContext().Материал.Add(_currentTab);
            try
            {
                LOXEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
