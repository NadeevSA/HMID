using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace HMID
{
    public class MainViewModel
    {
        public PlotModel DataPlot { get; set; }
        private DepthOfMarket depthOfMarket;
        private string depthOfMarketName;
        int y = 0;
        int i = 0;
        int count = 0;
        public MainViewModel()
        {
            DataPlot = new PlotModel();
            DataPlot.Series.Add(new LineSeries());
            depthOfMarketName = MainWindow._name;
            foreach(var dom in MainWindow.depthOfMarkets)
            {
                if(dom.name == depthOfMarketName)
                {
                    depthOfMarket = dom;
                }
            }
            var dispatcherTimer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 1) };
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Dispatcher.CurrentDispatcher.Invoke(() =>
            {
                for (int j = i; j < depthOfMarket.ActualPrices.Count; ++j)
                {
                    (DataPlot.Series[0] as LineSeries).Points.Add(new DataPoint(y++, depthOfMarket.ActualPrices[j]));
                    DataPlot.InvalidatePlot(true);
                }
                i = depthOfMarket.ActualPrices.Count;
            });
        }
    }
}
