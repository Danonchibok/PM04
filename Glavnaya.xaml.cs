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
using pm04.Model;

namespace pm04
{
    /// <summary>
    /// Логика взаимодействия для Glavnaya.xaml
    /// </summary>
    public partial class Glavnaya : UserControl
    {
        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set { categories = value;}
        }
        public Glavnaya()
        {
            InitializeComponent();
            DataContext = this;
            Categories = new ObservableCollection<Category>( TemplateContext.GetContext().Categories.ToList());
            string[] images = Directory.GetFiles(@"E:\pm04\pm04\Image\");
        
            foreach (Category item in Categories)
            {
                try
                { item.Image = File.ReadAllBytes(images.FirstOrDefault(img => img.Contains(@"E:\pm04\pm04\Image\" + item.Src))); }
                catch (Exception)
                { }
            }
        }

        private void Button_market(object sender, RoutedEventArgs e)
        {

        }

        private void Button_TG(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://web.telegram.org/") { UseShellExecute = true });
        }

        private void Button_Insta(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.instagram.com/teddyflowers_perm/") { UseShellExecute = true });
        }
        private void Button_Vk(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://vk.com/syrprizko") { UseShellExecute = true });
        }

        private void categoriesListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Category item = categoriesListView.SelectedItem as Category;
            NavigationClass.Navigate(new Goods(item));
        }
    }
}
