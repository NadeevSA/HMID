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
        private int id = 0;

        public static int _width;
        public static int _largePrice;
        public static int _fontSize;
        public static string _value;
        public static string _name;
        public static int _n;
        public static double _diff;
        public static Boolean _newStakan = false;
        public static SolidColorBrush _largeColor;
        public static SolidColorBrush _buyColor;
        public static SolidColorBrush _sellColor;
        public static SolidColorBrush _activeColor;
        public static List<DepthOfMarket> depthOfMarkets = new List<DepthOfMarket>();
        public static Dictionary<String, TextBox> valuePairs = new Dictionary<string, TextBox>();
        public static Dictionary<String, ComboBox> valuePairs1 = new Dictionary<string, ComboBox>();

        public MainWindow()
        {
            InitializeComponent();
            Rialto rialto = new Rialto(this);
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            DepthOfMarket depthOfMarket = null;
            if (Rialto.ValutaCurrentPrice.ContainsKey(_value))
            {
                depthOfMarket = new DepthOfMarket(this, Rialto.ValutaCurrentPrice[_value]);
            }
            else
            {
                depthOfMarket = new DepthOfMarket(this);
                Rialto.ValutaCurrentPrice.Add(_value, depthOfMarket.ActualPrice);
            }
            depthOfMarket.FontSize = _fontSize;
            depthOfMarket.name = _value + $"_{DepthOfMarket.Count}" + id++;
            depthOfMarket.Width = _width;
            depthOfMarket.LargeRrice = _largePrice;
            depthOfMarket.largeColor = _largeColor;
            depthOfMarket.SellColor = _sellColor;
            depthOfMarket.BuyColor = _buyColor;
            depthOfMarket.ActiveColor = _activeColor;
            depthOfMarket.Valuta = _value;
            depthOfMarket.diff = _diff;
            depthOfMarket.N = _n;
            depthOfMarket.tab = Convert.ToString((products.SelectedItem as TabItem).Header);
            panel1.Children.Add(depthOfMarket.CreateList());
            TextBox textBox = new TextBox();
            textBox.Width = _width;
            textBox.Height = 80;
            textBox.IsReadOnly = true;
            ComboBox comboBox = new ComboBox();
            TextBlock forComboBox1 = new TextBlock();
            TextBlock forComboBox2 = new TextBlock();
            TextBlock forComboBox3 = new TextBlock();
            forComboBox1.Text = "1000";
            forComboBox2.Text = "3000";
            forComboBox3.Text = "5000";
            comboBox.Items.Add(forComboBox1);
            comboBox.Items.Add(forComboBox2);
            comboBox.Items.Add(forComboBox3);
            comboBox.SelectedItem = forComboBox1;
            comboBox.Width = _width;
            comboBox.Height = 20;
            valuePairs.Add(depthOfMarket.name, textBox);
            valuePairs1.Add(depthOfMarket.name, comboBox);
            depthOfMarket.GenerationDatas();
            panel3.Children.Add(comboBox);
            panel2.Children.Add(textBox);
            depthOfMarkets.Add(depthOfMarket);
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
                    panel2.Children.Remove(valuePairs[(child as ListBox).Name]);
                    panel3.Children.Remove(valuePairs1[(child as ListBox).Name]);
                    foreach (var dom in depthOfMarkets)
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
            if(((sender as FrameworkElement).DataContext as Data).active)
                ((sender as FrameworkElement).DataContext as Data).active = false;
            else ((sender as FrameworkElement).DataContext as Data).active = true;
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

        private void RePrint()
        {
            panel1.Children.Clear();
            panel2.Children.Clear();
            panel3.Children.Clear();
            if ((products.SelectedItem as TabItem) != null)
            {
                foreach (var dom in depthOfMarkets)
                {
                    if (dom.tab == Convert.ToString((products.SelectedItem as TabItem).Header))
                    {
                        panel1.Children.Add(dom.ReturnListBox());
                        panel2.Children.Add(valuePairs[dom.name]);
                        panel3.Children.Add(valuePairs1[dom.name]);
                    }
                }
            }
        }

        private void products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RePrint();
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

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            foreach (var child in panel1.Children)
            {
                if (child is ListBox && ((sender as FrameworkElement).DataContext as Data).name == (child as ListBox).Name)
                {
                    _name = (child as ListBox).Name;
                    break;
                }
            }
            ChartWIndow chartWIndow = new ChartWIndow();
            chartWIndow.Show();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            foreach (var child in panel1.Children)
            {
                if (child is ListBox && ((sender as FrameworkElement).DataContext as Data).name == (child as ListBox).Name)
                {
                    for(int i = 0; i < depthOfMarkets.Count; ++i)
                    {
                        if (depthOfMarkets[i].name == (child as ListBox).Name && i != 0)
                        {
                            DepthOfMarket tmp = depthOfMarkets[i];
                            depthOfMarkets[i] = depthOfMarkets[i - 1];
                            depthOfMarkets[i - 1] = tmp;
                            break;
                        }
                    }
                    break;
                }
            }
            RePrint();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            foreach (var child in panel1.Children)
            {
                if (child is ListBox && ((sender as FrameworkElement).DataContext as Data).name == (child as ListBox).Name)
                {
                    for (int i = 0; i < depthOfMarkets.Count; ++i)
                    {
                        if (depthOfMarkets[i].name == (child as ListBox).Name && i != depthOfMarkets.Count - 1)
                        {
                            DepthOfMarket tmp = depthOfMarkets[i];
                            depthOfMarkets[i] = depthOfMarkets[i + 1];
                            depthOfMarkets[i + 1] = tmp;
                            break;
                        }
                    }
                    break;
                }
            }
            RePrint();
        }
    }
}
