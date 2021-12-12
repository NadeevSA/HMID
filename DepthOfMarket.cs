﻿using OxyPlot;
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
        public List<double> ActualPrices = new List<double>();
        public double ActualPrice = 0;
        private MainWindow form;
        public string Valuta;
        public static int Count = 0;
        public int N = 50;
        public string tab;
        public SolidColorBrush largeColor;
        public SolidColorBrush BuyColor;
        public SolidColorBrush SellColor;
        public SolidColorBrush ActiveColor;
        public int FontSize = 12;
        public double LargeRrice = 17000;
        public int Width = 140;
        public double diff = 0.15;
        public string name { get; set; }
        public string Title { get; private set; }
        public IList<DataPoint> Points { get; private set; }

        public DepthOfMarket()
        {
        }

        public DepthOfMarket(MainWindow form)
        {
            Random random = new Random();
            ActualPrice = random.Next(2, 6);
            Count++;
            this.form = form;
        }

        public DepthOfMarket(MainWindow form, double price)
        {
            Random random = new Random();
            ActualPrice = price;
            Count++;
            this.form = form;
        }

        public void GenerationDatas()
        {
            Random random = new Random();
            double price = ActualPrice + N/2 * diff;
            for (int i = 1; i <= N/2; ++i)
            {
                foreach (var child in form.panel1.Children)
                {
                    if (child is ListBox && (child as ListBox).Name == name)
                    {
                        Tuple<string, double> x = new Tuple<string, double>(Valuta, price);
                        if (Rialto.CountToPrice.ContainsKey(x))
                            (child as ListBox).Items.Add(new Data() { WidthColumn = this.Width / 2 - 12, name = this.name, FontSZ = this.FontSize, AmountToCurrency = Rialto.CountToPrice[x], PriceToCurrency = price, color = BuyColor });
                        else
                        {
                            double count = random.Next(1, 20000);
                            (child as ListBox).Items.Add(new Data() { WidthColumn = this.Width / 2 - 12, name = this.name, FontSZ = this.FontSize, AmountToCurrency = count, PriceToCurrency = price, color = BuyColor });
                            Rialto.CountToPrice[x] = count;
                        }
                        price = Math.Round(price - diff, 2);
                    }
                }
            }
            for (int i = 1; i <= N/2; ++i)
            {
                foreach (var child in form.panel1.Children)
                {
                    if (child is ListBox && (child as ListBox).Name == name)
                    {
                        Tuple<string, double> x = new Tuple<string, double>(Valuta, price);
                        if (Rialto.CountToPrice.ContainsKey(x))
                            (child as ListBox).Items.Add(new Data() { WidthColumn = this.Width / 2 - 12, name = this.name, FontSZ = this.FontSize, AmountToCurrency = Rialto.CountToPrice[x], PriceToCurrency = price, color = SellColor });
                        else
                        {
                            double count = random.Next(1, 20000);
                            (child as ListBox).Items.Add(new Data() { WidthColumn = this.Width / 2 - 12, name = this.name, FontSZ = this.FontSize, AmountToCurrency = count, PriceToCurrency = price, color = SellColor });
                            Rialto.CountToPrice[x] = count;
                        }
                        price = Math.Round(price - diff, 2);
                    }
                }
            }
            ActualPrices.Add(ActualPrice);
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
                ActualPrice = Rialto.ValutaCurrentPrice[Valuta];
                ActualPrices.Add(ActualPrice);
                form.Dispatcher.Invoke(
                    (ThreadStart)delegate ()
                    {
                        MainWindow.valuePairs[name].Text = "Валюта: " + Valuta + '\n' + "Цена за 1 шт. " + Math.Round(ActualPrice, 2) + " USD" +
                        '\n' + '\n' + "Объем одной" + '\n' + "покупки/продажи";
                        Random random = new Random();
                        for (int i = 0; i < N; ++i)
                        {
                            foreach (var child in form.panel1.Children)
                            {
                                Tuple<string, double> x = new Tuple<string, double>(Valuta, ((child as ListBox).Items[i] as Data).PriceToCurrency);

                                if (child is ListBox && (child as ListBox).Name == name && ((child as ListBox).Items[i] as Data).active)
                                {
                                    (child as ListBox).Items[i] = new Data() { active = true, WidthColumn = this.Width / 2 - 15, name = this.name, FontSZ = this.FontSize, AmountToCurrency = Rialto.CountToPrice[x], PriceToCurrency = ((child as ListBox).Items[i] as Data).PriceToCurrency, color = ActiveColor };
                                    break;
                                }
                                if (child is ListBox && (child as ListBox).Name == name && Rialto.CountToPrice[x] >= LargeRrice)
                                {
                                    (child as ListBox).Items[i] = new Data() { WidthColumn = this.Width/2 - 15, name = this.name, FontSZ = this.FontSize, AmountToCurrency = Rialto.CountToPrice[x], PriceToCurrency = ((child as ListBox).Items[i] as Data).PriceToCurrency, color = largeColor };
                                    break;
                                }
                                if (child is ListBox && (child as ListBox).Name == name && ((child as ListBox).Items[i] as Data).PriceToCurrency > ActualPrice)
                                {
                                    (child as ListBox).Items[i] = new Data() { WidthColumn = this.Width / 2 - 15, name = this.name, FontSZ = this.FontSize, AmountToCurrency = Rialto.CountToPrice[x], PriceToCurrency = ((child as ListBox).Items[i] as Data).PriceToCurrency, color = BuyColor };
                                    break;
                                }
                                if (child is ListBox && (child as ListBox).Name == name && ((child as ListBox).Items[i] as Data).PriceToCurrency <= ActualPrice)
                                {
                                    (child as ListBox).Items[i] = new Data() { WidthColumn = this.Width / 2 - 15, name = this.name, FontSZ = this.FontSize, AmountToCurrency = Rialto.CountToPrice[x], PriceToCurrency = ((child as ListBox).Items[i] as Data).PriceToCurrency, color = SellColor };
                                    break;
                                }
                            }
                        }
                    });
                Thread.Sleep(1000);
            }
        }

        public ListBox CreateList()
        {
            string template = "CarsDataTemplate";
            listBox.ItemTemplate = form.Resources[template] as DataTemplate;
            listBox.Name = name;
            listBox.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#181818"));
            listBox.Width = Width;
            listBox.Height = form.Height - 175;
            return listBox;
        }

        public ListBox ReturnListBox()
        {
            return listBox;
        }
    }
}
