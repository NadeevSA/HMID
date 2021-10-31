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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HMID
{
    public partial class MainWindow : Window
    {
        public class Ctakan
        {
            // TODO: Написать название и сам класс нормально
            public double number1 { get; set; }
            public double number2 { get; set; }
            public Brush color { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            // TODO: Сделать сбор данных из БД
            //Random random = new Random();
            //for (int i = 1; i <= 14; ++i)
            //{
            //    lbTodoList.Items.Add(new Ctakan() { number1 = (double)random.Next(100) / random.Next(1, 3), number2 = (double)random.Next(100) / random.Next(1, 3), color = Brushes.Pink });
            //}
            //lbTodoList.Items.Add(new Ctakan() { number1 = (double)random.Next(100) / random.Next(1, 3), number2 = (double)random.Next(100) / random.Next(1, 3), color = Brushes.Red });
            //for (int i = 1; i <= 5; ++i)
            //{
            //    lbTodoList.Items.Add(new Ctakan() { number1 = (double)random.Next(100)/random.Next(1, 3), number2 = (double)random.Next(100)/random.Next(1, 3), color = Brushes.White });
            //}
            //lbTodoList.Items.Add(new Ctakan() { number1 = (double)random.Next(100) / random.Next(1, 3), number2 = (double)random.Next(100) / random.Next(1, 3), color = Brushes.Green });
            //for (int i = 1; i <= 19; ++i)
            //{
            //    lbTodoList.Items.Add(new Ctakan() { number1 = (double)random.Next(100) / random.Next(1, 3), number2 = (double)random.Next(100) / random.Next(1, 3), color = Brushes.LightGreen });
            //}
        }

        bool f = true;
        int j = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //lbTodoList1.Items.Add(new Ctakan() { number1 = 10, number2 = 5, color = Brushes.LightGreen });
            if (f == true)
            {
                ListBox listBox = new ListBox();
                string template = "CarsDataTemplate";
                WrapPanel dynamicWrapPanel = new WrapPanel();
                //f = false;
                listBox.ItemTemplate = this.Resources[template] as DataTemplate;
                listBox.Name = "test";
                listBox.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#181818"));
                listBox.Width = 140;
                listBox.Height = this.Height - 180;
                panel1.Children.Add(listBox);
               // panel1.Children.RemoveAt(2);
            }
            foreach (var child in panel1.Children)
            {
                if(child is ListBox && (child as ListBox).Name == "test")
                    (child as ListBox).Items.Add(new Ctakan() { number1 = (10 + j), number2 = 5, color = Brushes.LightGreen });
                j++;
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            foreach (var child in panel1.Children)
            {
                if (child is ListBox && (child as ListBox).Name == "test")
                {
                    int max = (child as ListBox).Items.Count;
                   // (child as ListBox).Items.RemoveAt(0);
                    (child as ListBox).Items.RemoveAt(max - 1);
                }
            }
        }
    }
}
