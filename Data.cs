using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HMID
{
    class Data
    {
        public double AmountToCurrency { get; set; }
        public double PriceToCurrency { get; set; }
        public double WidthColumn { get; set; }
        public double FontSZ { get; set; }
        public string name { get; set; }
        public Brush color { get; set; }
        public bool active = false;

        public double NewPrice()
        {
            Random random = new Random();
            if (random.Next(0, 2) == 1 || AmountToCurrency - 1000 <= 0)
            {
                AmountToCurrency += 1000;
            }
            else
            {
                AmountToCurrency -= 1000;
            }
            return AmountToCurrency;
        }
    }
}
