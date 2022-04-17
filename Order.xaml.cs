using pm04.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : UserControl
    {
        private string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
        private User user => TemplateContext.User;
        private List<Item> items;

        private decimal? price = 0;
        private decimal skidka = 0;

        public Order(List<Item> items)
        {
            InitializeComponent();
            DataContext = this;
            this.items = items;

            foreach (Item item in items)
            {
                price += item.Count * item.Price;
            }
            priceText.Text = $"Стоимость: {price}р";
            skidkaText.Text = $"Скидка: {skidka}р";
            itogText.Text = $"Итог: {price}р" ;
        }

        private void Button_Insta(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.instagram.com/teddyflowers_perm/") { UseShellExecute = true });
        }

        private void Button_TG(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://web.telegram.org/") { UseShellExecute = true });
        }

        private void Button_Vk(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://vk.com/syrprizko") { UseShellExecute = true });
        }
        private void Button_back(object sender, RoutedEventArgs e)
        {
            NavigationClass.Back();
        }
               
        private void Button_Create(object sender, RoutedEventArgs e)
        {
            if (textEmail.Text == "")
            {
                MessageBox.Show("Введи данные");
                return;
            }

            Regex mailRegex = new Regex(pattern);
            if (!mailRegex.IsMatch(textEmail.Text))
            {
                MessageBox.Show("Данные не соотвествуют");
                return;
            }



            Model.Order order = new Model.Order();

            foreach (Item item in this.items)
            {
                Items_order itemsOrder = new Items_order();
                itemsOrder.Item = item;
                itemsOrder.Order = order;
                order.Items_order.Add(itemsOrder);
            }
            order.User = user;
            TemplateContext.GetContext().Orders.Add(order);
            TemplateContext.GetContext().SaveChanges();
            MessageBox.Show("Заказ оформлен");


        }


    }
}
