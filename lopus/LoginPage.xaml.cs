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
using System.Security.Cryptography;

namespace lopus
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        LOXEntities db = new LOXEntities();
        public authoriz _users = new authoriz();
        authoriz authuser = null;
        authoriz adminunser = null;
        private string TypeUser;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void TextBox_Login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }






        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            passwordBox_password.Password = GetHash(passwordBox_password.Password);
            var authuser = db.authorizs.FirstOrDefault(x => x.login == TextBox_Login.Text && x.password == passwordBox_password.Password);
            var adminuser = db.authorizs.FirstOrDefault(x => x.login == TextBox_Login.Text && x.type_user == "Admin");
            var masterproiz = db.authorizs.FirstOrDefault(x => x.login == TextBox_Login.Text && x.type_user == "MASTER");

            if (authuser != null)
            {
                if (adminuser != null)
                {
                    MessageBox.Show("Вы вошли как администратор");
                    admin.isadmin = true;
                    Manager.MainFrame.Navigate(new Materials());
                }
                else if (masterproiz != null)
                {
                    MessageBox.Show("Вы вошли как мастер");
                    Manager.MainFrame.Navigate(new Master(null));
                    //Manager.MainFrame.Navigate(new MasterT2(null));

                    admin.isadmin = false;
                }
                else
                {
                    MessageBox.Show("Пользователь! Добро пожаловать :)");
                    admin.isadmin = false;
                    Manager.MainFrame.Navigate(new Product());
                }
            }
            else
            {
                MessageBox.Show("Ошибка!!!\nВведите данные");
            }
        }
    }
}
