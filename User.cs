using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMID
{
    public class User
    {
        public double balance { set; get; }
        public double Sell = 0;
        public double Buy = 0;

        public User()
        {
            balance = 300;
        }
    }
}
