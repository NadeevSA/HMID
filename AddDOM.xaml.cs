using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace HMID
{
    /// <summary>
    /// Interaction logic for AddDOM.xaml
    /// </summary>
    public partial class AddDOM : Window
    {
        private MainWindow main;
        public AddDOM(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void titleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Up_Width(object sender, RoutedEventArgs e)
        {
            int newWidth = Convert.ToInt32(widht.Text);
            widht.Text = Convert.ToString(++newWidth);
        }

        private void Button_Down_Width(object sender, RoutedEventArgs e)
        {
            int newWidth = Convert.ToInt32(widht.Text);
            widht.Text = Convert.ToString(--newWidth);
        }

        private void Button_Up_largePrice(object sender, RoutedEventArgs e)
        {
            int newWidth = Convert.ToInt32(largePrice.Text);
            largePrice.Text = Convert.ToString(++newWidth);
        }

        private void Button_Down_largePrice(object sender, RoutedEventArgs e)
        {
            int newWidth = Convert.ToInt32(largePrice.Text);
            largePrice.Text = Convert.ToString(--newWidth);
        }

        private void Button_Up_fontSize(object sender, RoutedEventArgs e)
        {
            int newWidth = Convert.ToInt32(fontSize.Text);
            fontSize.Text = Convert.ToString(++newWidth);
        }

        private void Button_Down_fontSize(object sender, RoutedEventArgs e)
        {
            int newWidth = Convert.ToInt32(fontSize.Text);
            fontSize.Text = Convert.ToString(--newWidth);
        }

        private void Button_Up_n(object sender, RoutedEventArgs e)
        {
            int newWidth = Convert.ToInt32(n.Text);
            n.Text = Convert.ToString(++newWidth);
        }

        private void Button_Down_n(object sender, RoutedEventArgs e)
        {
            int newWidth = Convert.ToInt32(n.Text);
            n.Text = Convert.ToString(--newWidth);
        }

        private void Button_Up_diff(object sender, RoutedEventArgs e)
        {
            double newWidth = Convert.ToDouble(diff.Text);
            diff.Text = Convert.ToString(++newWidth);
        }

        private void Button_Down_diff(object sender, RoutedEventArgs e)
        {
            double newWidth = Convert.ToDouble(diff.Text);
            diff.Text = Convert.ToString(--newWidth);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int sumWidth = 0;
            foreach (var dom in MainWindow.depthOfMarkets)
            {
                if(dom.tab == Convert.ToString((main.products.SelectedItem as TabItem).Header))
                    sumWidth += dom.Width;
            }
            if (main.Width <= sumWidth + Convert.ToInt32(widht.Text))
            {
                MessageBox.Show("Нет места для нового рыночного стакана");
                return;
            }
            MainWindow._fontSize = Convert.ToInt32(fontSize.Text);
            MainWindow._largePrice = Convert.ToInt32(largePrice.Text);
            MainWindow._value = value.Text;
            MainWindow._n = Convert.ToInt32(n.Text);
            MainWindow._diff = Convert.ToDouble(diff.Text);
            MainWindow._largeColor = new SolidColorBrush((Color)LargeColor.SelectedColor);
            MainWindow._buyColor = new SolidColorBrush((Color)BuyColor.SelectedColor);
            MainWindow._sellColor = new SolidColorBrush((Color)SellColor.SelectedColor);
            MainWindow._activeColor = new SolidColorBrush((Color)ActiveColor.SelectedColor);
            MainWindow._width = Convert.ToInt32(widht.Text);
            main.Button_Click(sender, e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
