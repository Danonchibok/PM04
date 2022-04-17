using Microsoft.Win32;
using pm04.Model;
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

namespace pm04
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page, IChangebale
    {
        private bool isSaveLogin = true;
        private static readonly string registryKey = "pm04Key";

        private string login;
        private string password;
        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                PasswordTextBox.Password = value;
                OnPropertyChanged("Password");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public AuthPage()
        {
            InitializeComponent();
            DataContext = this;
            string[] data = GetRegistryKeys();
            if (data != null)
            {
                isSaveLogin = false;
                Login = data[0];
                Password = data[1];
            }
        }

        private void Button_LogIn(object sender, RoutedEventArgs e)
        {
            string varLogin = "";
            string varPassword = "";
            varLogin = Login;
            varPassword = PasswordTextBox.Password;
            try
            {
                List<User> users = TemplateContext.GetContext().Users.Where(ee => ee.Login == varLogin).ToList();
                if (users.Count >0)
                {
                    users = users.Where(ee => ee.Password == varPassword).ToList();
                    if (users.Count > 0)
                    {
                        if (isSaveLogin)
                        {
                            SetRegistryKeys(varLogin, varPassword);
                        }
                        NavigationClass.Navigate(new Glavnaya());
                        TemplateContext.User = users.FirstOrDefault();
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

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void SetRegistryKeys(string login, string password)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(registryKey, true);
            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey(registryKey);
            }
            key.SetValue("Login", login);
            key.SetValue("Password", password);
            key.Close();
        }

        private string[] GetRegistryKeys()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(registryKey, true);
            
            if (key != null)
            {
                string login = key.GetValue("Login").ToString();
                string password = key.GetValue("Password").ToString();
               
                string[] data = { login, password };
                return data;
            }
            return null;

        }
    }
}
