using pm04.Model;
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

namespace pm04
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void Button_LogIn(object sender, RoutedEventArgs e)
        {
            string varLogin = "";
            string varPassword = "";
            varLogin = loginTextBox.Text;
            varPassword = PasswordTextBox.Text;
            try
            {
                List<User> users = TemplateContext.GetContext().Users.Where(ee => ee.Login == varLogin).ToList();
                if (users.Count >0)
                {
                    users = users.Where(ee => ee.Password == varPassword).ToList();
                    if (users.Count >0)
                    {
                        NavigationClass.Navigate(new Glavnaya());
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль!");
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин!");
                }
            }
            catch (Exception exce)
            {
                MessageBox.Show(exce.Message);
            }
        }

        private void Button_Create(object sender, RoutedEventArgs e)
        {
            NavigationClass.Navigate(new Registration());
        }
    }
}
