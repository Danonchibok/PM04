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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : UserControl
    {
        private int tabIndex =0;
        public Registration()
        {
            InitializeComponent();
        }
        private void Button_Next(object sender, RoutedEventArgs e)
        {
            tabIndex++;
            if (tabIndex > rega.Items.Count -1)
            {
                tabIndex = rega.Items.Count -1;
                
                if (RegistrateUser())
                {
                    NavigationClass.mainFrame.Navigate(new Glavnaya());
                }
            }
            rega.SelectedItem = rega.Items[tabIndex];
        }
        private void Button_Back(object sender, RoutedEventArgs e)
        {
            tabIndex--;
            if (tabIndex < 0)
            {
                tabIndex = 0;
                NavigationClass.mainFrame.Navigate(new AuthPage());
            }
            rega.SelectedItem = rega.Items[tabIndex];
        }
        private bool RegistrateUser()
        {
            if (textPassword.Text != textRepeatPassword.Text)
            {
                MessageBox.Show("Пароль неверный!");
                return false;
            }
            User user = new User()
            {
                Login = textLogin.Text,
                Password = textPassword.Text,
                FirstName = textFirstName.Text,
                LastName = textLastName.Text,
                Name = textPatronumic.Text,
                Phone = textPhone.Text,
                DateOfBirth = DateTime.Parse(textBDay.Text),
                gender = male.IsChecked,
            };
            Address addres = new Address()
            {
                Street = textStreet.Text,
                House = textNumberHouse.Text,
                Room = textNumberRoom.Text,
                Porch = textNumberDoor.Text,
                Floor = textNumberFloor.Text,
            };
            user.Addresses.Add(addres);
            TemplateContext.GetContext().Users.Add(user);
            TemplateContext.GetContext().SaveChanges();
            return true;
        }
    }
}

