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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((DepthOfMarket.Count + 1) * 140 <= this.Width)
            {
                DepthOfMarket depthOfMarket = new DepthOfMarket(this);
                depthOfMarket.name = $"test{DepthOfMarket.Count + 1}";
                depthOfMarket.Width = 140;
                panel1.Children.Add(depthOfMarket.CreateList());
                depthOfMarket.GenerationDatas();
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
            SettingsDOM settingsDOM = new SettingsDOM();
            settingsDOM.Show();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            foreach (var child in panel1.Children)
            {
                if (child is ListBox && ((sender as FrameworkElement).DataContext as DepthOfMarket).name == (child as ListBox).Name)
                {
                    panel1.Children.Remove(child as ListBox);
                    DepthOfMarket.Count--;
                    break;
                }
            }
        }
    }
}
