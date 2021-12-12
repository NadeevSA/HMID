using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HMID
{
    public class Rialto
    {
        public static Dictionary<string, double> ValutaCurrentPrice = new Dictionary<string, double>();
        public static Dictionary<Tuple<string, double>, double> CountToPrice = new Dictionary<Tuple<string, double>, double>();
        private MainWindow form;

        public void NewCurrentPrice(string valuta, double diff = 0.15)
        {
            Random random = new Random();
            if (random.Next(0, 2) == 1)
            {
                ValutaCurrentPrice[valuta] += diff;
            }
            else
            {
                ValutaCurrentPrice[valuta] -= diff;
            }
        }

        public void NewCountToPrice(Tuple<string, double> price)
        {
            Random random = new Random();
            if (random.Next(0, 2) == 1 || CountToPrice[price] - 1000 <= 0)
            {
                CountToPrice[price] += 1000;
            }
            else
            {
                CountToPrice[price] -= 1000;
            }
        }

        public Rialto(MainWindow form)
        {
            this.form = form;
            Thread myThread = new Thread(new ThreadStart(Update));
            myThread.Start();
        }

        private void Update()
        {
            while (true)
            {
                form.Dispatcher.Invoke(
                    (ThreadStart)delegate ()
                    {
                        foreach (var item in ValutaCurrentPrice.Keys)
                        {
                            NewCurrentPrice(item);
                        }
                        foreach (var item in CountToPrice.Keys)
                        {
                            NewCountToPrice(item);
                        }
                    });
                Thread.Sleep(1000);
            }
        }
    }
}
