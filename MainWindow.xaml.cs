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
            //    lbTodoList.Items.Add(new Ctakan() { number1 = (double)random.Next(100)/random.Next(1, 3), number2 = (double)random.Next(100)/random.Next(1, 3), color = Brushes.Pink });
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //lbTodoList1.Items.Add(new Ctakan() { number1 = 10, number2 = 5, color = Brushes.LightGreen });
            ListBox listBox = new ListBox();
            if (f == true)
            {
                WrapPanel dynamicWrapPanel = new WrapPanel();
                f = false;
                listBox.Name = "asd";
                listBox.Width = 140;
                listBox.Items.Add(new Ctakan() { number1 = 11, number2 = 5, color = Brushes.LightGreen });
                panel1.Children.Add(listBox);
            }
        }
    }
}
