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
using Xceed.Wpf.Toolkit;

namespace HMID
{
    /// <summary>
    /// Interaction logic for SettingsDOM.xaml
    /// </summary>
    public partial class SettingsDOM : Window
    {
        private DepthOfMarket depthOfMarket;
        private MainWindow form;
        private string name;

        private void titleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public SettingsDOM(DepthOfMarket depthOfMarket, MainWindow form, int N, int FontSize, double LargePrice, 
            int Width, string name)
        {
            this.depthOfMarket = depthOfMarket;
            this.name = name;
            this.form = form;
            InitializeComponent();

            string[] words = name.Split('_');

            this.Title += ' ' + words[0] + ' ' + words[1];

            widht.Text = Convert.ToString(Width);
            largePrice.Text = Convert.ToString(LargePrice);
            fontSize.Text = Convert.ToString(FontSize);
            LargeColor.SelectedColor = depthOfMarket.largeColor.Color;
            BuyColor.SelectedColor = depthOfMarket.BuyColor.Color;
            SellColor.SelectedColor = depthOfMarket.SellColor.Color;
            ActiveColor.SelectedColor = depthOfMarket.ActiveColor.Color;
        }

        private void TextChanged_width(object sender, TextChangedEventArgs e)
        {
            if (widht.Text == "") return;
            int sumWidth = 0;
            foreach (var dom in MainWindow.depthOfMarkets)
            {
                sumWidth += dom.Width;
            }
            int width = Convert.ToInt32(widht.Text);
            if (sumWidth + width > form.Width)
            {
                System.Windows.MessageBox.Show("Нет места для нового стакана");
                return;
            }
            foreach (var child in form.panel1.Children)
            {
                if (child is ListBox && name == (child as ListBox).Name)
                {
                    (child as ListBox).Width = width;
                    depthOfMarket.Width = width;
                    MainWindow.valuePairs[depthOfMarket.name].Width = width;
                    MainWindow.valuePairs1[depthOfMarket.name].Width = width;
                    break;
                }
            }
        }

        private void TextChanged_largePrice(object sender, TextChangedEventArgs e)
        {
            if (largePrice.Text == "") return;
            int large = Convert.ToInt32(largePrice.Text);
            depthOfMarket.LargeRrice = large;
        }

        private void TextChanged_fontSize(object sender, TextChangedEventArgs e)
        {
            if (fontSize.Text == "") return;
            int NewfontSize = Convert.ToInt32(fontSize.Text);
            depthOfMarket.FontSize = NewfontSize;
        }

        private void Button_Up_Width(object sender, RoutedEventArgs e)
        {
            if (widht.Text == "") return;
            int newWidth = Convert.ToInt32(widht.Text);
            widht.Text = Convert.ToString(++newWidth);
        }

        private void Button_Down_Width(object sender, RoutedEventArgs e)
        {
            if (widht.Text == "") return;
            int newWidth = Convert.ToInt32(widht.Text);
            widht.Text = Convert.ToString(--newWidth);
        }


        private void Button_Up_largePrice(object sender, RoutedEventArgs e)
        {
            if (largePrice.Text == "") return;
            int newWidth = Convert.ToInt32(largePrice.Text);
            largePrice.Text = Convert.ToString(++newWidth);
        }

        private void Button_Down_largePrice(object sender, RoutedEventArgs e)
        {
            if (largePrice.Text == "") return;
            int newWidth = Convert.ToInt32(largePrice.Text);
            largePrice.Text = Convert.ToString(--newWidth);
        }

        private void Button_Up_fontSize(object sender, RoutedEventArgs e)
        {
            if (fontSize.Text == "") return;
            int newWidth = Convert.ToInt32(fontSize.Text);
            fontSize.Text = Convert.ToString(++newWidth);
        }

        private void Button_Down_fontSize(object sender, RoutedEventArgs e)
        {
            if (fontSize.Text == "") return;
            int newWidth = Convert.ToInt32(fontSize.Text);
            fontSize.Text = Convert.ToString(--newWidth);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LargeColor_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            depthOfMarket.largeColor = new SolidColorBrush((Color)LargeColor.SelectedColor);
        }

        private void BuyColor_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            depthOfMarket.BuyColor = new SolidColorBrush((Color)BuyColor.SelectedColor);
        }

        private void SellColor_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            depthOfMarket.SellColor = new SolidColorBrush((Color)SellColor.SelectedColor);
        }

        private void ActiveColor_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            depthOfMarket.ActiveColor = new SolidColorBrush((Color)ActiveColor.SelectedColor);
        }
    }
}
