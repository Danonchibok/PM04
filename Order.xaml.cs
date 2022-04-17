using pm04.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : UserControl
    {
        private User user => TemplateContext.User;
        private List<Item> items;

        public Order(List<Item> items)
        {
            InitializeComponent();
            DataContext = this;
            this.items = items;
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

            foreach (Item item in this.items)
            {
                Model.Order order = new Model.Order();
                Items_order itemsOrder = new Items_order();
                itemsOrder.Item = item;
                itemsOrder.Order = order;
                order.User = user;
                order.Items_order.Add(itemsOrder);
                TemplateContext.GetContext().Items_order.Add(itemsOrder);
                TemplateContext.GetContext().Orders.Add(order);
                TemplateContext.GetContext().SaveChanges();

            }


        }


    }
}
