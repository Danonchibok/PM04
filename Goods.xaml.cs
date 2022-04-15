using pm04.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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
    /// Логика взаимодействия для Goods.xaml
    /// </summary>
    public partial class Goods : UserControl
    {
        private ObservableCollection<Item> items;
        public ObservableCollection<Item> Items
        {
            get { return items; }
            set { items = value; }
        }
        public Goods(Category category)
        {
            InitializeComponent();
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
    }
}
