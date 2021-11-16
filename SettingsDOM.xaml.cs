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
    /// Interaction logic for SettingsDOM.xaml
    /// </summary>
    public partial class SettingsDOM : Window
    {
        private DepthOfMarket depthOfMarket;
        private MainWindow form;
        private string name;

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
            num.Text = Convert.ToString(N);
        }

        private void TextChanged_width(object sender, TextChangedEventArgs e)
        {
            int width = Convert.ToInt32(widht.Text);
            foreach (var child in form.panel1.Children)
            {
                if (child is ListBox && name == (child as ListBox).Name)
                {
                    (child as ListBox).Width = width;
                    depthOfMarket.Width = width;
                    break;
                }
            }
        }

        private void TextChanged_largePrice(object sender, TextChangedEventArgs e)
        {
            int large = Convert.ToInt32(largePrice.Text);
            depthOfMarket.LargeRrice = large;
        }

        private void TextChanged_num(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextChanged_fontSize(object sender, TextChangedEventArgs e)
        {
            int NewfontSize = Convert.ToInt32(fontSize.Text);
            depthOfMarket.FontSize = NewfontSize;
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


        private void Button_Up_num(object sender, RoutedEventArgs e)
        {
            int newWidth = Convert.ToInt32(num.Text);
            num.Text = Convert.ToString(++newWidth);
        }

        private void Button_Down_num(object sender, RoutedEventArgs e)
        {
            int newWidth = Convert.ToInt32(num.Text);
            num.Text = Convert.ToString(--newWidth);
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
    }
}
