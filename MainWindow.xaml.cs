using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace HMID
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<DepthOfMarket> depthOfMarkets = new List<DepthOfMarket>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((DepthOfMarket.Count + 1) * 140 <= this.Width)
            {
                DepthOfMarket depthOfMarket = new DepthOfMarket(this);
                depthOfMarket.name = value.Text + $"_{DepthOfMarket.Count}";
                depthOfMarket.Width = 140;
                depthOfMarket.ID = 1;
                panel1.Children.Add(depthOfMarket.CreateList());
                depthOfMarket.GenerationDatas();
                depthOfMarkets.Add(depthOfMarket);

                panel1.Children.Clear();

                DepthOfMarket depthOfMarket1 = new DepthOfMarket(this);
                depthOfMarket1.name = value.Text + $"_{DepthOfMarket.Count}";
                depthOfMarket1.Width = 140;
                depthOfMarket.ID = 2;
                panel1.Children.Add(depthOfMarket1.CreateList());
                depthOfMarket1.GenerationDatas();
                depthOfMarkets.Add(depthOfMarket1);

                //products.ItemsSource = null;
                products.ItemsSource = depthOfMarkets;
            }
            else MessageBox.Show($"Нет места для {DepthOfMarket.Count + 1}-ого стакана.");
        }

        private void Сhart_Click(object sender, RoutedEventArgs e)
        {
            ChartWIndow chartWindow = new ChartWIndow();
            chartWindow.Show();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
        }
        private void SettingsDOM_Click(object sender, RoutedEventArgs e)
        {
            foreach (var deathOfMarket in depthOfMarkets)
            {
                if (deathOfMarket.name == ((sender as FrameworkElement).DataContext as Data).name)
                {
                    SettingsDOM settingsDOM = new SettingsDOM(deathOfMarket, this, deathOfMarket.N,
                        deathOfMarket.FontSize,
                        deathOfMarket.LargeRrice,
                        deathOfMarket.Width,
                        deathOfMarket.name);
                    settingsDOM.Show(); 
                    break;
                }
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            foreach (var child in panel1.Children)
            {
                if (child is ListBox && ((sender as FrameworkElement).DataContext as Data).name == (child as ListBox).Name)
                {
                    panel1.Children.Remove(child as ListBox);
                    DepthOfMarket.Count--;
                    break;
                }
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            products.Items.Add(new TabItem
            {
                Header = new TextBlock { Text = "Ноутбуки" }
            });
        }
    }
}
