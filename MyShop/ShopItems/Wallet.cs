using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.ShopItems
{
    public class Wallet
    {
        private double MaxCash;

        public double MyCash
        {
            get
            {
                return MaxCash;
            }
        }

        public Wallet(double maxcash)
        {
            MaxCash = maxcash;
        }

    }
}
