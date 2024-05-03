using _03_Shop_CourseWork_;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _05_wpf_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ShopDbContext context;
        public MainWindow()
        {
            InitializeComponent();
            context = new ShopDbContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetGrid(1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SetGrid(2);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SetGrid(3);
        }
        private void SetGrid(int num)
        {
            var info = context.Shops.Find(num);
            context.Entry(info).Collection(s => s.Workers).Load();
            grid.ItemsSource = info.Workers.ToList();
            context.Entry(info).Collection(s => s.Products).Load();
            grid1.ItemsSource = info.Products.ToList();
        }
    }
}