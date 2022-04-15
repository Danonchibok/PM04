using pm04.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
    /// Логика взаимодействия для Goods.xaml
    /// </summary>
    public partial class Goods : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<Item> items;
        private string shoppingCart;
        private List<Item> cart;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string ShopingCart
        {
            get => shoppingCart;
            set
            {
                shoppingCart = value;
                OnPropertyChanged("ShopingCart");
            }
        }
        public ObservableCollection<Item> Items
        {
            get { return items; }
            set { items = value;  OnPropertyChanged("Items"); }
        }

        public Goods(Category category)
        {
            InitializeComponent();
            cart = new List<Item>();
            ShopingCart = "Корзина";
            DataContext = this;
            Items = new ObservableCollection<Item>(category.Items);
            string[] images = Directory.GetFiles(@"E:\pm04\pm04\Image\");

            foreach (Item item in Items)
            {
                try
                { item.Image = File.ReadAllBytes(images.FirstOrDefault(img => img.Contains(@"E:\pm04\pm04\Image\" + item.Src))); }
                catch (Exception)
                { item.Image = File.ReadAllBytes(@"E:\pm04\pm04\Image\no_photo.png"); }
            }
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

        private void increase_button(object sender, RoutedEventArgs e)
        {
            Item item = (sender as Button).DataContext as Item;
            item.Count++;

            if (!cart.Contains(item))
            {
                cart.Add(item);
                ShopingCart = $"Корзина ({cart.Count})";
            }
        }

        private void decrease_button(object sender, RoutedEventArgs e)
        {
            Item item = (sender as Button).DataContext as Item;
            if (item.Count != 0)
            {
                item.Count--;
            }

            if (item.Count < 1 && cart.Contains(item))
            {
                cart.Remove(item);
                ShopingCart = $"Корзина ({cart.Count})";
            }
            
        }

        private void Cart_button(object sender, RoutedEventArgs e)
        {
            NavigationClass.Navigate(new Cart(cart));
        }
    }
}
