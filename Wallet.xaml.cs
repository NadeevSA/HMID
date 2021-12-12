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
    /// Interaction logic for Wallet.xaml
    /// </summary>
    public partial class Wallet : Window
    {
        public Wallet()
        {
            InitializeComponent();
            List<Valuta> phonesList = new List<Valuta>
            {
                new Valuta { name="ываы", count=2, result=4.21, commission=0.21, earning=4.42 },
            };
            phonesGrid.ItemsSource = phonesList;
        }

        private void titleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
