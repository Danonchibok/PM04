using pm04.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
    /// Логика взаимодействия для Cart.xaml
    /// </summary>
    public partial class Cart : UserControl, IChangebale
    {
        private string cartInfo;
        private ObservableCollection<Item> items;

        public event PropertyChangedEventHandler PropertyChanged;

        public string CartInfo
        {
            get => cartInfo;
            set
            {
                cartInfo = value;
                OnPropertyChanged("CartInfo");
            }
        }
        public ObservableCollection<Item> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }
        public Cart(List<Item> items)
        {
            InitializeComponent();
            DataContext = this;
            this.items = new ObservableCollection<Item>(items);
            CartInfo = $"Оформить ({CalculatePrice()})";
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

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private decimal? CalculatePrice()
        {
            decimal? price = 0;
            foreach (Item item in Items)
            {
                price += item.Count * item.Price;
            }
            return price;
        }


        private void increase_button(object sender, RoutedEventArgs e)
        {
            Item item = (sender as Button).DataContext as Item;
            item.Count++;

            CartInfo = $"Оформить ({CalculatePrice()})";

        }

        private void decrease_button(object sender, RoutedEventArgs e)
        {
            Item item = (sender as Button).DataContext as Item;
            if (item.Count != 0)
            {
                item.Count--;
            }

            if (item.Count < 1 && Items.Contains(item))
            {
                Items.Remove(item);
                CartInfo = $"Оформить ({CalculatePrice()})";
            }

        }

        private void Cart_Button(object sender, RoutedEventArgs e)
        {
            NavigationClass.Navigate(new Order(Items.ToList()));
        }
    }
}
