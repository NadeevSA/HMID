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
        private int tabs = 2;
        private int deleteTabs = 0;

        public static int _width;
        public static int _largePrice;
        public static int _fontSize;
        public static string _value;
        public static Boolean _newStakan = false;
        public static SolidColorBrush _largeColor;
        public List<DepthOfMarket> depthOfMarkets = new List<DepthOfMarket>();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                DepthOfMarket depthOfMarket = new DepthOfMarket(this);
                depthOfMarket.FontSize = _fontSize;
                depthOfMarket.name = _value + $"_{DepthOfMarket.Count}";
                depthOfMarket.Width = _width;
                depthOfMarket.LargeRrice = _largePrice;
                depthOfMarket.largeColor = _largeColor;
                depthOfMarket.tab = Convert.ToString((products.SelectedItem as TabItem).Header);
                /*TextBox textBox = new TextBox();
                textBox.Text = value.Text;
                textBox.Width = 240;
                textBox.Height = 30;
                panel2.Children.Add(textBox);*/
                panel1.Children.Add(depthOfMarket.CreateList());
                depthOfMarket.GenerationDatas();
                depthOfMarkets.Add(depthOfMarket);
            }
            else MessageBox.Show($"Нет места для {DepthOfMarket.Count + 1}-ого стакана.");
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
                    foreach(var dom in depthOfMarkets)
                    {
                        if(dom.name == (child as ListBox).Name)
                        {
                            depthOfMarkets.Remove(dom);
                            break;
                        }   
                    }
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
            if (this.Width >= 70 * (tabs + 1) + 400 - 70 * deleteTabs)
            {
                products.Items.Add(new TabItem
                {
                    Header = $"Вкладка {tabs++}",
                    Width = 70
                });
            }
            else
            {
                MessageBox.Show("Нет места для новой вкладки");
            }
        }

        private void products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            panel1.Children.Clear();
            if ((products.SelectedItem as TabItem) != null)
            {
                foreach (var dom in depthOfMarkets)
                {
                    if (dom.tab == Convert.ToString((products.SelectedItem as TabItem).Header))
                    {
                        panel1.Children.Add(dom.ReturnListBox());
                    }
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if ((products.SelectedItem as TabItem) == null)
            {
                MessageBox.Show("Выберите вкладку");
                return;
            }
            AddDOM addDOM = new AddDOM(this);
            addDOM.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            products.Items.Remove(products.SelectedItem);
            deleteTabs++;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Wallet wallet = new Wallet();
            wallet.Show();
        }
    }
}
