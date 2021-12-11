using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace HMID
{
    public class DepthOfMarket
    {
        private ListBox listBox = new ListBox();
        private double ActualPrice;
        private MainWindow form;
        public static int Count = 0;
        public int N = 46;
        public string tab;
        public SolidColorBrush largeColor;
        public int FontSize = 12;
        public double LargeRrice = 17000;
        public int Width = 140;
        public string name { get; set; }
        public string Title { get; private set; }
        public IList<DataPoint> Points { get; private set; }

        public DepthOfMarket()
        {
        }

        public DepthOfMarket(MainWindow form)
        {
            Random random = new Random();
            ActualPrice = random.Next(6, 30);
            Count++;
            this.form = form;
        }

        public void GenerationDatas()
        {
            Random random = new Random();
            double price = ActualPrice + N/2 * 0.05;
            for (int i = 1; i <= N/2; ++i)
            {
                foreach (var child in form.panel1.Children)
                {
                    if (child is ListBox && (child as ListBox).Name == name)
                    {
                        (child as ListBox).Items.Add(new Data() { WidthColumn = this.Width / 2 - 12, name = this.name, FontSZ = this.FontSize, AmountToCurrency = random.Next(1, 20000), PriceToCurrency = price, color = new SolidColorBrush(Color.FromRgb(228, 182, 184)) });
                        price = Math.Round(price - 0.05, 2);
                    }
                }
            }
            for (int i = 1; i <= N/2; ++i)
            {
                foreach (var child in form.panel1.Children)
                {
                    if (child is ListBox && (child as ListBox).Name == name)
                    {
                        (child as ListBox).Items.Add(new Data() { WidthColumn = this.Width / 2 - 12, name = this.name, FontSZ = this.FontSize, AmountToCurrency = random.Next(1, 20000), PriceToCurrency = price, color = Brushes.LightGreen });
                        price = Math.Round(price - 0.05, 2);
                    }
                }
            }
            CreateToThread();
        }

        private void CreateToThread()
        {
            Thread myThread = new Thread(new ThreadStart(Update));
            myThread.Start();
        }

        private void Update()
        {
            while (true)
            {
                Random random = new Random();
                if (random.Next(0,2) == 1)
                {
                    ActualPrice += 0.05;
                }
                else
                {
                    ActualPrice -= 0.05;
                }
                form.Dispatcher.Invoke(
                    (ThreadStart)delegate ()
                    {
                        Random random = new Random();
                        for (int i = 0; i < N; ++i)
                        {
                            foreach (var child in form.panel1.Children)
                            {
                                double rnd = random.Next(1, 20000);
                                if (child is ListBox && (child as ListBox).Name == name && rnd >= LargeRrice)
                                {
                                    (child as ListBox).Items[i] = new Data() { WidthColumn = this.Width/2 - 12, name = this.name, FontSZ = this.FontSize, AmountToCurrency = rnd, PriceToCurrency = ((child as ListBox).Items[i] as Data).PriceToCurrency, color = largeColor };
                                    break;
                                }
                                if (child is ListBox && (child as ListBox).Name == name && ((child as ListBox).Items[i] as Data).PriceToCurrency > ActualPrice)
                                {                                    
                                    (child as ListBox).Items[i] = new Data() { WidthColumn = this.Width / 2 - 12, name = this.name, FontSZ = this.FontSize, AmountToCurrency = rnd, PriceToCurrency = ((child as ListBox).Items[i] as Data).PriceToCurrency, color = new SolidColorBrush(Color.FromRgb(228, 182, 184)) };
                                    break;
                                }
                                if (child is ListBox && (child as ListBox).Name == name && ((child as ListBox).Items[i] as Data).PriceToCurrency <= ActualPrice)
                                {
                                    (child as ListBox).Items[i] = new Data() { WidthColumn = this.Width / 2 - 12, name = this.name, FontSZ = this.FontSize, AmountToCurrency = rnd, PriceToCurrency = ((child as ListBox).Items[i] as Data).PriceToCurrency, color = Brushes.LightGreen };
                                    break;
                                }
                            }
                        }
                    });
                Thread.Sleep(5000);
            }
        }

        public ListBox CreateList()
        {
            string template = "CarsDataTemplate";
            listBox.ItemTemplate = form.Resources[template] as DataTemplate;
            listBox.Name = name;
            listBox.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#181818"));
            listBox.Width = Width;
            listBox.Height = form.Height;
            return listBox;
        }

        public ListBox ReturnListBox()
        {
            return listBox;
        }
    }
}
